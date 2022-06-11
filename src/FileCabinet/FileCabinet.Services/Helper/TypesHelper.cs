using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileCabinet.Models;

namespace FileCabinet.Service.Helper
{
    public static class TypesHelper
    {
        public static IEnumerable<Type> GetTypes<T>(T type)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes()).Where(t => t.BaseType == typeof(T));
        }
    }
}
