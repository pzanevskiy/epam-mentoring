using FileSystemVisitor.Lib.Arguments;
using FileSystemVisitor.Lib.Models;
using System;
using System.Collections.Generic;

namespace FileSystemVisitor.Lib.Interfaces
{
    public interface IFileSystemVisitor
    {
        public event EventHandler Start;

        public event EventHandler Finish;

        public event EventHandler<FileInfoEventArgs> FileFound;

        public event EventHandler<FileInfoEventArgs> DirectoryFound;

        public event EventHandler<FileInfoEventArgs> FilteredFileFound;

        public event EventHandler<FileInfoEventArgs> FilteredDirectoryFound;

        IEnumerable<FileSystemResult> GetFileSystemInfo(string rootDir, bool shouldRiseEvents);
    }
}
