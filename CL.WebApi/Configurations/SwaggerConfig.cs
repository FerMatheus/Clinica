using Microsoft.OpenApi.Models;

namespace CL.WebApi.Configurations;

public static class SwaggerConfig
{

    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen( op =>
        {
            op.SwaggerDoc("v1", new OpenApiInfo { Title = "Clinica GESAD", Version="v1"});
        });
    }
    public static void UseSwaggerConfiguration(this WebApplication app) 
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }

}
