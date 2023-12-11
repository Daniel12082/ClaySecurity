using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class ClaySecurityContext : DbContext
    {
        public ClaySecurityContext(DbContextOptions<ClaySecurityContext> options) : base(options)
        {
        }

        public DbSet<CategoriaPer> CategoriaPer { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<ContactoPer> ContactoPer { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<DirPersona> DirPersona { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Programacion> Programacion { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<TipoContacto> TipoContacto { get; set; }
        public DbSet<TipoDireccion> TipoDireccion { get; set; }
        public DbSet<TipoPersona> TipoPersona { get; set; }
        public DbSet<Turno> Turno { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRol> UserRol { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
