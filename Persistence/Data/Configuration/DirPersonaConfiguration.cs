using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class dirPersonaConfiguration : IEntityTypeConfiguration<DirPersona>
    {
        public void Configure(EntityTypeBuilder<DirPersona> builder)
        {
            builder.ToTable("dirPersona");
            builder.HasKey(e => e.Id).HasName("idDirPersona");

            builder.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");


            builder.HasOne(d => d.Persona)
                .WithMany(p => p.DirPersonas)
                .HasForeignKey(d => d.IdPersonaFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dirPersona_Persona");

            builder.HasOne(d => d.TipoDireccion)
                .WithMany(p => p.DirPersonas)
                .HasForeignKey(d => d.IdTipoDireccionFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dirPersona_TipoDireccion");
        }
    }
}
