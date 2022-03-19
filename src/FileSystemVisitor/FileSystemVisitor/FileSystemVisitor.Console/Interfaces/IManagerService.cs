using System;

namespace FileSystemVisitor.Console.Interfaces
{
    public interface IManagerService<T> where T : EventArgs
    {
        event EventHandler<T> Start;

        event EventHandler<T> Stop;

        void StartExecution();

        void StopExecution();
    }
}
