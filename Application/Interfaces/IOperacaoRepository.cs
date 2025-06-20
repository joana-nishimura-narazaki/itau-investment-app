using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOperacaoRepository
    {
        Task<IEnumerable<Operacao>> GetByUsuarioAsync(int usuarioId);
        Task AddAsync(Operacao operacao);
    }
}
