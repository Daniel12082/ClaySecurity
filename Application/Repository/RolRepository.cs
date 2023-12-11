using Api.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Persistence;
using Persistence.Data;

namespace Application.Repository;

public class RolRepository : GenericRepository<Rol>, IRol
{
    private readonly ClaySecurityContext _context;

    public RolRepository(ClaySecurityContext context) : base(context)
    {
       _context = context;
    }
}