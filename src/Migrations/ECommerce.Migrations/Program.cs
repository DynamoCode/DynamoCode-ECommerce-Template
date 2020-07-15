using System.Xml.Linq;
using System;
using System.IO;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

            IConfiguration config = builder.Build();
            string connectionString = config.GetConnectionString("Context");

            var serviceProvider = CreateServices(connectionString);

            // Put the database update into a scope to ensure
            // that all resources will be disposed.
            using (var scope = serviceProvider.CreateScope())
            {
                MigrateUp(scope.ServiceProvider);
            }
        }

        private static string GetDatabaseConnection()
        {
            string conn = "Data Source=";

            string current = Directory.GetCurrentDirectory();
            var migrations = Directory.GetParent(current);
            var src = migrations.Parent;
            string database = System.IO.Path.Combine(src.FullName,"DataBase","ecommerce.db"); 

            return string.Concat(conn, database,";Version=3;");
        }

        /// <summary>
        /// Configure the dependency injection services
        /// </summary>
        private static IServiceProvider CreateServices(string connectionString)
        {
            return new ServiceCollection()
                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .AddSingleton<IAssemblySourceItem>(new AssemblySourceItem(typeof(Program).Assembly))
                .ConfigureRunner(rb => rb
                    //.AddSqlServer2016()
                    .AddSQLite()
                    .WithGlobalConnectionString(GetDatabaseConnection())
                    .ScanIn(typeof(Program).Assembly).For.Migrations())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                // Build the service provider
                .BuildServiceProvider(false);               
        }


        /// <summary>
        /// Update the database
        /// </summary>
        private static void MigrateUp(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateUp();
        }

        /// <summary>
        /// Update the database
        /// </summary>
        private static void MigrateDown(IServiceProvider serviceProvider, long version)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateDown(version);
        }
    }
}
