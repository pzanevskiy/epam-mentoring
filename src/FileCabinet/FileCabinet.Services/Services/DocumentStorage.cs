using System.Collections.Generic;
using System.Linq;
using FileCabinet.Models;
using FileCabinet.Service.Interfaces;

namespace FileCabinet.Service.Services
{
    public class DocumentStorage: IDocumentStorage<Document>
    {
        private readonly IRepository<Document> _documentRepository;
        private readonly ICacheStorage<Document> _cacheStorage;

        public DocumentStorage(
            IRepository<Document> documentRepository,
            ICacheStorage<Document> cacheStorage)
        {
            _documentRepository = documentRepository;
            _cacheStorage = cacheStorage;
        }

        public void AddDocument(Document document)
        {
            _documentRepository.Write(document);
        }

        public void AddDocuments(IEnumerable<Document> documents)
        {
            _documentRepository.WriteRange(documents);
        }

        public IEnumerable<Document> GetDocuments()
        {
            var documents = _documentRepository.Read().ToList();

            foreach (var document in documents)
            {
                _cacheStorage.AddItem(document.Id, document);
            }

            return documents;
        }

        public Document GetDocumentById(int id)
        {
            var document = _cacheStorage.GetItem(id);
            if (document == null)
            {
                document = _documentRepository.GetById(id);
                _cacheStorage.AddItem(document.Id, document);
            }

            return document;
        }
    }
}
