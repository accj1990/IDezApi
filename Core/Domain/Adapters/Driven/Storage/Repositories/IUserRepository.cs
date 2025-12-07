using IDezApi.Domain.Adapters.Driven.Storage;
using IDezApi.Domain.Entity;

namespace IDezApi.Domain.Adapters.Driven.Storage.Repositories
{
    public interface IUserRepository : IGenericRepositoryAsync<User>
    {
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    }
}
