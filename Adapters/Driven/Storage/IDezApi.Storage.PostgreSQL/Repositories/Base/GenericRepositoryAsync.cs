using System.ComponentModel;
using System.Reflection;

using IDezApi.Domain.Adapters.Driven.Storage;
using IDezApi.Storage.Dapper;

namespace IDezApi.Storage.PostgreSQL.Repositories.Base
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private static readonly IEnumerable<string> _propertyNames;

        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly string _tableName;
        private readonly string _schema;

        private readonly string _selectFields;
        private readonly string _insertQuery;
        private readonly string _updateQuery;

        static GenericRepositoryAsync()
        {
            _propertyNames = [.. typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p =>
                    !p.GetCustomAttributes<DescriptionAttribute>()
                      .Any(attr => attr.Description == "ignore"))
                .Select(p => p.Name)];
        }

        protected GenericRepositoryAsync(ISqlConnectionFactory sqlConnectionFactory, string tableName, string schema)
        {
            _sqlConnectionFactory = sqlConnectionFactory ?? throw new ArgumentNullException(nameof(sqlConnectionFactory));
            _tableName = tableName ?? throw new ArgumentNullException(nameof(tableName));
            _schema = schema ?? throw new ArgumentNullException(nameof(schema));

            _selectFields = BuildSelectFields();
            _insertQuery = BuildInsertQuery();
            _updateQuery = BuildUpdateQuery();
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var quotedFields = _selectFields
                           .Split(',')                    // separa os nomes
                           .Select(f => $"\"{f.Trim()}\"") // adiciona aspas duplas em cada um
                           .ToArray();

            var sql = $"SELECT {string.Join(",", quotedFields)} FROM \"{_schema}\".\"{_tableName}\"";
            var connection = _sqlConnectionFactory.GetOpenConnection();
            return await connection.QueryAsyncWithToken<T>(sql, cancellationToken: cancellationToken);
        }

        public async Task<T> GetAsync(object id, CancellationToken cancellationToken = default)
        {
            var idColumn = GetIdColumn();
            var quotedFields = _selectFields
                .Split(',')                    // separa os nomes
                .Select(f => $"\"{f.Trim()}\"") // adiciona aspas duplas em cada um
                .ToArray();

            var sql = $"SELECT {string.Join(",", quotedFields)} FROM \"{_schema}\".\"{_tableName}\" WHERE \"{idColumn}\" = @Id";

            var connection = _sqlConnectionFactory.GetOpenConnection();
            var result = await connection.QuerySingleOrDefaultWithToken<T>(sql, new { Id = id }, cancellationToken: cancellationToken);
            return result ?? throw new KeyNotFoundException($"{_schema}.{_tableName} with id [{id}] not found.");
        }

        public async Task<int> InsertAsync(T entity, CancellationToken cancellationToken = default)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            return await connection.ExecuteAsyncWithToken(_insertQuery, entity, cancellationToken: cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            await connection.ExecuteAsyncWithToken(_updateQuery, entity, cancellationToken: cancellationToken);
        }

        public async Task DeleteAsync(object id, CancellationToken cancellationToken = default)
        {
            var idColumn = GetIdColumn();
            var sql = $"DELETE FROM \"{_schema}\".\"{_tableName}\" WHERE \"{idColumn}\" = @Id";
            var connection = _sqlConnectionFactory.GetOpenConnection();
            await connection.ExecuteAsyncWithToken(sql, new { Id = id }, cancellationToken: cancellationToken);
        }

        public async Task InsertRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            using var transaction = connection.BeginTransaction();

            try
            {
                await connection.ExecuteAsyncWithToken(_insertQuery, entities, transaction, cancellationToken: cancellationToken);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        #region Helpers

        private bool IsId(string property) => property.Equals("Id", StringComparison.OrdinalIgnoreCase) ||
                                              property.Equals($"{_tableName}Id", StringComparison.OrdinalIgnoreCase);

        private string GetIdColumn() =>
            _propertyNames.FirstOrDefault(IsId) ?? throw new Exception("ID column not found.");

        private static string BuildSelectFields()
        {
            var fields = _propertyNames
                .Select(p => p)
                .ToList();

            return string.Join(",", fields);
        }


        private string BuildInsertQuery()
        {
            var columns = _propertyNames
                .ToList();

            var columnList = string.Join(",", columns.Select(c => $"\"{c}\""));
            var valueList = string.Join(",", columns.Select(c => $"@{c}"));

            return $"INSERT INTO \"{_schema}\".\"{_tableName}\" ({columnList}) VALUES ({valueList})";
        }

        private string BuildUpdateQuery()
        {
            var idColumn = GetIdColumn();
            var setClause = string.Join(",", _propertyNames
                .Where(p => !IsId(p))
                .Select(p => $"\"{p}\" = @{p}"));

            return $"UPDATE \"{_schema}\".\"{_tableName}\" SET {setClause} WHERE \"{idColumn}\" = @{idColumn}";
        }

        #endregion
    }
}
