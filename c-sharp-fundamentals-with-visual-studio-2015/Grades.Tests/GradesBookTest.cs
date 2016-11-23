using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grades.Tests
{
    [TestClass]
    public class GradesBookTest
    {
        [TestMethod]
        public void TestName()
        {
            GradesBook gb = new GradesBook();
            gb.Name = "XYZ";
            gb.Name = "ABC";
            Assert.AreEqual(gb.Name, "ABC");
        }
    }
}
