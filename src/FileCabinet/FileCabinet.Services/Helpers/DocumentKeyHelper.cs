using FileCabinet.Models;

namespace FileCabinet.Service.Helpers
{
    public static class DocumentKeyHelper
    {
        public static string GenerateKey(Document document)
        {
            return $"{document.GetType().Name}_#{{{document.Id}}}";
        }
    }
}
