using System.Collections.Generic;

namespace FileCabinet.Service.Interfaces
{
    public interface IRepository<T>
    {
        void Write(T document);

        void WriteRange(IEnumerable<T> documents);

        IEnumerable<T> Read();

        T GetById(int id);
    }
}