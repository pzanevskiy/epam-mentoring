using System;

namespace FileSystemVisitor.Lib.Arguments
{
    public class FileInfoEventArgs : EventArgs
    {
        public string FileInfoName { get; }

        public FileInfoEventArgs(string fileInfoName)
        {
            FileInfoName = fileInfoName;
        }
    }
}
