// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System
open System.Numerics
open System.Collections.Generic
open ArrayFire

[<EntryPoint>]
let main argv = 

    let testBackend() = 
        Device.PrintInfo()
        let arr1 = Data.RandNormal<single>(3, 3)
        let arr2 = Data.RandNormal<single>(3, 3)
        let arr3 = arr1 + arr2
        let arr4 = Matrix.Multiply(arr1, arr2)
        let arr5 = (sin arr1) + (cos arr2)
        Util.Print(arr1, "arr1")
        Util.Print(arr2, "arr2")
        Util.Print(arr3, "arr1 + arr2")
        Util.Print(arr4, "arr1 * arr2 (matrix product)")
        Util.Print(arr5, "sin(arr1) + cos(arr2)");

    try
        printfn "Testing CPU Backend"
        Device.SetBackend Backend.CPU
        testBackend()
    with
    | ex -> printfn "%s" (ex.ToString())

    try
        printfn "Testing CUDA Backend"
        Device.SetBackend Backend.CUDA
        testBackend()
    with
    | ex -> printfn "%s" (ex.ToString())

    try
        printfn "Testing OPENCL Backend"
        Device.SetBackend Backend.OPENCL
        testBackend()
    with
    | ex -> printfn "%s" (ex.ToString())

    0 // return an integer exit code
