using ArrayFire;
using System;

namespace GettingStarted__Integer__CSharp_
{
    /// <summary>
    /// port from getting_started\integer.cpp
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Device.SetBackend(Backend.DEFAULT);
            Device.PrintInfo();
            Console.Write("\n=== ArrayFire signed(s32) / unsigned(u32) Integer Example ===\n");

            int[,] h_A = new int[,]{ { 1, 2, 4 }, { -1, 2, 0 }, { 4, 2, 3 } };
            int[,] h_B = new int[,] { { 2, 3, -5 }, { 6, 0, 10 }, { -12, 0, 1 } };

            ArrayFire.Array A = Data.CreateArray(h_A);
            ArrayFire.Array B = Data.CreateArray(h_B);

            Console.Write("--\nSub-refencing and Sub-assignment\n");

            Util.Print(A, "A");
            Util.Print(A.Rows(0, 0), "A's first row");
            Util.Print(A.Cols(0, 0), "A's first column");
            A[0, 0] = Data.CreateArray(new int[] { 100 });
            A[1, 2] = Data.CreateArray(new int[] { 100 });
            Util.Print(A, "A");
            Util.Print(B, "B");
            A[1, Util.Span] = B[2, Util.Span];
            Util.Print(A, "A");
            Util.Print(B, "B");

            Console.Write("--Bit-wise operations\n");
            Util.Print(A & B, "A & B");
            Util.Print(A | B, "A | B");
            Util.Print(A ^ B, "A ^ B");

            Console.Write("\n--Transpose\n");
            Util.Print(A, "A");
            Util.Print(Matrix.Transpose(A, false), "Matrix.Transpose(A)");

            Console.Write("\n--Sum along columns\n");
            Util.Print(A, "A");
            Util.Print(Algorithm.Sum(A), "Algorithm.Sum(A)");

            Console.Write("\n--Product along columns\n");
            Util.Print(A, "A");
            Util.Print(Algorithm.Product(A), "Algorithm.Product(A)");

            Console.Write("\n--Minimum along columns\n");
            Util.Print(A, "A");
            Util.Print(Algorithm.Min(A), "Algorithm.Min(A)");

            Console.Write("\n--Maximum along columns\n");
            Util.Print(A, "A");
            Util.Print(Algorithm.Max(A), "Algorithm.Max(A)");

            Console.Write("\n--Minimum along columns with index\n");
            Util.Print(A, "A");

            ArrayFire.Array outArray, idx;
            outArray = Algorithm.Min(A, out idx);
            Util.Print(outArray, "output");
            Util.Print(idx, "indexes");
        }
    }
}
