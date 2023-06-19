using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsHW
{
    public class Stack<T>
    {
        private Item? head;

        public int Count { get; private set; }

        public Stack()
        {
            Count = 0;
        }

        public void Push(T Element)
        {
            var newItem = new Item(Element);
            newItem.Next = head;
            head = newItem;
            Count++;
        }
        
        public T Pop()
        {
            if(head is null)
                throw new StackOverflowException("Stack is empty. Stack undreflow!");

            T result = head.Value;

            head = head.Next;
            Count--;
            return result;
        }

        public T Peek()
        {
            if (head is null)
                throw new StackOverflowException("Stack is empty!");

            return head.Value;
        }

        public void Clear()
        {
            head = null;
        }

        public void CopyTo(out T[] arr)
        {
            arr = new T[Count];

            var currentItem = head;
            int i = 0;

            while(currentItem != null)
            {
                arr[i++] = currentItem.Value;
                currentItem = currentItem.Next;
            }
        }

        private class Item
        {
            public T Value { get; set; }
            public Item? Next { get; set; }

            public Item(T value)
            {
                Value = value;
            }
        }
    }
}
