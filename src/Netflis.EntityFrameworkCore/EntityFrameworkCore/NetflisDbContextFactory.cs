using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Netflis.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class NetflisDbContextFactory : IDesignTimeDbContextFactory<NetflisDbContext>
{
    public NetflisDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        NetflisEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<NetflisDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new NetflisDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Netflis.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
