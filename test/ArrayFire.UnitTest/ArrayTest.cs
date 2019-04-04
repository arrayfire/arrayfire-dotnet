using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ArrayFire.UnitTest
{
    /// <summary>
    /// port from test\array.cpp
    /// </summary>
    [TestClass]
    public class ArrayTest : UnitTestBase
    {
        [TestMethod]
        public void Creation()
        {
            var A = Data.Range<int>(2, 2);
            Util.Print(A, "A");
            Assert.IsTrue(Enumerable.SequenceEqual(new int[] { 0, 1, 0, 1 }, Data.GetData<int>(A)));
        }

        [TestMethod]
        public void Dot2x2()
        {
            var x = Data.CreateArray(new float[,]
            {
                { 1, 0 },
                { 0, 1 },
            });

            var y = Data.CreateArray(new float[,]
            {
                { 4, 1 },
                { 2, 2 },
            });

            var dot = Matrix.MatMul(x, y);
            Assert.IsTrue(Enumerable.SequenceEqual(new float[] { 4, 1, 2, 2 }, Data.GetData<float>(dot)));
        }
    }
}
