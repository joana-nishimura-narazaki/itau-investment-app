using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
public interface IAtivoRepository
{
    Task<IEnumerable<Ativo>> GetAllAsync();
    Task AddAsync(Ativo ativo);

    // >>>> adicione este método:
    Task<Ativo?> GetByIdAsync(int id);
}

}
