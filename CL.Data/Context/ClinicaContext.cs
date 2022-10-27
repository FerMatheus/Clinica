using CL.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CL.Data.Context;

public class ClinicaContext : DbContext
{
	public ClinicaContext(DbContextOptions<ClinicaContext> context) : base(context) { }

	public DbSet<Cliente> Clientes { get; set; }
}
