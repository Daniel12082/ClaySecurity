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
    public class ProgramacionRepository : GenericRepository<Programacion> , IProgramacion 
    { 
        public ClaySecurityContext _context { get; set; } 
        public ProgramacionRepository(ClaySecurityContext context) : base(context) 
        { 
            _context = context; 
        } 
    } 
} 
