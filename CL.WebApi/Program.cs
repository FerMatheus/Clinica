using CL.Data.Context;
using CL.Data.Repository;
using CL.Manager.Implementation;
using CL.Manager.Interfaces;
using CL.Manager.Mapping;
using CL.Manager.Validation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation( op =>
{
    op.RegisterValidatorsFromAssemblyContaining<NovoClienteValidator>();
    op.RegisterValidatorsFromAssemblyContaining<AlteraClienteValidator>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddAutoMapper(typeof(NovoClienteMappingProfile),typeof(AlteraClienteMappingProfile));

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteManager, ClienteManager>();

var connectionString = builder.Configuration.GetConnectionString("MatheusConnection");

builder.Services.AddDbContext<ClinicaContext>(op =>
{
    op.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
