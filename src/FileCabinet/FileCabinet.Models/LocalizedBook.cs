using System.Linq;
using System.Text;

namespace FileCabinet.Models
{
    public class LocalizedBook : Document
    {
        public string ISBN { get; set; }

        public string[] Authors { get; set; }

        public int NumberOfPages { get; set; }

        public string OriginalPublisher { get; set; }

        public string CountryOfLocalization { get; set; }

        public string LocalPublisher { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"ISBN - {ISBN}");
            sb.AppendLine("Authors: ");
            for (int i = 1; i < Authors.Length; i++)
            {
                sb.AppendLine($"Author{i} - {Authors[i - 1]}");
            }
            sb.AppendLine($"NumberOfPages - {NumberOfPages}");
            sb.AppendLine($"OriginalPublisher - {OriginalPublisher}");
            sb.AppendLine($"CountryOfLocalization - {CountryOfLocalization}");
            sb.AppendLine($"LocalPublisher - {LocalPublisher}");
            return base.ToString() + sb;
        }
    }
}