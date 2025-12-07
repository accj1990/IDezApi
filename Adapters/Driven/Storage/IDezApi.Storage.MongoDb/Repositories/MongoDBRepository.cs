using System.Linq.Expressions;

using MongoDB.Bson;
using MongoDB.Driver;

using IDezApi.Storage.MongoDb.Context;
using IDezApi.Storage.MongoDb.Interfaces;
using IDezApi.Storage.MongoDb.Models;

namespace IDezApi.Storage.MongoDb.Repositories
{

    public class MongoDBRepository<T> : IMongoDBRepository<T> where T : BaseEntityMDB
    {
        private readonly IMongoCollection<T> _collection;

        public MongoDBRepository(MongoDbContext context)
        {
            var collectionName = typeof(T).Name.ToLowerInvariant();
            _collection = context.GetCollection<T>(collectionName);
        }

        public async Task<T> InsertAsync(T entity)
        {
            if (entity.Id == ObjectId.Empty)
                entity.Id = ObjectId.GenerateNewId();

            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var results = await _collection.FindAsync(_ => true);
            return results.ToList();
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
                return null;

            var results = await _collection.FindAsync(e => e.Id == objectId);
            return results.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter)
        {
            var results = await _collection.FindAsync(filter);
            return results.ToList();
        }

        public async Task<bool> DeleteAsync(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
                return false;

            var result = await _collection.DeleteOneAsync(e => e.Id == objectId);
            return result.DeletedCount > 0;
        }
    }
}
