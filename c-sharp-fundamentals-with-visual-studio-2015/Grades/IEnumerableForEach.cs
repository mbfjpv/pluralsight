using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class IEnumerableForEach : IEnumerable
    {
        private MyList mList = new MyList(10);

        public IEnumerator GetEnumerator()
        {
            return mList;
        }
    }

    public class MyList : IEnumerator
    {
        int[] intArray = null;
        int position = -1;

        public MyList(int listSize)
        {
            intArray = new int[listSize];
            for (int x = 0; x < listSize; x++)
            {
                intArray[x] = new Random().Next();
            }
        }

        public object Current
        {
            get
            {
                try
                {
                    return intArray[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < intArray.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
