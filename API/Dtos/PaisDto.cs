using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos; 
    public class PaisDto : BaseDto
    { 
        public string NombrePais { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
    } 
