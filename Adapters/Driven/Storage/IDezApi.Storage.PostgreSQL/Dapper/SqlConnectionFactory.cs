using System.Data;

using Npgsql;

using IDezApi.Domain.Adapters.Driven.Storage;


namespace IDezApi.Storage.Dapper
{
    public class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
    {
        private readonly string _connectionString;
        private IDbConnection? _connection;
        private bool _disposed;

        public SqlConnectionFactory(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("A connection string não pode ser nula ou vazia.", nameof(connectionString));

            _connectionString = connectionString;
        }

        public IDbConnection GetOpenConnection()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(SqlConnectionFactory));

            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection?.Dispose(); // se tiver suja, joga fora antes
                _connection = new NpgsqlConnection(_connectionString);
                _connection.Open();
            }

            return _connection;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                if (_connection != null)
                {
                    _connection.Dispose();
                    _connection = null;
                }
            }

            _disposed = true;
        }
    }
}
