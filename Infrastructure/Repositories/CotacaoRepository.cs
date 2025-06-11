using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CotacaoRepository : ICotacaoRepository
    {
        private readonly AppDbContext _context;

        public CotacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cotacao>> GetByAtivoAsync(int ativoId)
        {
            return await _context.Cotacoes
                .AsNoTracking()
                .Where(c => c.AtivoId == ativoId)
                .ToListAsync();
        }

        public async Task AddAsync(Cotacao cotacao)
        {
            await _context.Cotacoes.AddAsync(cotacao);
            await _context.SaveChangesAsync();
        }
    }
}
