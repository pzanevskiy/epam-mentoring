using System;
using System.Collections.Generic;
using System.Text;
using FileCabinet.Models;

namespace FileCabinet.ConsoleApp
{
    public static class TestData
    {
        public static Patent Patent = new Patent
        {
            Id = 1,
            Title = "patent1",
            DatePublished = DateTime.Now,
            ExpirationDate = DateTime.Now + TimeSpan.FromDays(20),
            Authors = new[] {"author1", "author2"},
            UniqueId = Guid.NewGuid()
        };

        public static LocalizedBook LocalizedBook = new LocalizedBook
        {
            Id = 2,
            Title = "localizedBook1",
            DatePublished = DateTime.Now,
            Authors = new[] {"author1", "author2"},
            ISBN = "ISBN-2022-1234",
            OriginalPublisher = "originalpublisher1",
            CountryOfLocalization = "BY",
            LocalPublisher = "bypulisher1",
            NumberOfPages = 100
        };

        public static Book Book = new Book
        {
            Id = 3,
            Title = "book1",
            DatePublished = DateTime.Now,
            Authors = new[] {"author1", "author2"},
            ISBN = "ISBN-2022-5678",
            Publisher = "publisher1",
            NumberOfPages = 420
        };

        public static Magazine Magazine = new Magazine
        {
            Id = 4,
            Title = "magazine1",
            DatePublished = DateTime.Now,
            Publisher = "publisher3",
            ReleaseNumber = 123
        };
    }
}
