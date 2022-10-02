using AdWeb.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.DataAccess
{
    public class AdBoardContextConfiguration : IDbContextOptionsConfigurator<AdBoardContext>
    {
        private const string PostGresConnectionStringName = "PostgresAdWebDb";
        private const string MsSqlConnectionStringName = "MsSqlAdWebDb";
        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;

        public AdBoardContextConfiguration(ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            _loggerFactory = loggerFactory;
            _configuration = configuration;
        }

        public void Configure(DbContextOptionsBuilder<AdBoardContext> options)
        {
            string connectionString;

            // var useMsSql = _configuration.Get<bool>("DataBaseOptions:UseMsSql").Value;
            var useMsSql = false;

            if (!useMsSql)
            {
                connectionString = _configuration.GetConnectionString(PostGresConnectionStringName);
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException(
                            $"Не найдена строка подключения с именем '{PostGresConnectionStringName}'"
                        );
                }
                options.UseNpgsql(connectionString);
            }
            else
            {
                connectionString = _configuration.GetConnectionString(MsSqlConnectionStringName);
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException(
                            $"Не найдена строка подключения с именем '{MsSqlConnectionStringName}'"
                        );
                }
                options.UseSqlServer(connectionString);
            }
            options.UseLoggerFactory(_loggerFactory);
        }
    }
}
