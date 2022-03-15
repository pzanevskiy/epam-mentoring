using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSystemVisitor.Console
{
    public class FileSystemVisitorService
    {
        private readonly Func<FileSystemInfo, bool> _filter;

        public FileSystemVisitorService(Func<FileSystemInfo, bool> filter = null)
        {
            _filter = filter;
        }

        public event EventHandler Start;

        public event EventHandler Finish;

        public event EventHandler FileFound;

        public event EventHandler DirectoryFound;

        public event EventHandler FilteredFileFound;

        public event EventHandler FilteredDirectoryFound;

        public IEnumerable<FileSystemInfo> GetFileSystemInfo(string dirPath)
        {
            Start?.Invoke(this, EventArgs.Empty);

            var root = new DirectoryInfo(dirPath);

            foreach (var file in root.EnumerateFiles("*", SearchOption.AllDirectories))
            {
                if (_filter != null && _filter(file))
                {
                    FilteredFileFound?.Invoke(this, EventArgs.Empty);
                    yield return file;
                }

                if (_filter is null)
                {
                    FileFound?.Invoke(this, EventArgs.Empty);
                    yield return file;
                }

            }

            foreach (var dir in root.EnumerateDirectories("*", SearchOption.AllDirectories))
            {
                if (_filter != null && _filter(dir))
                {
                    FilteredDirectoryFound?.Invoke(this, EventArgs.Empty);
                    yield return dir;
                }

                if (_filter is null)
                {
                    DirectoryFound?.Invoke(this, EventArgs.Empty);
                    yield return dir;
                }
            }

            Finish?.Invoke(this, EventArgs.Empty);
        }
    }
}
