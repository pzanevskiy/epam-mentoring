using Reflection.Attributes.Components;
using System;

namespace Reflection.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new FileSettings();

            ShowInformation(settings);
            settings.Name = "my val";          
            settings.Rate = (float)100.50;
            settings.Count = 10;
            settings.Duration = TimeSpan.FromSeconds(900);
            ShowInformation(settings);
        }

        static void ShowInformation(ConfigurationComponentBase settings)
        {
            Console.WriteLine("Name: {0}", settings.Name);
            Console.WriteLine("Duration: {0}", settings.Duration);
            Console.WriteLine("Rate: {0}", settings.Rate);
            Console.WriteLine("Count: {0}", settings.Count);
        }
    }
}
