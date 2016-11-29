using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Generics
{
    public class MaheshCircularBuffer<T>
    {
        private T[] _buffer;
        int _start = 0;
        int _end = 0;

        public MaheshCircularBuffer()
            : this(capacity: 10)
        {
        }

        public MaheshCircularBuffer(int capacity)
        {
            _buffer = new T[capacity + 1];
        }

        public void Write(T value)
        {
            _buffer[_end] = value;
            _end = (_end + 1) % _buffer.Length;
            if (_end == _start)
            {
                _start = (_start + 1) % _buffer.Length;
            }
        }

        public T Read()
        {
            T result = _buffer[_start];
            _start = (_start + 1) % _buffer.Length;
            return result;
        }

        public int Capacity
        {
            get { return _buffer.Length; }
        }

        public bool IsEmpty
        {
            get { return _start == _end; }
        }

        public bool IsFull
        {
            get { return (_end + 1) % _buffer.Length == _start; }
        }
    }
}
