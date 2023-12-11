using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Empleado : BaseEntity
    {
        public int IdPersonaFk { get; set; }
        public Persona Persona { get; set; }
        public ICollection<Contrato> Contratos { get; set; }
        public ICollection<Programacion> Programacion { get; set; }
    }
}