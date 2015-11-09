using System;
using System.Numerics;
using System.Collections.Generic;

using ArrayFire;

namespace CSharpTesting
{
    class Program
    {
        static void TestBackend()
        {
            Device.PrintInfo();
            Console.WriteLine(Device.BackendCount);
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

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Testing CPU Backend");
                Device.SetBackend(Backend.CPU);
                TestBackend();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            try
            {
                Console.WriteLine("Testing CUDA Backend");
                Device.SetBackend(Backend.CUDA);
                TestBackend();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            try
            {
                Console.WriteLine("Testing OPENCL Backend");
                Device.SetBackend(Backend.OPENCL);
                TestBackend();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }
    }
}
