using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Reflection.Plugin;
using System;
using System.IO;

namespace Reflection.Providers
{
    public class ConfigurationManagerProvider : ICustomConfigurationProvider
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");

        public ConfigurationProviderType ConfigurationProviderType => ConfigurationProviderType.ConfigurationManager;

        public string Read(string key)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json", false, true)
               .Build();

            return configuration.GetSection(key).Value;
        }


        public void Write<TInput>(string key, TInput value)
        {
            var inputJson = File.ReadAllText(_filePath);

            dynamic jsonObject = JsonConvert.DeserializeObject(inputJson);
            jsonObject[key] = value;

            var outputJson = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
            File.WriteAllText(_filePath, outputJson);
        }
    }
}
