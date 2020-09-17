// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System
open System.Numerics
open System.Collections.Generic
open ArrayFire

[<EntryPoint>]
let main argv = 

    Device.SetBackend(Backend.DEFAULT)
    Device.PrintInfo()
    printfn "\n=== ArrayFire signed(s32) / unsigned(u32) Integer Example ===\n"

    let h_A = array2D[ [ 1; 2; 4 ]; [ -1; 2; 0 ]; [ 4; 2; 3 ] ]
    let h_B = array2D[ [ 2; 3; -5 ]; [ 6; 0; 10 ]; [ -12; 0; 1 ] ]
    //printfn "Array 2D is %A" h_A.GetType()
    let A = Data.CreateArray(h_A)
    let B = Data.CreateArray(h_B)
    printfn "--\nSub-refencing and Sub-assignment\n"
    
    Util.Print(A, "A");
    Util.Print(A.Rows(0, 0), "A's first row")
    Util.Print(A.Cols(0, 0), "A's first column")
    A.[Util.Seq(0, 0), Util.Seq(0, 0)] <- Data.CreateArray([|100|])
    A.[Util.Seq(1, 1), Util.Seq(2, 2)] <- Data.CreateArray([|100|])
    Util.Print(A, "A")
    Util.Print(B, "B")
    A.[Util.Seq(1, 1), Util.Span] <- B.[Util.Seq(2, 2), Util.Span]
    Util.Print(A, "A")
    Util.Print(B, "B")
    let C = A + B
    printf "--Bit-wise operations\n"
    Util.Print(A &&& B, "A &&& B")
    Util.Print(A ||| B, "A ||| B")
    Util.Print(A ^^^ B, "A ^^^ B")
    
    printfn "\n--Transpose\n"
    Util.Print(A, "A")
    Util.Print(Matrix.Transpose(A, false), "Matrix.Transpose(A)")
    
    printfn "\n--Sum along columns\n"
    Util.Print(A, "A")
    Util.Print(Algorithm.Sum(A), "Algorithm.Sum(A)")
    
    printfn "\n--Product along columns\n"
    Util.Print(A, "A")
    Util.Print(Algorithm.Product(A), "Algorithm.Product(A)")
    
    printfn "\n--Minimum along columns\n"
    Util.Print(A, "A")
    Util.Print(Algorithm.Min(A), "Algorithm.Min(A)")
    
    printfn "\n--Maximum along columns\n"
    Util.Print(A, "A")
    Util.Print(Algorithm.Max(A), "Algorithm.Max(A)")
    
    printfn "\n--Minimum along columns with index\n"
    Util.Print(A, "A")
    
    let mutable idx = null
    let outArray = Algorithm.Min(A, &idx)
    Util.Print(outArray, "output")
    Util.Print(idx, "indexes")

    0 // return an integer exit code
