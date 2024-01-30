using Simego.DataSync.Providers.Ado;
using System;
using System.Data.Common;
using System.Globalization;
using System.Reflection;

namespace Simego.DataSync.Providers.PostgreSql
{
    [ProviderInfo(Name = "PostgreSql (8.0.1)", Description = "Npgsql for PostgreSql", Group = "SQL")]
    public class PostgreSqlDatasourceReader : AdoDataSourceReader
    {
        private Lazy<AdoDbProviderFactory> MyFactory => new Lazy<AdoDbProviderFactory>(() => new AdoDbProviderFactory("Npgsql", GetFactory()));

        protected override bool IsCustomAdoProvider() => true;

        public override AdoDbProviderFactory GetProviderFactory(string providerInvariantName) => MyFactory.Value;

        private static DbProviderFactory GetFactory()
        {
            var factoryType = typeof(Npgsql.NpgsqlFactory);

            return factoryType.InvokeMember(factoryType.Name,
               BindingFlags.CreateInstance | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public,
               null, null, null, CultureInfo.CurrentCulture) as DbProviderFactory;
        }
    }
}

