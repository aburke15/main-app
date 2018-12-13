using System;
using Microsoft.Extensions.Caching.Memory;

namespace Websites.Services.System
{
    public class CachingService<T> : ICachingService<T> where T : class
    {
        private readonly IMemoryCache Cache;

        public CachingService(IMemoryCache cache) 
            => Cache = cache;

        public void Create(T item, string key, int? days, int? minutes, int? seconds)
        {
            ValidateKey(key);

            var expiration = DateTime.Now;

            if (days.HasValue)
                expiration.AddDays((double)days);

            if (minutes.HasValue)
                expiration.AddMinutes((double)minutes);

            if (seconds.HasValue)
                expiration.AddSeconds((double)seconds);

            var cacheEntry = Cache.CreateEntry(key);

            expiration.AddDays((double)days);
        }

        public T Get(string key)
        {
            ValidateKey(key);

            return (T)(Cache.Get(key));
        }

        private void ValidateKey(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new InvalidOperationException("[Key] cannot be null.");
        }
    }
}