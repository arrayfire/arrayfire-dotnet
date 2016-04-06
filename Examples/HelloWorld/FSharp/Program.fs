// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System
open System.Numerics
open System.Collections.Generic
open ArrayFire

[<EntryPoint>]
let main argv = 

    Device.SetBackend(Backend.CPU)
    let arr1 = Data.RandNormal<double>(3, 3)
    let arr2 = Data.RandNormal<double>(3, 3)
    let arr3 = arr1 + arr2
    let arr4 = Matrix.Multiply(arr1, arr2)
    let arr5 = (sin arr1) + (cos arr2)
    Util.Print(arr1, "arr1")
    Util.Print(arr2, "arr2")
    Util.Print(arr3, "arr1 + arr2")
    Util.Print(arr4, "arr1 * arr2 (matrix product)")
    Util.Print(arr5, "sin(arr1) + cos(arr2)");

    // new! indexing:    
    Util.Print(arr1.[Util.Span, Util.Seq(0,0)], "arr1's first column");
    Util.Print(arr1.Cols(0, 0), "arr1's first row (again)");
    let corner = arr1.[Util.Seq(0, 1), Util.Seq(0, 1)]
    Util.Print(corner, "arr1's top-left 2x2 corner")
    arr2.[Util.Seq(1, 2), Util.Seq(1, 2)] <- corner
    Util.Print(arr2, "arr2 with botton-right 2x2 corner ovewritten with the previous result");

    0 // return an integer exit code
