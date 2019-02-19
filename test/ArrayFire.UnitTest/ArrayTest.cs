using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        }
    }
}
