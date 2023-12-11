using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 

namespace API.Dtos; 
    public class DirPersonaDto : BaseDto
    { 
        public string Direccion { get; set; }
        public int IdPersonaFk { get; set; }
        public int IdTipoDireccionFk { get; set; }
    } 
