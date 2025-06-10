using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOperacaoRepository
    {
        Task<IEnumerable<Operacao>> GetAllAsync();
        Task<Operacao?> GetByIdAsync(int id);
        Task<IEnumerable<Operacao>> GetByUsuarioAsync(int usuarioId);
        Task AddAsync(Operacao operacao);
        Task UpdateAsync(Operacao operacao);
        Task DeleteAsync(int id);
    }
}
