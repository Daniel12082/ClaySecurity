using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ProgramacionConfiguration : IEntityTypeConfiguration<Programacion>
    {
        public void Configure(EntityTypeBuilder<Programacion> builder)
        {
            builder.ToTable("Programacion");
            builder.HasKey(e => e.Id).HasName("idProgramacion");

            builder.HasOne(d => d.Contrato)
                .WithMany(p => p.Programaciones)
                .HasForeignKey(d => d.IdContratoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Programacion_Contrato");

            builder.HasOne(d => d.Turnos)
                .WithMany(p => p.Programaciones)
                .HasForeignKey(d => d.IdTurnosFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Programacion_Turno");

            builder.HasOne(d => d.Empleado)
                .WithMany(p => p.Programacion)
                .HasForeignKey(d => d.IdEmpleadoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Programacion_Empleado");
        }
    }
}
