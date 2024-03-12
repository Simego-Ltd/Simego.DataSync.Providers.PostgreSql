using Npgsql;
using System.ComponentModel;
using System.Data.Common;

namespace Simego.DataSync.Providers.PostgreSql
{
    /// <summary>
    /// Wrapper for NpgsqlConnectionStringBuilder as it no longer works with the .NET PropertyGrid Control.
    /// </summary>
    public class PostgreSqlConnectionStringBuilder : DbConnectionStringBuilder
    {
        private readonly NpgsqlConnectionStringBuilder _builder;

        public PostgreSqlConnectionStringBuilder()
        {
            _builder = new NpgsqlConnectionStringBuilder();
        }

        public PostgreSqlConnectionStringBuilder(bool useOdbcRules)
        {
            _builder = new NpgsqlConnectionStringBuilder(useOdbcRules);
        }

        public PostgreSqlConnectionStringBuilder(string connectionString)
        {
            _builder = new NpgsqlConnectionStringBuilder(connectionString);
        }

        /// <summary>
        /// The hostname or IP address of the PostgreSQL server to connect to.
        /// </summary>
        [Category("Connection")]
        [Description("The hostname or IP address of the PostgreSQL server to connect to.")]
        [DisplayName("Host")]
        public string Host
        {
            get => _builder.Host;
            set => _builder.Host = value;
        }

        /// <summary>
        /// The TCP/IP port of the PostgreSQL server.
        /// </summary>
        [Category("Connection")]
        [Description("The TCP port of the PostgreSQL server.")]
        [DisplayName("Port")]
        [DefaultValue(NpgsqlConnection.DefaultPort)]
        public int Port
        {
            get => _builder.Port;
            set => _builder.Port = value;
        }

        ///<summary>
        /// The PostgreSQL database to connect to.
        /// </summary>
        [Category("Connection")]
        [Description("The PostgreSQL database to connect to.")]
        [DisplayName("Database")]
        public string Database
        {
            get => _builder.Database;
            set => _builder.Database = value;
        }

        /// <summary>
        /// The username to connect with.
        /// </summary>
        [Category("Credentials")]
        [Description("The username to connect with.")]
        [DisplayName("Username")]
        public string Username
        {
            get => _builder.Username;
            set => _builder.Username = value;
        }

        /// <summary>
        /// The password to connect with.
        /// </summary>
        [Category("Credentials")]
        [Description("The password to connect with.")]
        [PasswordPropertyText(true)]
        [DisplayName("Password")]
        public string Password
        {
            get => _builder.Password;
            set => _builder.Password = value;
        }

        /// <summary>
        /// Controls whether SSL is required, disabled or preferred, depending on server support.
        /// </summary>
        [Category("Security")]
        [Description("Controls whether SSL is required, disabled or preferred, depending on server support.")]
        [DisplayName("SSL Mode")]
        [DefaultValue(SslMode.Prefer)]
        public SslMode SslMode
        {
            get => _builder.SslMode;
            set => _builder.SslMode = value;
        }

        /// <summary>
        /// The time to wait (in seconds) while trying to establish a connection before terminating the attempt and generating an error.
        /// Defaults to 15 seconds.
        /// </summary>
        [Category("Timeouts")]
        [Description("The time to wait (in seconds) while trying to establish a connection before terminating the attempt and generating an error.")]
        [DisplayName("Timeout")]
        public int Timeout
        {
            get => _builder.Timeout;
            set => _builder.Timeout = value;
        }

        /// <summary>
        /// The time to wait (in seconds) while trying to execute a command before terminating the attempt and generating an error.
        /// Defaults to 30 seconds.
        /// </summary>
        [Category("Timeouts")]
        [Description("The time to wait (in seconds) while trying to execute a command before terminating the attempt and generating an error. Set to zero for infinity.")]
        [DisplayName("Command Timeout")]
        public int CommandTimeout
        {
            get => _builder.CommandTimeout;
            set => _builder.CommandTimeout = value;
        }
    }
}