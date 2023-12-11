using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos; 
    public class CiudadDto : BaseDto
    {
        public string NombreCiudad { get; set; }
        public int IdDepartamentoFk { get; set; }
        public ICollection<Persona> Personas { get; set; }
    } 
