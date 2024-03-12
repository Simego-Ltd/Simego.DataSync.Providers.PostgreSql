using Npgsql;
using System.Data.Common;

namespace Simego.DataSync.Providers.PostgreSql
{
    /// <summary>
    /// Wrapper for PostgreSql DbProviderFactory so we can use our custom ConnectionStringBuilder.
    /// </summary>
    public class PostgreSqlProviderFactory : DbProviderFactory
    {        
        public override DbCommand CreateCommand() => new NpgsqlCommand();

        public override DbConnection CreateConnection() => new NpgsqlConnection();

        public override DbParameter CreateParameter() => new NpgsqlParameter();

        public override DbConnectionStringBuilder CreateConnectionStringBuilder() => new PostgreSqlConnectionStringBuilder();           

        public override DbCommandBuilder CreateCommandBuilder() => new NpgsqlCommandBuilder();

        public override DbDataAdapter CreateDataAdapter() => new NpgsqlDataAdapter();        
    }
}

