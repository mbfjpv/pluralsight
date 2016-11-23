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

        private NameChangedDelegate NameChanged;

        public GradesBook()
        {
            NameChanged += new NameChangedDelegate(OnNameChanged);
            NameChanged += new NameChangedDelegate(OnNameChanged2);
            //NameChanged = null;
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

    }
}
