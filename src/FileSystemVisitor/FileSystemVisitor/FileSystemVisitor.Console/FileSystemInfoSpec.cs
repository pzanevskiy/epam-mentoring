using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace FileSystemVisitor.Console
{
    public class FileSystemInfoSpec : ISpecification<FileSystemInfo>
    {
        public Func<FileSystemInfo, bool> Criteria { get; set; }
    }
}
