using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            builder.HasOne(d => d.Cliente)
                .WithMany(p => p.Contratos)
                .HasForeignKey(d => d.IdClienteFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contrato_Cliente");

            builder.HasOne(d => d.Empleado)
                .WithMany(p => p.Contratos)
                .HasForeignKey(d => d.IdEmpleadoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contrato_Empleado");

            builder.HasOne(d => d.Estado)
                .WithMany(p => p.Contratos)
                .HasForeignKey(d => d.IdEstadoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contrato_Estado");
        }
    }
}
