using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICotacaoRepository
    {
        Task<IEnumerable<Cotacao>> GetByAtivoAsync(int ativoId);
        Task AddAsync(Cotacao cotacao);
    }
}
