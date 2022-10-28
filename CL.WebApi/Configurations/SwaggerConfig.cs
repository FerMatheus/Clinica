using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CL.WebApi.Configurations;

public static class SwaggerConfig
{

    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen( op =>
        {
            op.SwaggerDoc("v1", new OpenApiInfo {
                Title = "Clinica GESAD",
                Version = "v1",
                Description = "Api da aplicação Clinica GESAD",
                Contact = new OpenApiContact {
                    Name = "GESAD Newcomers",
                    Email = "fernandes.matheus@aluno.uece.br",
                    Url = new Uri("https://github.com/GESAD-Newcomers"),
                },
                License = new OpenApiLicense {
                    Name = "OSD",
                    Url = new Uri("https://opensource.org/osd"),
                },
                TermsOfService = new Uri("https://opensource.org/osd")
            });
            var xmlname = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlname);
            op.IncludeXmlComments(xmlPath);
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
