using CL.Manager.Mapping;

namespace CL.WebApi.Configurations;

public static class AutoMapperConfig
{
    public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(NovoClienteMappingProfile),
                               typeof(AlteraClienteMappingProfile),
                               typeof(MedicoMappingProfile),
                               typeof(EspecialidadeMappingProfile));
    }
}
