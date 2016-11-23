using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using static Grades.Polymorphism;
using static Grades.Abstract;

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

        [TestMethod]
        public void TestComment()
        {
            GradesBook gb = new GradesBook();
            gb.Comments = "ABC";
            Assert.AreEqual(gb.Comments, "ABC");
        }

        [TestMethod]
        public void TestCommentsEvent()
        {
            GradesBook gb = new GradesBook();
            gb.CommentsChanged += Gb_CommentsChanged;
            //gb.CommentsChanged = null;
            gb.Comments = "ABC";
            Assert.AreEqual(gb.Comments, "ABC");
        }

        private void Gb_CommentsChanged(object sender, CommentsChangedEventArgs eventArgs)
        {
            Trace.WriteLine("Gb_CommentsChanged");
        }

        [TestMethod]
        public void TestPolymorphism()
        {
            Shape shape = new Box();
            shape.Draw();
        }

        [TestMethod]
        public void Test01()
        {
            int num = 20;
            string result = num > 20 ? "yes" : "no";
            Assert.AreEqual("no", result);
        }

        [TestMethod]
        public void AbstractTest()
        {
            Window win = new Frame("New");
            
        }
    }
}
