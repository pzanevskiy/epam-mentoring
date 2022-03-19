using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystemVisitor.Console.Interfaces
{
    public interface IEventSubscriber<T> where T : class
    {
        void Subscribe(T publisher);

        void Unubscribe(T publisher);
    }
}
