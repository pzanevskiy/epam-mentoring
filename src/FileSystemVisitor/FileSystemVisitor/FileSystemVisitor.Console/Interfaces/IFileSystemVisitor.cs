using FileSystemVisitor.Console.Arguments;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSystemVisitor.Console.Interfaces
{
    public interface IFileSystemVisitor
    {
        public event EventHandler Start;

        public event EventHandler Finish;

        public event EventHandler<FileInfoEventArgs> FileFound;

        public event EventHandler<FileInfoEventArgs> DirectoryFound;

        public event EventHandler<FileInfoEventArgs> FilteredFileFound;

        public event EventHandler<FileInfoEventArgs> FilteredDirectoryFound;

        IEnumerable<FileSystemInfo> GetFileSystemInfo(string rootDir, bool shouldRiseEvents);
    }
}
