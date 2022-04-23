using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        public DoublyLinkedList()
        {
            Head = null;
            Last = null;
            Length = 0;
        }

        public Node<T> Head { get; private set; }

        public Node<T> Last { get; private set; }

        public int Length { get; private set; }

        public void Add(T e)
        {
            var node = new Node<T>(e);

            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Last.Next = node;
                node.Previous = Last;
            }

            Last = node;
            Length++;
        }

        public void AddAt(int index, T e)
        {
            var foundedNode = FindByIndex(index);
            if (foundedNode == null)
            {
                Add(e);
            }
            else
            {
                var node = new Node<T>(e);

                if (foundedNode == Head)
                {
                    foundedNode.Previous = node;
                    node.Next = foundedNode;
                    Head = node;
                }
                else
                {
                    node.Next = foundedNode;
                    node.Previous = foundedNode.Previous;
                    foundedNode.Previous.Next = node;
                    foundedNode.Previous = node;
                }

                Length++;
            }
        }

        public T ElementAt(int index)
        {
            var foundedNode = FindByIndex(index);
            return foundedNode != null ? foundedNode.Value : throw new IndexOutOfRangeException();
        }


        public void Remove(T item)
        {
            var nodeIndex = FindIndexByNodeValue(item);

            if (nodeIndex >= 0)
            {
                RemoveAt(nodeIndex);
            }
        }

        public T RemoveAt(int index)
        {
            var foundedNode = FindByIndex(index);

            if (foundedNode == null)
            {
                throw new IndexOutOfRangeException();
            }

            if (foundedNode == Head)
            {
                Head = foundedNode.Next;
            }

            if (foundedNode == Last)
            {
                Last = foundedNode.Previous;
            }

            if (foundedNode.Next != null)
            {
                foundedNode.Next.Previous = foundedNode.Previous;
            }

            if (foundedNode.Previous != null)
            {
                foundedNode.Previous.Next = foundedNode.Next;
            }

            Length--;
            return foundedNode.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoubleLinkedListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Node<T> FindByIndex(int index)
        {
            var counter = 0;
            var node = Head;

            while (node != null)
            {
                if (counter == index)
                {
                    return node;
                }

                node = node.Next;
                counter++;
            }

            return null;
        }

        private int FindIndexByNodeValue(T value)
        {
            var counter = 0;
            var node = Head;

            while (node != null)
            {
                if (node.Value.Equals(value))
                {
                    return counter;
                }

                node = node.Next;
                counter++;
            }

            return -1;
        }

        public class DoubleLinkedListEnumerator : IEnumerator<T>
        {
            private readonly DoublyLinkedList<T> _dll;

            public T Current => CurrentNode.Value;

            public Node<T> CurrentNode { get; private set; }

            public DoubleLinkedListEnumerator(DoublyLinkedList<T> dll)
            {
                _dll = dll;
                CurrentNode = null;
            }

            public bool MoveNext()
            {
                CurrentNode = CurrentNode == null ? _dll.Head : CurrentNode.Next;
                return CurrentNode != null;
            }

            public void Reset()
            {
                CurrentNode = null;
            }

            object? IEnumerator.Current => Current;

            public void Dispose() { }
        }
    }
}
