using System.Collections.Generic;
using System.Linq;

namespace FileSystemVisitor.Console
{
    public static class SpecificationEvaluator<T> where T : class
    {
        public static IEnumerable<T> GetQuery(IEnumerable<T> inputQuery, ISpecification<T> spec)
        {
            var query = inputQuery;

            if (spec?.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            return query;
        }
    }
}
