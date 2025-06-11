using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AtivoRepository : IAtivoRepository
    {
        private readonly AppDbContext _context;

        public AtivoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ativo>> GetAllAsync()
        {
            return await _context.Ativos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Ativo?> GetByIdAsync(int id)
        {
            return await _context.Ativos
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAsync(Ativo ativo)
        {
            await _context.Ativos.AddAsync(ativo);
            await _context.SaveChangesAsync();
        }
    }
}
