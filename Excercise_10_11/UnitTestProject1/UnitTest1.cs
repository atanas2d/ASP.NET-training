using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JSONSerialization.Tests
{
    [TestClass]
    public class GameInfoTest
    {
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void TestMethod1()
        {
            Assert.AreEqual(1,1);
            throw new ArgumentException("kremvirsh");
        }
    }
}
