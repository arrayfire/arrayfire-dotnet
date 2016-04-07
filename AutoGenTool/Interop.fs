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

    let private fixTypes =
        replaceWord Anywhere "unsigned" "uint" >> 
        replaceWord Anywhere "intl" "long" >> 
        replaceWord Anywhere "uintl" "ulong"

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
                "const\s+af_seq\s*\*\s*(?:const\s+)?(\w+)",     "[In] af_seq[] $1";
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
        | Some (pat, rep) -> 
            Regex.Replace(param, pat, rep) 
            |> replaceWord LastWord "in" "input"
            |> replaceWord LastWord "out" "output"
        | None -> "???" + param + "???"

    let private finalFixes api str =
        if api = "af_assign_seq" then replaceWord FirstWord "out" "ref" str
        else if str.Contains("af_index_t") && not (str.Contains "???") then replaceWord Anywhere "af_index_t" "???af_index_t???" str
        else str

    let private getFileMatches (file:string) =
        let matches =
            use sr = new StreamReader(file)
            Regex.Matches(sr.ReadToEnd(), "AFAPI\s+af_err\s+(\w+)\s*\(\s*(?:([\w\s\d\*]+)\s*[,)]\s*)*")
        seq {
            for mat in matches do
                let apiname = mat.Groups.[1].Value
                let parcaps = mat.Groups.[2].Captures
                yield apiname, [ for cap in parcaps -> cap.Value.Trim() |> fixTypes |> transformParameter |> finalFixes apiname ] |> String.concat ", "
        } |> Seq.toList // lazy -> eager (release regex/match resources)

    let private getEnums (file:string) =
        let matches =
            use sr = new StreamReader(file)
            Regex.Matches(sr.ReadToEnd(), "typedef\s+enum\s{([^}]+)}\s+(\w+)")
        seq {
            for mat in matches do
                let fixline (line:string) = 
                    let trim = line.Trim()
                    if trim.StartsWith "#" then "// " + trim else trim 
                let vals = mat.Groups.[1].Value.Trim().Split('\n') |> Array.map fixline
                let name = mat.Groups.[2].Value
                yield name, vals
        } |> Seq.toList // lazy -> eager (release regex/match resources)

    let generate() =
        let root = INCLUDE_DIR |> List.find Directory.Exists

        do
            use cw = new CodeWriter(OUTPUT_DIR + "/Interop/enums.cs")
            let mutable is1st = true
            Console.WriteLine "Enumerations:"
            for enum in getEnums (root + "/defines.h") do
                if is1st then is1st <- false else cw <=- ""
                cw <=- "public enum " + (fst enum)
                cw <=- "{"
                for value in snd enum do cw <=- value
                cw <=- "}"
                Console.WriteLine (" + " + (fst enum))
            Console.WriteLine()

        let namelower file = Path.GetFileNameWithoutExtension(file).ToLower()
        let upperFirst (name:string) = name.Substring(0,1).ToUpper() + name.Substring(1)

        let files =
            let find lst elem = List.exists ((=) elem) lst
            Directory.GetFiles(root, "*.h") |> Array.toList |> List.filter (namelower >> find SKIP_INCLUDES >> not)

        for file in files do
            let matches = getFileMatches file
            if List.isEmpty matches |> not then
                let name = "AF" + (file |> namelower |> upperFirst)
                Console.WriteLine ("class " + name + ":")
                use cw = new CodeWriter(OUTPUT_DIR + "/Interop/" + name + ".cs")
                cw <=- "[SuppressUnmanagedCodeSecurity]"
                cw <=- "public static class " + name
                cw <=- "{"
                let mutable is1st = true
                for api, pars in matches do
                    let unsupported = pars.Contains("???")
                    let versions =
                        if not unsupported && pars.Contains("T[_]") then
                            [ "bool"; "Complex"; "float"; "double"; "int"; "long"; "uint"; "ulong"; "byte"; "short"; "ushort" ]
                            |> listCartesian [ "[]"; "[,]"; "[,,]"; "[,,,]" ]
                            |> List.map (fun (x,y) -> pars.Replace("T[_]", y + x))
                        else [ pars ]
                    for vpars in versions do
                        if is1st then is1st <- false else cw <=- ""
                        if unsupported then cw <=- "/* not yet supported:"
                        else Console.WriteLine (" + " + api)
                        cw <=- "[DllImport(af_config.dll, ExactSpelling = true, SetLastError = false, CallingConvention = CallingConvention.Cdecl)]"
                        cw <=- "public static extern af_err " + api + "(" + vpars + ");" + (if unsupported then " */" else "")
                cw <=- "}"
                Console.WriteLine()

