using System;

namespace FileSystemVisitor.Lib.Arguments
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
