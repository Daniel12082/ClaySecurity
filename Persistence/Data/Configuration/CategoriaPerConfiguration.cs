using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CategoriaPerConfiguration : IEntityTypeConfiguration<CategoriaPer>
    {
        public void Configure(EntityTypeBuilder<CategoriaPer> builder)
        {
            builder.ToTable("CategoriaPer");
            builder.HasKey(e => e.Id).HasName("idCategoriaPer");

            builder.Property(e => e.NombreCategoria)
                .HasColumnName("NombreCategoria")
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
