using CL.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CL.Data.Configuration;

public class ClienteConfig : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Nome).HasMaxLength(100).IsRequired();
        builder.Property(c => c.Sexo).IsRequired();
        builder.Property(c => c.Telefone).HasMaxLength(12).IsRequired();
        builder.Property(c => c.Documento).HasMaxLength(15).IsRequired();
    }
}
