using System.Collections.Generic;

namespace Ado.Net.Lib.Repos
{
    public interface IRepository<T>
    {
        void Create(T entity);

        T Read(int id);

        void Update(T entity, int id);

        void Delete(int id);

        IEnumerable<T> GetAll();
    }
}
