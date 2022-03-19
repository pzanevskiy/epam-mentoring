using FileSystemVisitor.Lib.Interfaces;
using FileSystemVisitor.Lib.Arguments;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FileSystemVisitor.Lib.Models;

namespace FileSystemVisitor.Lib.Services
{
    public class FileSystemVisitorService : IFileSystemVisitor,
        IEventSubscriber<IManagerService<ManagerEventArgs>>
    {
        private bool _shouldStop;
        private readonly Func<FileSystemInfo, bool> _filter;

        public FileSystemVisitorService(Func<FileSystemInfo, bool> filter = null)
        {
            _filter = filter;
        }

        public event EventHandler Start;

        public event EventHandler Finish;

        public event EventHandler<FileInfoEventArgs> FileFound;

        public event EventHandler<FileInfoEventArgs> DirectoryFound;

        public event EventHandler<FileInfoEventArgs> FilteredFileFound;

        public event EventHandler<FileInfoEventArgs> FilteredDirectoryFound;

        public IEnumerable<FileSystemResult> GetFileSystemInfo(string rootDir, bool shouldRiseEvents)
        {
            if (string.IsNullOrEmpty(rootDir))
            {
                throw new ArgumentNullException(nameof(rootDir));
            }

            if (shouldRiseEvents)
            {
                Start?.Invoke(this, new EventArgs());
            }

            var root = new DirectoryInfo(rootDir);

            if (!root.Exists)
            {
                throw new DirectoryNotFoundException();
            }

            foreach (var file in root.EnumerateFiles("*", SearchOption.AllDirectories))
            {
                if (_filter != null && _filter(file))
                {
                    if (shouldRiseEvents)
                    {
                        FilteredFileFound?.Invoke(this, new FileInfoEventArgs(file.Name));
                    }

                    yield return new FileSystemResult()
                    {
                        Name = file.Name,
                        CreationTime = file.CreationTime
                    };
                }

                if (_filter is null)
                {
                    if (shouldRiseEvents)
                    {
                        FileFound?.Invoke(this, new FileInfoEventArgs(file.Name));
                    }

                    yield return new FileSystemResult()
                    {
                        Name = file.Name,
                        CreationTime = file.CreationTime
                    };
                }

            }

            foreach (var dir in root.EnumerateDirectories("*", SearchOption.AllDirectories))
            {
                if (_filter != null && _filter(dir))
                {
                    if (shouldRiseEvents)
                    {
                        FilteredDirectoryFound?.Invoke(this, new FileInfoEventArgs(dir.Name));
                    }

                    yield return new FileSystemResult()
                    {
                        Name = dir.Name,
                        CreationTime = dir.CreationTime
                    };
                }

                if (_filter is null)
                {
                    if (shouldRiseEvents)
                    {
                        DirectoryFound?.Invoke(this, new FileInfoEventArgs(dir.Name));
                    }

                    yield return new FileSystemResult()
                    {
                        Name = dir.Name,
                        CreationTime = dir.CreationTime
                    };
                }
            }

            if (shouldRiseEvents)
            {
                Finish?.Invoke(this, new EventArgs());
            }
        }

        public void Subscribe(IManagerService<ManagerEventArgs> publisher)
        {
            publisher.Start += Publisher_Start;
            publisher.Stop += Publisher_Stop;
        }

        public void Unubscribe(IManagerService<ManagerEventArgs> publisher)
        {
            publisher.Start -= Publisher_Start;
            publisher.Stop -= Publisher_Stop;
        }

        private void Publisher_Start(object sender, ManagerEventArgs e)
        {
            _shouldStop = e.ShouldStop;
            GetFileSystemInfo(e.DirectoryPath, e.ShouldStop);
        }

        private void Publisher_Stop(object sender, ManagerEventArgs e)
        {
            _shouldStop = e.ShouldStop;
        }
    }
}
