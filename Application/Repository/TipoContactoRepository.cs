using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 
using Api.Repository; 
using Domain.Entities; 
using Domain.Interfaces; 
using Microsoft.EntityFrameworkCore; 
using Persistence.Data; 

namespace Application.Repository 
{ 
    public class TipoContactoRepository : GenericRepository<TipoContacto> , ITipoContacto 
    { 
        public ClaySecurityContext _context { get; set; } 
        public TipoContactoRepository(ClaySecurityContext context) : base(context) 
        { 
            _context = context; 
        } 
    } 
} 
