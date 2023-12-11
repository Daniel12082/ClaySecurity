using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TipoPersonaConfiguration : IEntityTypeConfiguration<TipoPersona>
    {
        public void Configure(EntityTypeBuilder<TipoPersona> builder)
        {
            builder.ToTable("TipoPersona");
            builder.HasKey(e => e.Id).HasName("idTipoPersona");

            builder.Property(e => e.Descripcion)
                .HasColumnName("descripcion")
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
