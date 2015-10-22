(*
Copyright (c) 2015, ArrayFire
Copyright (c) 2015, Steven Burns (royalstream@hotmail.com)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice, this
  list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice,
  this list of conditions and the following disclaimer in the documentation
  and/or other materials provided with the distribution.

* Neither the name of arrayfire_dotnet nor the names of its
  contributors may be used to endorse or promote products derived from
  this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*)

namespace AutoGenTool

open System
open System.IO
open System.Text
open System.Collections.Generic
open System.Text.RegularExpressions

open Config
open Utils

// generate the /ArrayFire/Interop/*.cs classes
module Interop =

    let private fixTypes str =
        [   "unsigned",     "uint";
            "intl",         "long";
            "uintl",        "ulong"
        ] |> List.fold (fun s x -> Regex.Replace(s, @"\b" + (fst x) + @"\b", snd x)) str

    let private fixParamName str =
        [   "in",   "input";
            "out",  "output"
        ] |> List.fold (fun s x -> Regex.Replace(s, @"\b" + (fst x) + "$", snd x)) str // "$" to anchor to the end

    let private transformParameter (param:string) =
        let ismatch pat = Regex.IsMatch(param, "^" + pat + "$")
        match [ // long-typedef inputs:
                "(?:const\s+)?af_window\s+(\w+)",               "long window_$1";
                "(?:const\s+)?dim_t\s+(\w+)",                   "long dim_$1";
                // pointer-sized inputs:
                "(?:const\s+)?size_t\s+(\w+)",                  "UIntPtr size_$1";
                "(?:const\s+)?af_array\s+(\w+)",                "IntPtr array_$1";
                // array inputs:
                "const\s+af_array\s*\*\s*(?:const\s+)?(\w+)",   "[In] IntPtr[] array_$1";
                "const\s+dim_t\s*\*\s*(?:const\s+)?(\w+)",      "[In] long[] dim_$1";
                "const\s+void\s*\*\s*(?:const\s+)?(\w+)",       "[In] T[_] $1"
                "const\s+char\s*\*\s*(?:const\s+)?(\w+)",       "string $1";
                // trivial-case inputs:
                "(?:const\s+)?(\w+)\s+(\w+)",                   "$1 $2";
                // long-typedef outputs:
                "dim_t\s*\*\s*(\w+)",                           "out long dim_$1";
                "af_window\s*\*\s*(\w+)",                       "out long window_$1";
                // pointer-sized outputs:
                "af_array\s*\*\s*(\w+)",                        "out IntPtr array_$1";
                "size_t\s*\*\s*(\w+)",                          "out UIntPtr size_$1";
                // array outputs:
                "void\s*\*\s*(\w+)",                            "[Out] T[_] $1";
                "char\s*\*\s*(\w+)",                            "[Out] StringBuilder $1";
                // trivial-case outputs:
                "(\w+)\s*\*\s*(\w+)",                           "out $1 $2";
            ] |> List.tryFind (fst >> ismatch) with
        | Some (pat, rep) -> Regex.Replace(param, pat, rep) |> fixParamName
        | None -> "???" + param + "???"

    let private getFileMatches (file:string) =
        let matches =
            use sr = new StreamReader(file)
            Regex.Matches(sr.ReadToEnd(), "AFAPI\s+af_err\s+(\w+)\s*\(\s*(?:([\w\s\d\*]+)\s*[,)]\s*)*")
        seq {
            for mat in matches do
                let apiname = mat.Groups.[1].Value
                let parcaps = mat.Groups.[2].Captures
                yield apiname, [ for cap in parcaps -> cap.Value.Trim() |> fixTypes |> transformParameter ] |> String.concat ", "
        } |> Seq.toList // lazy -> eager (release regex/match resources)

    let private getEnums (file:string) =
        let matches =
            use sr = new StreamReader(file)
            Regex.Matches(sr.ReadToEnd(), "typedef\s+enum\s{([^}]+)}\s+(\w+)")
        seq {
            for mat in matches do
                let vals = mat.Groups.[1].Value.Trim().Split('\n') |> Array.map (fun x -> x.Trim())
                let name = mat.Groups.[2].Value
                yield name, vals
        } |> Seq.toList // lazy -> eager (release regex/match resources)

    let generate() =
        let root = INCLUDE_DIR |> List.find Directory.Exists

        do
            use cw = new CodeWriter(OUTPUT_DIR + "/Interop/enums.cs")
            cw <=- "internal static class af_config // put here for convenience"
            cw <=- "{"
            cw <=- "internal const string dll = @\"" + DLL_NAME + "\";"
            cw <=- "}"
            Console.WriteLine "Enumerations:"
            for enum in getEnums (root + "/defines.h") do
                cw <=- ""
                cw <=- "public enum " + (fst enum)
                cw <=- "{"
                for value in snd enum do cw <=- value
                cw <=- "}"
                Console.WriteLine (" + " + (fst enum))
            Console.WriteLine()

        let namelower file = Path.GetFileNameWithoutExtension(file).ToLower()
        //let upperFirst (name:string) = name.Substring(0,1).ToUpper() + name.Substring(1)

        let files =
            let find lst elem = List.exists ((=) elem) lst
            Directory.GetFiles(root, "*.h") |> Array.toList |> List.filter (namelower >> find SKIP_INCLUDES >> not)

        for file in files do
            let matches = getFileMatches file
            if List.isEmpty matches |> not then
                let name = "af_" + (file |> namelower)
                Console.WriteLine ("class " + name + ":")
                use cw = new CodeWriter(OUTPUT_DIR + "/Interop/" + name + ".cs")
                cw <=- "[SuppressUnmanagedCodeSecurity]"
                cw <=- "public static class " + name
                cw <=- "{"
                let mutable is1st = true
                for api, pars in matches do
                    let unsupp = pars.Contains("???")
                    let versions =
                        if not unsupp && pars.Contains("T[_]") then
                            let add x y = y + x
                            [ "bool"; "Complex"; "float"; "double"; "int"; "long"; "uint"; "ulong"; "byte" ]
                            |> listCartesian [ "[]"; "[,]"; "[,,]"; "[,,,]" ]
                            |> List.map (fun (x,y) -> pars.Replace("T[_]", y + x))
                        else [ pars ]
                    for vpars in versions do
                        if is1st then is1st <- false else cw <=- ""
                        if unsupp then cw <=- "/* not yet supported:"
                        else Console.WriteLine (" + " + api)
                        cw <=- "[DllImport(af_config.dll, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]"
                        cw <=- "public static extern af_err " + api + "(" + vpars + ");" + (if unsupp then " */" else "")
                cw <=- "}"
                Console.WriteLine()

