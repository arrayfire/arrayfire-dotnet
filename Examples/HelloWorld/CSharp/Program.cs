using System;
using System.Numerics;
using System.Collections.Generic;

using ArrayFire;

// If using Visual Studio 2015 you can uncomment the following lines and type Sin() instead of Arith.Sin(), Seq() instead of Util.Seq(), and so on.
// using static ArrayFire.Arith;
// using static ArrayFire.Util;

namespace CSharpTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Device.SetBackend(Backend.CPU);
            var arr1 = Data.RandNormal<float>(3, 3);
            var arr2 = Data.RandNormal<float>(3, 3);
            var arr3 = arr1 + arr2;
            var arr4 = Matrix.Multiply(arr1, arr2);
            var arr5 = Arith.Sin(arr1) + Arith.Cos(arr2);
            Util.Print(arr1, "arr1");
            Util.Print(arr2, "arr2");
            Util.Print(arr3, "arr1 + arr2");
            Util.Print(arr4, "arr1 * arr2 (matrix product)");
            Util.Print(arr5, "Sin(arr1) + Cos(arr2)");

            // new! indexing:    
            Util.Print(arr1[Util.Span, 0], "arr1's first column");
            Util.Print(arr1.Cols(0, 0), "arr1's first row (again)");
            var corner = arr1[Util.Seq(0, 1), Util.Seq(0, 1)];
            Util.Print(corner, "arr1's top-left 2x2 corner");
            arr2[Util.Seq(1, 2), Util.Seq(1, 2)] = corner;
            Util.Print(arr2, "arr2 with botton-right 2x2 corner ovewritten with the previous result");

        }
    }
}
