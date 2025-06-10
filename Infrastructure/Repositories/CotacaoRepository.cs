namespace Infrastructure.Repositories
{
    using Application.Interfaces;
    using Domain.Entities;
    using Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CotacaoRepository : ICotacaoRepository
    {
        private readonly AppDbContext _ctx;
        public CotacaoRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<Cotacao> AddAsync(Cotacao c)
        {
            _ctx.Cotacoes.Add(c);
            await _ctx.SaveChangesAsync();
            return c;
        }

        public async Task<IEnumerable<Cotacao>> GetByAtivoAsync(int ativoId)
            => await _ctx.Cotacoes
                         .Where(c => c.AtivoId == ativoId)
                         .ToListAsync();
    }
}
