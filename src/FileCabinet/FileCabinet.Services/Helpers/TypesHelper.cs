using System;
using System.Collections.Generic;
using System.Linq;

namespace FileCabinet.Service.Helpers
{
    public static class TypesHelper
    {
        public static IEnumerable<Type> GetTypes<T>()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes()).Where(t => t.BaseType == typeof(T));
        }
    }
}
