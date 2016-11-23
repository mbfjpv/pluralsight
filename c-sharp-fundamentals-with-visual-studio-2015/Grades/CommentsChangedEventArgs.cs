using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class CommentsChangedEventArgs : EventArgs
    {
        public string ExistingComments { get; set; }
        public string  NewComments { get; set; }
    }
}
