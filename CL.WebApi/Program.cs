using CL.WebApi.Configurations;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(op =>
{
    op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});



// Validação 
builder.Services.AddFluentValidationConfiguration();

builder.Services.AddAutoMapperConfiguration();

// Injeção de dependência
builder.Services.AddDependencyinjectionConfiguration();

var connectionString = builder.Configuration.GetConnectionString("MatheusConnection");
builder.Services.AddDataBaseConfiguration(connectionString);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

// Atualizar a base de dados com nossos Migrations
app.UseDatabaseConfiguration();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
app.UseSwaggerConfiguration();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
