namespace Fundamentals.Console
{
    internal class Program
    {
        private static void Main()
        {
            System.Console.Write("Input: ");
            var userName = System.Console.ReadLine();
            System.Console.WriteLine("Hello, {0}!", userName);
        }
    }
}
