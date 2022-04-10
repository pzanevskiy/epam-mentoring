﻿using Reflection.ProviderInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Reflection.Atrributes
{
    public static class ProvidersLoader
    {
        private static string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Providers",
            "Reflection.Providers.dll");

        public static IDictionary<ConfigurationProviderType, ICustomConfigurationProvider> GetProviders()
        {
            var providersDictionary = new Dictionary<ConfigurationProviderType, ICustomConfigurationProvider>();

            var assembly = Assembly.LoadFrom(_filePath);

            var types = assembly.GetTypes()
                .Where(x => x.GetInterfaces().Contains(typeof(ICustomConfigurationProvider)));

            var providers = types.Select(x => Activator.CreateInstance(x))
                .OfType<ICustomConfigurationProvider>();

            foreach (var provider in providers)
            {
                providersDictionary.TryAdd(provider.ConfigurationProviderType, provider);
            }

            return providersDictionary;
        }
    }
}
