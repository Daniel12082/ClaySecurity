using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos; 
    public class TurnoDto : BaseDto
    { 
        public string NombreTurno { get; set; }
        public ICollection<Programacion> Programaciones { get; set; }
    } 
