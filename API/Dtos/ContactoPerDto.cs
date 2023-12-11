using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 

namespace API.Dtos; 
    public class ContactoPerDto : BaseDto
    { 
        public string descripcion { get; set; }
        public int IdPersonaFk { get; set; }
        public int IdTipoContactoFk { get; set; }
    } 
