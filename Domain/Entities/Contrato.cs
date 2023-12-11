using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Contrato : BaseEntity
    {
        public int IdClienteFk { get; set; }
        public int IdEmpleadoFk { get; set; }
        public int IdEstadoFk { get; set; }
        public DateOnly FechaContrato { get; set; }
        public DateOnly FechaFin { get; set; }
        public Persona Empleado { get; set; }
        public Persona Cliente { get; set; }
        public Estado Estado { get; set; }
        public ICollection<Programacion> Programaciones { get; set; }
    }
}
