using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos; 
    public class ClienteDto : BaseDto
    { 
        public int IdPersonaFk { get; set; }
        public ICollection<Contrato> Contratos { get; set; }
    } 
