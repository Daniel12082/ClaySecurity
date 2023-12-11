using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos; 
    public class EstadoDto : BaseDto
    { 
        public string descripcion { get; set; }
        public ICollection<Contrato> Contratos { get; set; }
    } 
