// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System
open System.Numerics
open System.Collections.Generic
open ArrayFire

[<EntryPoint>]
let main argv = 

    let arr1 = Data.RandNormal<double>(3, 3)
    let arr2 = Data.RandNormal<double>(3, 3)
    let arr3 = arr1 + arr2
    let arr4 = Matrix.Multiply(arr1, arr2)
    let arr5 = (sin arr1) + (cos arr2) // thanks to F# Core.Operators 
    Util.Print(arr1, "arr1")
    Util.Print(arr2, "arr2")
    Util.Print(arr3, "arr1 + arr2")
    Util.Print(arr4, "arr1 * arr2 (matrix product)")
    Util.Print(arr5, "sin(arr1) + cos(arr2)");

    0 // return an integer exit code
