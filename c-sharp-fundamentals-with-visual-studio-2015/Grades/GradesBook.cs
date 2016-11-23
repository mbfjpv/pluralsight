using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradesBook
    {
        private string _name = string.Empty;
        private string _comments = string.Empty;

        private NameChangedDelegate NameChanged;

        public event CommentsChangedDelegate CommentsChanged;

        public GradesBook()
        {
            NameChanged += new NameChangedDelegate(OnNameChanged);
            NameChanged += new NameChangedDelegate(OnNameChanged2);
            NameChanged += new NameChangedDelegate(OnNameChanged2);
            NameChanged -= new NameChangedDelegate(OnNameChanged2);
            //NameChanged = null;

            CommentsChanged += GradesBook_CommentsChanged;
            //CommentsChanged = null;
        }

        public void TestMethod()
        {
            CommentsChanged = null;
        }

        private void GradesBook_CommentsChanged(object sender, CommentsChangedEventArgs eventArgs)
        {
            Console.WriteLine("GradesBook_CommentsChanged");
        }

        public void OnNameChanged(string existingName, string newName)
        {
            Console.WriteLine($"Name Changed from {existingName} to {newName}.");
        }
        public void OnNameChanged2(string existingName, string newName)
        {
            Console.WriteLine("**");
        }

        public string Name {
            get
            {
                return _name;
            }
            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    if(!_name.Equals(value))
                    {
                        NameChanged(_name, value);
                    }
                    _name = value;
                }
            }
        }

        public string Comments {
            get
            {
                return _comments;
            }
            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    if(!_comments.Equals(value))
                    {
                        CommentsChangedEventArgs eventArgs = new CommentsChangedEventArgs()
                        { ExistingComments = _comments, NewComments = value };

                        CommentsChanged(this, eventArgs);
                    }
                    _comments = value;
                }
            }
        }

    }
}
