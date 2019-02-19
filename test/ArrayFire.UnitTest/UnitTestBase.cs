using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayFire.UnitTest
{
    public class UnitTestBase
    {
        public UnitTestBase()
        {
            Device.SetBackend(Backend.DEFAULT);
            Device.PrintInfo();
        }
    }
}
