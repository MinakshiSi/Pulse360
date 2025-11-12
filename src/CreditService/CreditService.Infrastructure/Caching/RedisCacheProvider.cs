using StackExchange.Redis;
using System.Text.Json;
using SharedKernel.Caching;

namespace CreditService.Infrastructure.Caching
{
    public class RedisCacheProvider : ICacheProvider
    {
        private readonly IDatabase _db;

        public RedisCacheProvider(IConnectionMultiplexer redis)
        {
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
