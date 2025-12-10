using IDezApi.Domain.Adapters.Driven.Integrations.Services;

namespace IDezApi.Integrations.Cache.Service
{
    public class CacheService : ICacheService
    {
        private Dictionary<string, object> _cache;

        public CacheService()
        {
            _cache = new Dictionary<string, object>();
        }

        public Task AddAsync(string chave, object value)
        {
            chave = chave.ToLower();

            if (!_cache.ContainsKey(chave))
            {
                _cache[chave] = value;
            }

            return Task.CompletedTask;

        }
        public Task<object?> GetAsync(string chave)
        {
            chave = chave.ToLower();
            _cache.TryGetValue(chave, out var valor);
            return Task.FromResult(valor);
        }

        public Task RemoveAsync(string chave, object value)
        {
            chave = chave.ToLower();

            if (_cache.ContainsKey(chave))
            {
                chave = chave.ToLower();
                _cache.Remove(chave);
                return Task.CompletedTask;
            }
            else
            {
                throw new KeyNotFoundException("Chave não encontrada no cache.");
            }
        }
    }
}
