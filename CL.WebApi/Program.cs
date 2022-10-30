using CL.Data.Context;
using CL.Data.Repository;
using CL.Manager.Implementation;
using CL.Manager.Interfaces;
using CL.Manager.Mapping;
using CL.Manager.Validation;
using CL.WebApi.Configurations;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(op =>
{
    op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});



// Valida��o 
builder.Services.AddFluentValidationConfiguration();

builder.Services.AddAutoMapperConfiguration();

// Inje��o de depend�ncia
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
