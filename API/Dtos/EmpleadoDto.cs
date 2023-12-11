using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos; 
    public class EmpleadoDto : BaseDto
    { 
        public int IdPersonaFk { get; set; }
        public ICollection<Contrato> Contratos { get; set; }
        public ICollection<Programacion> Programacion { get; set; }
    } 
