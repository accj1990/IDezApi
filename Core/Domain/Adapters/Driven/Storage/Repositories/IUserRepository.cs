using Template.Domain.Entity;

namespace IDezApi.Domain.Adapters.Driven.Storage.Repositories
{
    public interface IUserRepository : IGenericRepositoryAsync<User>
    {
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    }
}
