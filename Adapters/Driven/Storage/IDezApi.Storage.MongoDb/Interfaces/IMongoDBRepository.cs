using System.Linq.Expressions;

using IDezApi.Storage.MongoDb.Models;

namespace IDezApi.Storage.MongoDb.Interfaces
{
    public interface IMongoDBRepository<T> where T : BaseEntityMDB
    {
        Task<T> InsertAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(string id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter);
        Task<bool> DeleteAsync(string id);
    }
}
