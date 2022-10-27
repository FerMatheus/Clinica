using CL.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CL.Data.Context;

public class ClinicaContext : DbContext
{
	public ClinicaContext(DbContextOptions<ClinicaContext> context) : base(context) { }

	public DbSet<Cliente> Clientes { get; set; }

	protected override void OnModelCreating(ModelBuilder db)
	{
		db.Entity<Cliente>().HasKey(c => c.Id);
		db.Entity<Cliente>().Property(c => c.Nome).HasMaxLength(100).IsRequired();
        db.Entity<Cliente>().Property(c => c.Sexo).IsRequired();
        db.Entity<Cliente>().Property(c => c.Telefone).HasMaxLength(12).IsRequired();
        db.Entity<Cliente>().Property(c => c.Documento).HasMaxLength(15).IsRequired();
    }
}
