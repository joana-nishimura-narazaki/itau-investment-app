namespace Application.Interfaces
{
    using Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface para repositório de Usuários.
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Adiciona um novo usuário.
        /// </summary>
        Task<Usuario> AddAsync(Usuario usuario);

        /// <summary>
        /// Retorna um usuário pelo ID.
        /// </summary>
        Task<Usuario?> GetByIdAsync(int id);

        /// <summary>
        /// Retorna todos os usuários.
        /// </summary>
        Task<IEnumerable<Usuario>> GetAllAsync();
    }
}
