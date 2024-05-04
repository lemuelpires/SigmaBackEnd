using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace sigmaBack.Infra.Data.Contexts
{
    public class SigmaDbContextFactory : IDesignTimeDbContextFactory<SigmaDbContext>
    {
        public SigmaDbContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.Development.json")
                .AddJsonFile($"appsettings.Development{environmentName}.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<SigmaDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new SigmaDbContext(optionsBuilder.Options);
        }

    }
}
