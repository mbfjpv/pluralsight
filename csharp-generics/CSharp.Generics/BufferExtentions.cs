using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Generics
{
    public static class BufferExtentions
    {
        public delegate void Printer<T>(T data);

        public static IEnumerable<TOutput> AsIEnumerableOfxtention<T, TOutput>(this IBuffer<T> buffer)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            foreach (var item in buffer)
            {
                var result = converter.ConvertTo(item, typeof(TOutput));
                yield return (TOutput)result;
            }
        }

        public static IEnumerable<TOutput> AsIEnumerableOfxtention<T, TOutput, T2>
                        (this IBuffer<T> buffer, T2 value)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            foreach (var item in buffer)
            {
                var result = converter.ConvertTo(item, typeof(TOutput));
                yield return (TOutput)result;
            }
        }

        public static void PrintBuffer<T>(this IBuffer<T> buffer)
        {
            foreach(var item in buffer)
            {
                Trace.WriteLine(item);
            }
        }

        public static void PrintBufferDeligate<T>(this IBuffer<T> buffer, Printer<T> print)
        {
            foreach (var item in buffer)
            {
                print(item);
            }
        }

        public static void PrintBufferAction<T>(this IBuffer<T> buffer, Action<T> print)
        {
            foreach (var item in buffer)
            {
                print(item);
            }
        }
    }
}
