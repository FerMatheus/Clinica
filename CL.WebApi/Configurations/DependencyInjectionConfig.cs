using CL.Data.Repository;
using CL.Manager.Implementation;
using CL.Manager.Interfaces;

namespace CL.WebApi.Configurations;

public static class DependencyInjectionConfig
{
    public static void AddDependencyinjectionConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IClienteManager, ClienteManager>();
        services.AddScoped<IMedicoRepository, MedicoRepository>();
        services.AddScoped<IMedicoManager, MedicoManager>();
        services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
        services.AddScoped<IEspecialidadeManager, EspecialidadeManager>();
    }
}
