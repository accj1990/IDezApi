// Licensed under the MIT license.

using System.Data;

using Dapper;

namespace IDezApi.Storage.Dapper
{
    public static class DapperExtensionAsync
    {
        /// <summary>
        /// Executa um comando SQL com suporte a token de cancelamento.
        /// </summary>
        public static Task<int> ExecuteAsyncWithToken(this IDbConnection cnn,
            string sql,
            object? param = null,
            IDbTransaction? transaction = null,
            int? commandTimeout = null,
            CommandType? commandType = null,
            CancellationToken cancellationToken = default) =>
            cnn.ExecuteAsync(CreateCommand(sql, param, transaction, commandTimeout, commandType, cancellationToken));

        /// <summary>
        /// Executa uma consulta SQL retornando uma coleção de elementos do tipo T.
        /// </summary>
        public static Task<IEnumerable<T>> QueryAsyncWithToken<T>(this IDbConnection cnn,
            string sql,
            object? param = null,
            IDbTransaction? transaction = null,
            int? commandTimeout = null,
            CommandType? commandType = null,
            CancellationToken cancellationToken = default) =>
            cnn.QueryAsync<T>(CreateCommand(sql, param, transaction, commandTimeout, commandType, cancellationToken));

        /// <summary>
        /// Executa uma consulta SQL retornando um único elemento ou valor padrão.
        /// </summary>
        public static Task<T?> QuerySingleOrDefaultWithToken<T>(this IDbConnection cnn,
            string sql,
            object? param = null,
            IDbTransaction? transaction = null,
            int? commandTimeout = null,
            CommandType? commandType = null,
            CancellationToken cancellationToken = default) =>
            cnn.QuerySingleOrDefaultAsync<T>(CreateCommand(sql, param, transaction, commandTimeout, commandType, cancellationToken));

        /// <summary>
        /// Executa uma consulta SQL retornando um único elemento.
        /// </summary>
        public static Task<T> QuerySingleWithToken<T>(this IDbConnection cnn,
            string sql,
            object? param = null,
            IDbTransaction? transaction = null,
            int? commandTimeout = null,
            CommandType? commandType = null,
            CancellationToken cancellationToken = default) =>
            cnn.QuerySingleAsync<T>(CreateCommand(sql, param, transaction, commandTimeout, commandType, cancellationToken));

        // Método auxiliar para evitar repetição de código
        private static CommandDefinition CreateCommand(
             string sql,
             object? param,
             IDbTransaction? transaction,
             int? timeout,
             CommandType? type,
             CancellationToken cancellationToken)
        {
            return new CommandDefinition(
                commandText: sql,
                parameters: param,
                transaction: transaction,
                commandTimeout: timeout,
                commandType: type,
                cancellationToken: cancellationToken
            );
        }
    }
}
