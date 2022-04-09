using Reflection.Attributes.Components;
using System;

namespace Reflection.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfgManager = new ConfigurationManagerSettings();

            var name = cfgManager.Name;
            Console.WriteLine(name);
            cfgManager.Name = "new cf";
            Console.WriteLine(cfgManager.Name);
            cfgManager.Count = 21;
            Console.WriteLine(cfgManager.Count);
            //var x = new FileProvider();
            //var val = x.Read("Duration");
            //Console.WriteLine(x.Read("Count"));
            //x.Write("Count", 10);
            //Console.WriteLine($"{val}");
            //Console.WriteLine($"{x.Read("Count")}");
        }

    }
}
