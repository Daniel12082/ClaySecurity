using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos; 
    public class TipoContactoDto : BaseDto
    { 
        public string descripcion { get; set; }
        public ICollection<ContactoPer> ContactoPers { get; set; }
    } 
