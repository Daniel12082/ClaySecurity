using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos; 
    public class ContratoDto : BaseDto
    { 
        public int IdClienteFk { get; set; }
        public int IdEmpleadoFk { get; set; }
        public int IdEstadoFk { get; set; }
        public DateOnly FechaContrato { get; set; }
        public DateOnly FechaFin { get; set; }
        public virtual ICollection<Programacion> Programaciones { get; set; }
    } 
