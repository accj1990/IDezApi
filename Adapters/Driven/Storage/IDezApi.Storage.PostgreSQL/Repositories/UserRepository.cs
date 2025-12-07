using System.Data;

using Microsoft.Extensions.Logging;

using IDezApi.Domain.Adapters.Driven.Storage;
using IDezApi.Domain.Adapters.Driven.Storage.Repositories;
using IDezApi.Domain.Entity;
using IDezApi.Storage.Dapper;
using IDezApi.Storage.PostgreSQL.Repositories.Base;

namespace IDezApi.Storage.PostgreSQL.Repositories
{
    public class UserRepository : GenericRepositoryAsync<User>, IUserRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IDbConnection _connection;
        private readonly ILogger<GenericRepositoryAsync<User>> _logger;

        public UserRepository(ISqlConnectionFactory sqlConnectionFactory, ILogger<GenericRepositoryAsync<User>> logger) : base(sqlConnectionFactory, "user", "public")
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _connection = _sqlConnectionFactory.GetOpenConnection();
            _logger = logger;
        }

        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogInformation("Consultando o banco... ");

                var SQL = "SELECT \"Id\", \"Email\", \"Password\", \"Picture\", \"IsAdmin\"\r\nFROM public.\"user\" A\r\nWHERE A.\"Email\" = @EMAIL";

                var result = await _connection.QuerySingleOrDefaultWithToken<User>(SQL,
                    param: new { EMAIL = email },
                    cancellationToken: cancellationToken);
                return result;
            }
            catch
            {
                _logger.LogInformation("Exceção consultando no banco... ");

                throw;
            }
        }
    }
}
