using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp.Generics;
using System.Diagnostics;

namespace CSharp.Generics.Tests
{
    [TestClass]
    public class CircularBufferTests
    {
        [TestMethod]
        public void New_Buffer_Is_Empty()
        {
            var buffer = new CircularBuffer<double>();
            Assert.IsTrue(buffer.IsEmpty);
        }

        [TestMethod]
        public void Three_Element_Buffer_Is_Full_After_Three_Writes()
        {
            var buffer = new CircularBuffer<double>(capacity: 3);
            buffer.Write(1);
            buffer.Write(1);
            buffer.Write(1);
            Assert.IsTrue(buffer.IsFull);
        }

        [TestMethod]
        public void First_In_First_Out_When_Not_Full()
        {
            var buffer = new CircularBuffer<string>(capacity: 3);
            var value1 = "1.1";
            var value2 = "2.0";

            buffer.Write(value1);
            buffer.Write(value2);

            Assert.AreEqual(value1, buffer.Read());
            Assert.AreEqual(value2, buffer.Read());
            Assert.IsTrue(buffer.IsEmpty);
        }

        [TestMethod]
        public void Overwrites_When_More_Than_Capacity()
        {
            var buffer = new CircularBuffer<double>(capacity: 3);
            var values = new[] { 1.0, 2.0, 3.0, 4.0, 5.0 };

            foreach (var value in values)
            {
                buffer.Write(value);
            }

            Assert.IsTrue(buffer.IsFull);
            Assert.AreEqual(values[2], buffer.Read());
            Assert.AreEqual(values[3], buffer.Read());
            Assert.AreEqual(values[4], buffer.Read());
            Assert.IsTrue(buffer.IsEmpty);
        }

        [TestMethod]
        public void ForEach_Through_All_Items()
        {
            var buffer = new CircularBuffer<double>(capacity: 3);
            var values = new[] { 1.0, 2.0, 3.0 };
            var count = 0;

            foreach (var value in values)
            {
                buffer.Write(value);
            }

            foreach(var item in buffer)
            {
                Assert.AreEqual(values[count], item);
                count++;
            }
        }

        [TestMethod]
        public void Return_A_Specified_Type_Of_IEnumerable()
        {
            var buffer = new CircularBuffer<double>(capacity: 3);
            var values = new[] { 1.2, 2.4, 3.6 };

            foreach (var value in values)
            {
                buffer.Write(value);
                Trace.WriteLine(value);
            }

            var asInts = buffer.AsIEnumerableOf<int>();
            foreach(var item in asInts)
            {
                Trace.WriteLine(item);
            }
        }
    }
}
