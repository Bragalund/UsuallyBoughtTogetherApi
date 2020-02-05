using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UsuallyBoughtTogetherApi.Constants;

namespace UsuallyBoughtTogetherApi.tests.TestUtils
{
    public class CustomWebApplicationFactory<T> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                
                Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentConstants.AutomatedTesting);
                
                // Create a new service provider.
                var serviceProvider = new ServiceCollection().BuildServiceProvider();

                // Add a database context (AppDbContext) using an in-memory database for testing.
                var connection = new SqliteConnection("DataSource=:memory:");

                connection.Open();
                services.AddDbContext<PredictionContext>(options =>
                {
                    options.UseSqlite(connection);
                    options.UseInternalServiceProvider(serviceProvider);
                });
                
                
                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database contexts
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                }
            });
        }
    }
}