using CL.Manager.Validation;
using FluentValidation.AspNetCore;

namespace CL.WebApi.Configurations;

public static class FluentValidationConfig
{
    [Obsolete]
    public static void AddFluentValidationConfiguration(this IServiceCollection services)
    {
        services.AddFluentValidation(op =>
        {
            op.RegisterValidatorsFromAssemblyContaining<NovoClienteValidator>();
            op.RegisterValidatorsFromAssemblyContaining<AlteraClienteValidator>();
            op.RegisterValidatorsFromAssemblyContaining<NovoMedicoValidator>();
        });
    }
}
