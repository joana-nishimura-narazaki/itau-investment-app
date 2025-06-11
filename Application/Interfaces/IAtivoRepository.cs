using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAtivoRepository
    {
        Task<IEnumerable<Ativo>> GetAllAsync();
        Task<Ativo?> GetByIdAsync(int id);
        Task AddAsync(Ativo ativo);
        
    }
}
