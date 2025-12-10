using IDezApi.Domain.Adapters.Driven.Integrations.Services;

namespace IDezApi.Integrations.Cache.Service
{
    public class CacheService : ICacheService<T>
    {
        private Dictionary<string, List<T>> _cache;

        public CacheService()
        {
            _cache = new Dictionary<string, List<T>>();
        }

        public Task AddAsync(string chave, List<T> list) => throw new NotImplementedException();
        public Task<List<T>> GetAsync(string chave) => throw new NotImplementedException();
        public Task RemoveAsync(string chave, T list) => throw new NotImplementedException();
    }
}
