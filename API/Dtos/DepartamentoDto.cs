using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos; 
    public class DepartamentoDto : BaseDto
    { 
        public string NombreDepartamento { get; set; }
        public int IdPaisFk { get; set; }
        public ICollection<Ciudad> Ciudades { get; set; }
    } 
