using CL.Data.Context;
using CL.Data.Repository;
using CL.Manager.Implementation;
using CL.Manager.Interfaces;
using CL.Manager.Mapping;
using CL.Manager.Validation;
using CL.WebApi.Configurations;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Validação 
builder.Services.AddFluentValidationConfiguration();

builder.Services.AddAutoMapperConfiguration();

// Injeção de dependência
builder.Services.AddDependencyinjectionConfiguration();

var connectionString = builder.Configuration.GetConnectionString("MatheusConnection");

builder.Services.AddDbContext<ClinicaContext>(op =>
{
    op.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerConfiguration();

var app = builder.Build();


// Configure the HTTP request pipeline.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
app.UseSwaggerConfiguration();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
