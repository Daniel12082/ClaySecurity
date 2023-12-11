using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("Persona");
            builder.HasKey(e => e.Id).HasName("idPersona");

            builder.HasIndex(e => e.IdPersona).IsUnique();


            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50) 
                .IsUnicode(false)
                .HasColumnName("Nombre");

            builder.Property(e => e.FechaRegistro)
                .HasColumnType("date")
                .HasColumnName("FechaRegistro");

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            builder.HasOne(d => d.Ciudad)
                .WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdCiudadFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_Ciudad");
                
            builder.HasOne(d => d.Categoria)
                .WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdCategoriaFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_Categoria");

            builder.HasOne(d => d.TipoPersona)
                .WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdTipoPersonaFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_TipoPersona");
        }
    }
}
