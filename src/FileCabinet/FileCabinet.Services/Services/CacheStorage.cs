using System;
using System.Collections.Generic;
using FileCabinet.Service.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace FileCabinet.Service.Services
{
    public class CacheStorage<T> : ICacheStorage<T>
    {
        private readonly MemoryCache _cache;
        private readonly IDictionary<Type, MemoryCacheEntryOptions> _cacheOptions;

        public CacheStorage(
            MemoryCache cache,
            IDictionary<Type, MemoryCacheEntryOptions> cacheOptions)
        {
            _cache = cache;
            _cacheOptions = cacheOptions;
        }

        public T GetItem(int key)
        {
            if (!_cache.TryGetValue(key, out T value))
            {
                return default(T);
            }

            return value;
        }

        public void AddItem(int key, T value)
        {
            if (_cacheOptions.TryGetValue(value.GetType(), out var options))
            {
                _cache.Set(key, value, options);
            }
        }
    }
}