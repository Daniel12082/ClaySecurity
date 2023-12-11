using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class tipoDireccionConfiguration : IEntityTypeConfiguration<TipoDireccion>
    {
        public void Configure(EntityTypeBuilder<TipoDireccion> builder)
        {
            builder.ToTable("TipoDireccion");
            builder.HasKey(e => e.Id).HasName("idTipoDireccion");

            builder.Property(e => e.Descripcion)
                .HasColumnName("descripcion")
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
