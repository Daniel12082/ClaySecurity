using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Programacion : BaseEntity
    {
        public int IdContratoFk { get; set; }
        public int IdTurnosFk { get; set; }
        public int IdEmpleadoFk { get; set; }

        public Contrato Contrato { get; set; }
        public Turno Turnos { get; set; }
        public Persona Empleado { get; set;}
        
    }
}
