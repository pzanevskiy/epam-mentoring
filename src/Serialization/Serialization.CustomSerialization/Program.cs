using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Serialization.Models.Task2;

namespace Serialization.CustomSerialization
{
    class Program
    {
        private const string FileName = "simpleclass.bin";
        static void Main(string[] args)
        {
            var simpleClassObject = new SimpleClass
            {
                SimpleString = "custom string",
                SimpleInt = 42069
            };

            IFormatter formatter = new BinaryFormatter();
            SerializeItem(simpleClassObject, formatter);

            var deserializedSimpleClass = DeserializeItem(formatter);

            ShowSimpleClass(deserializedSimpleClass);
        }

        private static void SerializeItem(SimpleClass simpleClass, IFormatter formatter)
        {
            using var fileStream = new FileStream(FileName, FileMode.Create);
            formatter.Serialize(fileStream, simpleClass);
        }

        private static SimpleClass DeserializeItem(IFormatter formatter)
        {
            using var fileStream = new FileStream(FileName, FileMode.Open);
            var simpleClassObject = (SimpleClass)formatter.Deserialize(fileStream);
            return simpleClassObject;
        }

        private static void ShowSimpleClass(SimpleClass simpleClass)
        {
            Console.WriteLine($"{simpleClass.SimpleString} - ${simpleClass.SimpleInt}");
        }
    }
}
