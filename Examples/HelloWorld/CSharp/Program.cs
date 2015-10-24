using System;
using System.Numerics;
using System.Collections.Generic;

using ArrayFire;

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
        }
    }
}
