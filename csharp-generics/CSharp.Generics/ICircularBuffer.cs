using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Generics
{
    public interface ICircularBuffer<T>
    {
        bool IsEmpty { get; }
        bool IsFull { get; }
        void Write(T value);
        T Read();
    }
}
