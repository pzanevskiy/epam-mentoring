using System.Collections.Generic;

namespace FileCabinet.Service.Interfaces
{
    public interface IDocumentStorage<T>
    {
        void AddDocument(T document);

        void AddDocuments(IEnumerable<T> documents);

        IEnumerable<T> GetDocuments();

        T GetDocumentById(int id);
    }
}
