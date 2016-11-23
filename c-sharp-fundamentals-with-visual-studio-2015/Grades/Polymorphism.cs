using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class Polymorphism
    {
        public class Shape
        {
            public Shape()
            {
                Trace.WriteLine("Ctor Shape");
            }

            public virtual void Draw()
            {
                Trace.WriteLine("Shape.Draw");
            }
        }

        public class Box : Shape
        {
            public Box()
            {
                Trace.WriteLine("Ctor Box");
            }

            public override void Draw()
            {
                Trace.WriteLine("Box.Draw");
            }
        }
    }
}
