using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TurnosConfiguration : IEntityTypeConfiguration<Turno>
    {
        public void Configure(EntityTypeBuilder<Turno> builder)
        {
            builder.ToTable("Turno");
            builder.HasKey(e => e.Id).HasName("idTurno");

            builder.Property(e => e.NombreTurno)
                .HasColumnName("NombreTurno")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.HoraInicio)
                .HasColumnName("HoraInicio")
                .HasColumnType("time")
                .IsRequired();
            builder.Property(e => e.HoraFin)
                .HasColumnName("HoraFin")
                .HasColumnType("time")
                .IsRequired();
        }
    }
}
