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
    public class EstadoRepository : GenericRepository<Estado> , IEstado 
    { 
        public ClaySecurityContext _context { get; set; } 
        public EstadoRepository(ClaySecurityContext context) : base(context) 
        { 
            _context = context; 
        } 
    } 
} 
