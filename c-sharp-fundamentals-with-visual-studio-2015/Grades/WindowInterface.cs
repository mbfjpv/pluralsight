using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class Window : IWindow
    {
        private string _title = string.Empty;

        public Window()
        {
            Trace.WriteLine("Window Ctor");
        }

        public virtual string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        public virtual void Draw()
        {
            Trace.WriteLine("Window.Draw");
        }

        public abstract void Open();

    }

    public class Frame : Window
    {
        private string _title = string.Empty;

        public Frame(string title)
        {
            Trace.WriteLine("Frame Ctor");
            Title = title;
        }

        public override string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = "Title : " + value;
            }
        }

        public override void Open()
        {
            Trace.WriteLine("Frame.Open");
        }

        public void Animate()
        {
            Trace.WriteLine("Frame.Animate");
        }
    }

    public interface IWindow
    {
        string  Title { get; set; }
        void Draw();
        void Open();
    }


}
