using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        public HybridFlowProcessor()
        {
            LinkedList = new DoublyLinkedList<T>();
        }

        public DoublyLinkedList<T> LinkedList { get; }

        public T Dequeue()
        {
            try
            {
                return LinkedList.RemoveAt(0);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new InvalidOperationException(e.Message, e);
            }
        }

        public void Enqueue(T item)
        {
            LinkedList.Add(item);
        }

        public T Pop()
        {
            try
            {
                return LinkedList.RemoveAt(0);

            }
            catch (IndexOutOfRangeException e)
            {
                throw new InvalidOperationException(e.Message, e);
            }
        }

        public void Push(T item)
        {
            LinkedList.AddAt(0, item);
        }
    }
}
