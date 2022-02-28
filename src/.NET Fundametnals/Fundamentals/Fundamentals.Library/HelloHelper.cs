using System;

namespace Fundamentals.Library
{
    public static class HelloHelper
    {
        public static string GetHello(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName), "Empty username.");
            }

            return $"{DateTime.UtcNow} - Hello, {userName}!";
        }
    }
}
