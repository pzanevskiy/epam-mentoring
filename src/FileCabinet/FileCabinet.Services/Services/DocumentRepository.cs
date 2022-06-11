using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FileCabinet.Models;
using FileCabinet.Service.Interfaces;

namespace FileCabinet.Service.Services
{
    public class DocumentRepository : IRepository<Document>
    {
        public void Write(IEnumerable<Document> documents)
        {
            foreach (var document in documents)
            {
                var json = JsonSerializer.Serialize(document, document.GetType());
                var path = $"{document.GetType().Name}_#{{{document.Id}}}.json";
                File.WriteAllText(path, json);
            }
        }

        public IEnumerable<Document> Read()
        {
            var docTypes = GetDocumentTypes().ToList();
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            var files = directory
                .GetFiles("*.json")
                .Where(file => docTypes.Any(type => file.Name.Contains(type.Name, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            var documents = new List<Document>();
            foreach (var file in files)
            {
                var jsonString = File.ReadAllText(file.FullName);
                var type = docTypes.First(t => file.Name.Split('_')[0].Equals(t.Name, StringComparison.OrdinalIgnoreCase));
                var document = JsonSerializer.Deserialize(jsonString, type);
                documents.Add((Document)document);
            }
            return documents;
        }

        public Document GetById(int id)
        {
            return Read().Single(x => x.Id == id);
        }

        private static IEnumerable<Type> GetDocumentTypes()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes()).Where(t => t.BaseType == typeof(Document));
        }

    }
}