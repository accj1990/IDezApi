namespace IDezApi.Domain.Adapters.Driven.Integrations.Services
{
    public interface ICacheService
    {
        Task AddAsync(string chave, object value);

        Task RemoveAsync(string chave, object value);

        Task<object> GetAsync(string chave);

    }
}
