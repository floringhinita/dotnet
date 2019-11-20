using System;
using System.Collections.Generic;
using System.Text;

namespace app4
{
    class ReversableLinkedList<T> : LinkedList<T>
    {
        public ReversableLinkedList<T> Reverse()
        {
            ReversableLinkedList<T> rev = new ReversableLinkedList<T>();

            LinkedListNode<T> current = this.Last;

            while(current != null)
            {
                rev.AddLast(current.Value);
                current = current.Previous;
            }

            return rev;
        }

        public ReversableLinkedList<T> ReverseRecursive(LinkedListNode<T> current)
        {
            if (current != null && current.Next != null)
            {
                this.ReverseRecursive(current.Next);
            }

            current = current.Previous;

            return this;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            var first = this.First;
            
            while(first != null)
            {
                s.Append(first.Value);
                first = first.Next;
            }

            return s.ToString();
        }
    }
}
