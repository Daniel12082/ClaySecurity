using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos; 
    public class PersonaDto : BaseDto
    { 
        public int IdPersona { get; set; }
        public ICollection<Empleado> Empleados { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public string Nombre { get; set; }
        public DateOnly FechaRegistro { get; set; }
        public int IdCiudadFk { get; set; }
        public int IdCategoriaFk { get; set; }
        public int IdTipoPersonaFk { get; set; }
        public ICollection<ContactoPer> ContactoPers { get; set; }
        public ICollection<DirPersona> DirPersonas { get; set; }
    } 
