using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ContactoPerConfiguration : IEntityTypeConfiguration<ContactoPer>
    {
        public void Configure(EntityTypeBuilder<ContactoPer> builder)
        {
            builder.ToTable("ContactoPer");
            builder.HasKey(e => e.Id).HasName("idContactoPer");

            builder.Property(e => e.descripcion)
                .HasColumnName("descripcion")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.HasIndex(e => e.descripcion).IsUnique();
            
            builder.HasOne(d => d.TipoContacto)
                .WithMany(p => p.ContactoPers)
                .HasForeignKey(d => d.IdTipoContactoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactoPer_TipoContacto");

            builder.HasOne(d => d.Persona)
                .WithMany(p => p.ContactoPers)
                .HasForeignKey(d => d.IdPersonaFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactoPer_Persona");
        }
    }
}
