using Reflection.Plugin;
using System.Collections.Generic;

namespace Reflection.Providers
{
    public static class ProvidersLoader
    {
        public static IDictionary<ConfigurationProviderType, ICustomConfigurationProvider> GetProviders()
        {
            var dict = new Dictionary<ConfigurationProviderType, ICustomConfigurationProvider>();

            dict.TryAdd(ConfigurationProviderType.ConfigurationManager, new ConfigurationManagerProvider());
            dict.TryAdd(ConfigurationProviderType.File, new FileProvider());

            return dict;
        }
    }
}
