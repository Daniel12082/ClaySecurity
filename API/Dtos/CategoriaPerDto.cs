using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos; 
    public class CategoriaPerDto : BaseDto
    { 
        public string NombreCategoria { get; set; }
        public ICollection<Persona> Personas { get; set; }
    } 
