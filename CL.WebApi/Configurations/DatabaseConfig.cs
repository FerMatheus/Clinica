using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CL.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CL.WebApi.Configurations;

public static class DatabaseConfig
{
    public static void AddDataBaseConfiguration(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ClinicaContext>(op =>
        {
            op.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });
    }
    public static void UseDatabaseConfiguration(this WebApplication app)
    {
        using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<ClinicaContext>();
        context.Database.Migrate();
        context.Database.EnsureCreated();
    }
}

