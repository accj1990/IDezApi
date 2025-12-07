// Licensed under the MIT license.

using System.Data;

namespace IDezApi.Domain.Adapters.Driven.Storage
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
