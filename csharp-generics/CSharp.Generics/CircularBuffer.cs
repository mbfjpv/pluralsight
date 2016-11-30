using System;
using System.Collections;

namespace CSharp.Generics
{
    public class CircularBuffer<T> : Buffer<T>
    {
        int _capacity = 0;
        public CircularBuffer(int capacity = 10)
        {
            _capacity = capacity;
        }

        public override void Write(T value)
        {
            base.Write(value);
            if(_queue.Count > _capacity)
            {
                var discard = _queue.Dequeue();
                OnItemDiscarded(discard, value);
            }
        }

        private void OnItemDiscarded(T discard, T value)
        {
            if(ItemDiscarded != null)
            {
                var args = new ItemDiscardedEventArgs<T>(discard, value);
                ItemDiscarded(this, args);
            } 
        }

        public bool IsFull
        {
            get
            {
                return _queue.Count == _capacity;
            }
        }

        public event EventHandler<ItemDiscardedEventArgs<T>> ItemDiscarded;

        public class ItemDiscardedEventArgs<T> : EventArgs
        {
            public ItemDiscardedEventArgs(T discard, T newItem)
            {
                ItemDiscarded = discard;
                NewItem = newItem;
            }

            public T ItemDiscarded { get; set; }
            public T NewItem { get; set; }
        }
    }
}
