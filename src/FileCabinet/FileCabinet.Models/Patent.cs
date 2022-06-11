using System;
using System.Text;

namespace FileCabinet.Models
{
    public class Patent : Document
    {
        public string[] Authors { get; set; }

        public DateTime ExpirationDate { get; set; }

        public Guid UniqueId { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Authors: ");
            for (int i = 1; i < Authors.Length; i++)
            {
                sb.AppendLine($"Author{i} - {Authors[i - 1]}");
            }
            sb.AppendLine($"ExpirationDate - {ExpirationDate}");
            sb.AppendLine($"UniqueId - {UniqueId}");
            return base.ToString() + sb;
        }
    }
}