// Application/Interfaces/ICotacaoRepository.cs
namespace Application.Interfaces
{
    using Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICotacaoRepository
    {
        Task<Cotacao> AddAsync(Cotacao c);
        Task<IEnumerable<Cotacao>> GetByAtivoAsync(int ativoId);
    }
}
