using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Data;
using Application.Interfaces;

namespace Infrastructure.Repositories
{
    public class OperacaoRepository : IOperacaoRepository
    {
        private readonly AppDbContext _context;
        public OperacaoRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Operacao>> GetAllAsync()
        {
            return await _context.Operacoes.AsNoTracking().ToListAsync();
        }

        public async Task<Operacao?> GetByIdAsync(int id)
        {
            return await _context.Operacoes.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Operacao>> GetByUsuarioAsync(int usuarioId)
        {
            return await _context.Operacoes
                          .AsNoTracking()
                          .Where(o => o.UsuarioId == usuarioId)
                          .ToListAsync();
        }

        public async Task AddAsync(Operacao op)
        {
            await _context.Operacoes.AddAsync(op);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Operacao op)
        {
            _context.Operacoes.Update(op);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ent = await _context.Operacoes.FindAsync(id);
            if (ent != null)
            {
                _context.Operacoes.Remove(ent);
                await _context.SaveChangesAsync();
            }
        }
    }
}
