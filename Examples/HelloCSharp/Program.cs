using System;
using System.Numerics;
using System.Collections.Generic;

using ArrayFire;
using static ArrayFire.Arith;

namespace CSharpTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr1 = Data.RandNormal<double>(3, 3);
            var arr2 = Data.RandNormal<double>(3, 3);
            var arr3 = arr1 + arr2;
            var arr4 = Matrix.Multiply(arr1, arr2);
            var arr5 = Sin(arr1) + Cos(arr2); // thanks to: using static ArrayFire.Arith;
            Util.Print(arr1, "arr1");
            Util.Print(arr2, "arr2");
            Util.Print(arr3, "arr1 + arr2");
            Util.Print(arr4, "arr1 * arr2 (matrix product)");
            Util.Print(arr5, "Sin(arr1) + Cos(arr2)");
        }
    }
}
