﻿using FileSystemVisitor.Lib.Services;
using System;
using System.IO;

namespace FileSystemVisitor.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");
            var service = new FileSystemVisitorService();
            //(x) => x.FullName.Contains(""))
            service.Start += (x, y) =>
            {
                System.Console.ForegroundColor = ConsoleColor.DarkYellow;
                System.Console.WriteLine("Start seraching");
                System.Console.ForegroundColor = ConsoleColor.White;
            };

            service.Finish += (x, y) =>
            {
                System.Console.ForegroundColor = ConsoleColor.DarkYellow;
                System.Console.WriteLine("Finish seraching");
                System.Console.ForegroundColor = ConsoleColor.White;
            };

            service.FilteredFileFound += (x, y) =>
            {
                System.Console.ForegroundColor = ConsoleColor.Blue;
                System.Console.WriteLine("Filtered file found");
                System.Console.ForegroundColor = ConsoleColor.White;
            };

            service.FileFound += (x, y) =>
            {
                System.Console.ForegroundColor = ConsoleColor.DarkGreen;
                System.Console.WriteLine("File found");
                System.Console.ForegroundColor = ConsoleColor.White;
            };
            var x = service.GetFileSystemInfo(@"C://Reports", false);
            foreach (var item in x)
            {
            }
        }     
    }


}
