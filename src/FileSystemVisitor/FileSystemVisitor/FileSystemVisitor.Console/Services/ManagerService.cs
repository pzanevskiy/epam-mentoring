using FileSystemVisitor.Console.Arguments;
using FileSystemVisitor.Console.Interfaces;
using System;

namespace FileSystemVisitor.Console.Services
{
    public class ManagerService : IManagerService<ManagerEventArgs>
    {
        private readonly bool _shouldRiseEvents;
        private readonly string _directoryPath;

        public ManagerService(bool shouldRiseEvents, string directoryPath)
        {
            _shouldRiseEvents = shouldRiseEvents;
            _directoryPath = directoryPath;
        }

        public event EventHandler<ManagerEventArgs> Start;

        public event EventHandler<ManagerEventArgs> Stop;

        public void StartExecution()
        {
            var args = new ManagerEventArgs(false, _directoryPath, _shouldRiseEvents);
            Start?.Invoke(this, args);
        }

        public void StopExecution()
        {
            var args = new ManagerEventArgs(true);
            Stop?.Invoke(this, args);
        }
    }
}
