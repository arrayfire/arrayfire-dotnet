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

// expand the for-in-do loops in the /ArrayFire/*.cs files
module ForInDo =

    let rec private processFile (lines:string list) (changed,result) =
        match lines with
        | [] -> (changed,result |> List.rev)
        | line::rest ->
            if Regex.IsMatch(line, "^\s*#if\s*_") then
                processFor rest (changed, line::result)
            else processFile rest (changed, line::result)

    and private processFor lines (changed,result) =
        match lines with
        [] -> failwith "syntax error"
        | line::rest ->
            let mat = Regex.Match(line, "^\s*for\s+([^\s]+)\s+in\s*$")
            if mat.Success then
                let patt = mat.Groups.[1].Value
                processIn rest (line::result) patt []
            else processFile rest (changed, line::result)

    and private processIn lines result patt items =
        match lines with
        [] -> failwith "syntax error"
        | line::rest ->
            if Regex.IsMatch(line, "^\s*do\s*$") then
                let mats = [ for mat in Regex.Matches(items |> List.rev |> String.concat " ", patt) -> mat.Value ] |> List.rev
                processDo rest (line::result) patt mats []
            else processIn rest (line::result) patt (line::items)

    and private processDo lines result patt mats repls =
        match lines with
        [] -> failwith "syntax error"
        | line::rest ->
            if Regex.IsMatch(line, "^\s*#else") then
                let addNewLine = function [one] -> [one] | many -> ""::many
                let cutEmptyHead = function ""::rest -> rest | other -> other
                let replaces = repls |> addNewLine |> listCartesian mats |> List.map (fun (m,r) -> replaceLU patt r m)
                processEnd rest ((cutEmptyHead replaces) @ (line::result))
            else processDo rest (line::result) patt mats (line::repls)

    and private processEnd lines result =
        match lines with
        | [] -> failwith "syntax error"
        | line::rest ->
            if Regex.IsMatch(line, "^\s*#endif") then
                processFile rest (true, line::result)
            else processEnd rest result // intentionally dont add it to the results

    let expand() =

        let files = Directory.GetFiles(OUTPUT_DIR, "*.cs")
        for file in files do
            try
                let lines = loadLinesFromFile file
                let changed, results = processFile lines (false,[])
                if changed then
                    results |> saveLinesToFile file
                    Console.WriteLine (file + " ... [ok]")
            with
            | _ -> Console.WriteLine ("Error processing " + file)

