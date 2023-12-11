using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Persona : BaseEntity
    {
        public int IdPersona { get; set; }
        public ICollection<Empleado> Empleados { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public string Nombre { get; set; }
        public DateOnly FechaRegistro { get; set; }
        public int IdCiudadFk { get; set; }
        public int IdCategoriaFk { get; set; }
        public int IdTipoPersonaFk { get; set; }
        public Ciudad Ciudad { get; set; }
        public TipoPersona TipoPersona { get; set; }
        public CategoriaPer Categoria { get; set; }
        public ICollection<ContactoPer> ContactoPers { get; set; }
        public ICollection<DirPersona> DirPersonas { get; set; }
    }
}
