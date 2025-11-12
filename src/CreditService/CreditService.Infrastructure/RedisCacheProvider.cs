using SharedKernel.Caching;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CreditService.Infrastructure
{
    public class RedisCacheProvider : ICacheProvider
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _db;

        public RedisCacheProvider(IConnectionMultiplexer redis)
        {
            _redis = redis;
            _db = redis.GetDatabase();
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var value = await _db.StringGetAsync(key);
            if (value.IsNullOrEmpty) return default;
            return JsonSerializer.Deserialize<T>(value!);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
        {
            var json = JsonSerializer.Serialize(value);
            await _db.StringSetAsync(key, json, expiration);
        }

        public async Task RemoveAsync(string key)
        {
            await _db.KeyDeleteAsync(key);
        }
    }

}
