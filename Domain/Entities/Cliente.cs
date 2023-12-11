using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public int IdPersonaFk { get; set; }
        public Persona Persona { get; set; }
        public ICollection<Contrato> Contratos { get; set; }
    }
}