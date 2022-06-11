using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FileCabinet.Models;
using FileCabinet.Service.Helpers;
using FileCabinet.Service.Interfaces;

namespace FileCabinet.Service.Services
{
    public class DocumentRepository : IRepository<Document>
    {
        public void WriteRange(IEnumerable<Document> documents)
        {
            foreach (var document in documents)
            {
                Write(document);
            }
        }

        public IEnumerable<Document> Read()
        {
            var docTypes = TypesHelper.GetTypes<Document>().ToList();
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            var files = directory
                .GetFiles("*.json")
                .Where(file => docTypes.Any(type => file.Name.Contains(type.Name, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            var documents = new List<Document>();
            foreach (var file in files)
            {
                var jsonString = File.ReadAllText(file.FullName);
                var type = docTypes.First(t =>
                    file.Name.Split('_')[0].Equals(t.Name, StringComparison.OrdinalIgnoreCase));

                var document = JsonSerializer.Deserialize(jsonString, type);
                documents.Add((Document)document);
            }
            return documents;
        }

        public Document GetById(int id)
        {
            return Read().Single(x => x.Id == id);
        }

        public void Write(Document document)
        {
            var json = JsonSerializer.Serialize(document, document.GetType());
            var key = DocumentKeyHelper.GenerateKey(document);
            var path = $"{key}.json";
            File.WriteAllText(path, json);
        }
    }
}