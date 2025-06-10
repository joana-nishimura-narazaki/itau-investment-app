using Application.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        // Retorna todos os usuários cadastrados
        public Task<IEnumerable<Usuario>> GetAllAsync()
            => _repo.GetAllAsync();

        // Retorna um usuário por ID
        public Task<Usuario?> GetByIdAsync(int id)
            => _repo.GetByIdAsync(id);

        // Cria um novo usuário (validações básicas)
        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nome))
                throw new ArgumentException("Nome é obrigatório");

            if (string.IsNullOrWhiteSpace(usuario.Email))
                throw new ArgumentException("Email é obrigatório");

            await _repo.AddAsync(usuario);
            return usuario;
        }
    }
}
