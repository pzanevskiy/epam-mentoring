using System;

namespace Fundamentals.Library
{
    public static class HelloHelper
    {
        public static string GetHello(string username) =>
            $"{DateTime.UtcNow} - Hello, {username}!";
    }
}
