using System;

namespace FileSystemVisitor.Console.Arguments
{
    public class FileInfoEventArgs : EventArgs
    {
        public string FileInfoName { get; set; }

        public FileInfoEventArgs(string fileInfoName)
        {
            FileInfoName = fileInfoName;
        }
    }
}
