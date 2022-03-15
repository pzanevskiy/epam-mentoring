using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FileSystemVisitor.Console
{
    public interface ISpecification<T>
    {
        public Func<T, bool> Criteria { get; set; }
    }
}
