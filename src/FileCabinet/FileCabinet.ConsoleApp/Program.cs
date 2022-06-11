using System;
using System.Collections.Generic;
using System.Threading;
using FileCabinet.Models;
using FileCabinet.Service.Services;
using Microsoft.Extensions.Caching.Memory;

namespace FileCabinet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var entryOptionsMap = new Dictionary<Type, MemoryCacheEntryOptions>
            {
                {typeof(Book), new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(10))},
                {typeof(LocalizedBook), new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(60))},
                {typeof(Patent), new MemoryCacheEntryOptions()}
            };

            var cache = new MemoryCache(new MemoryCacheOptions());
            var cacheStorage = new CacheStorage<Document>(cache, entryOptionsMap);

            var documentRepository = new DocumentRepository();
            var documentStorage = new DocumentStorage(documentRepository, cacheStorage); 

            documentStorage.AddDocuments(new List<Document>
            {
                TestData.LocalizedBook,
                TestData.Book,
                TestData.Magazine,
                TestData.Patent,
            });

            var documents = documentStorage.GetDocuments();
            foreach (var document in documents)
            {
                Console.WriteLine(document);
            }

            Thread.Sleep(10000);
            var documentById = documentStorage.GetDocumentById(3);
            Console.WriteLine(documentById);
        }
    }
}
