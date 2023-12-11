using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos; 
    public class TipoPersonaDto : BaseDto
    { 
        public string Descripcion { get; set; }
        public ICollection<Persona> Personas { get; set; }
    } 
