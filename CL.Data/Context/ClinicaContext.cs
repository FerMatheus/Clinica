using CL.Core.Domain;
using CL.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CL.Data.Context;

public class ClinicaContext : DbContext
{
	public ClinicaContext(DbContextOptions<ClinicaContext> context) : base(context) { }

	public DbSet<Cliente> Clientes { get; set; }
	public DbSet<Medico> Medicos { get; set; }
	public DbSet<Especialidade> Especialidades { get; set; }

	protected override void OnModelCreating(ModelBuilder db)
	{
		db.ApplyConfiguration(new ClienteConfig());
		db.ApplyConfiguration(new MedicoConfig());
		db.ApplyConfiguration(new EspecialidadeConfig());
    }
}
