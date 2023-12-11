using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ContratoConfiguration : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            builder.ToTable("Contrato");

            builder.HasKey(e => e.Id).HasName("idContrato");
            builder.Property(e => e.FechaContrato)
                .HasColumnType("date")
                .HasColumnName("fechaInicio");

            builder.Property(e => e.FechaFin)
                .HasColumnType("date")
                .HasColumnName("fechaFin");

            builder.HasOne(c => c.Cliente)
                .WithMany(c => c.Contratos)
                .HasForeignKey(c => c.IdClienteFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contrato_Cliente");

            builder.HasOne(c => c.Empleado)
                .WithMany(c => c.Contratos)
                .HasForeignKey(c => c.IdEmpleadoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contrato_Empleado");

            builder.HasOne(c => c.Estado)
                .WithMany(p => p.Contratos)
                .HasForeignKey(c => c.IdEstadoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contrato_Estado");
        }
    }
}
