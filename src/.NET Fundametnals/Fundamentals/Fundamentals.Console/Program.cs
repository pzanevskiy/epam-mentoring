using System;
using Fundamentals.Library;

namespace Fundamentals.Console
{
    internal class Program
    {
        private static void Main()
        {
            System.Console.Write("Input: ");
            try
            {
                var userName = System.Console.ReadLine();
                System.Console.WriteLine(HelloHelper.GetHello(userName));
            }
            catch (ArgumentNullException exception)
            {
                System.Console.WriteLine($"An error occurred with the following message: {exception.Message}");
            }
            catch (Exception exception)
            {
                System.Console.WriteLine($"An unhandled error occurred with the following message: {exception.Message}.");
            }
        }
    }
}
