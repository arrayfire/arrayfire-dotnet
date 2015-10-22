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
open System.Text.RegularExpressions

module Utils =

    // performs the cartesian product of two lists
    let listCartesian xlist ylist = xlist |> List.collect (fun x -> ylist |> List.map (fun y -> x,y))

    // a version of Regex.Replace that supports $Ux and $Lx as the uppercase and lowercase versions of $x where x is the group number (e.g. $U1 is the same as $1 but in lowercase)
    let replaceLU input pattern replacement =
        let mev (mat:Match) =
            let mutable res = mat.Result replacement
            for i = 1 to mat.Groups.Count - 1 do
                res <- Regex.Replace(res, "\$U" + i.ToString(), mat.Groups.[i].Value.ToUpper())
                res <- Regex.Replace(res, "\$L" + i.ToString(), mat.Groups.[i].Value.ToLower())
            res
        Regex.Replace(input, pattern, mev)

    // loads a file as a list of lines
    let loadLinesFromFile (file:string) =
        use sr = new StreamReader(file)
        let line = sr.ReadLine() |> ref
        seq {
            while !line <> Unchecked.defaultof<string> do
                yield !line
                line := sr.ReadLine()
        } |> Seq.toList // evaluate sequence

    // saves a list of lines to a file
    let saveLinesToFile (file:string) (lines:string list) =
        use sw = new StreamWriter(file, false)
        for line in lines do line.TrimEnd() |> sw.WriteLine
