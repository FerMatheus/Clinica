using CL.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CL.Data.Configuration;

public class EspecialidadeConfig : IEntityTypeConfiguration<Especialidade>
{
    public void Configure(EntityTypeBuilder<Especialidade> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Descricao).HasMaxLength(100).IsRequired();
    }
}
