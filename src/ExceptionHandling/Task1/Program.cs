using System;
using System.Threading;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Write("Please input some string: ");
                    var inputString = Console.ReadLine();
                    Console.WriteLine("First character of the input string is '{0}'", inputString[0]);
                    Thread.Sleep(TimeSpan.FromSeconds(3));
                    Console.Clear();
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Input string cannot be empty.");
                    throw;
                }
            }
        }
    }
}