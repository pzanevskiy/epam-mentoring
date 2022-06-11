using System;
using FileCabinet.Service.Services;

namespace FileCabinet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new DocumentRepository();

            //var docs = new List<Book>
            //{
            //    TestData.Book,
            //};

            //repo.Write(docs);

            //var x = repo.Read();
            //foreach (var document in x)
            //{
            //    Console.WriteLine(document);
            //}

            var byId = repo.GetById(1);
            Console.WriteLine(byId.GetType());
            Console.WriteLine(byId);
        }
    }
}
