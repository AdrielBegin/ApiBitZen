using Microsoft.EntityFrameworkCore;
using TesteTecnico.Domain.Entidades;
using TesteTecnico.Domain.Interfaces;
using TesteTecnico.Persistence.Contexto;

namespace TesteTecnico.Persistence.Repositorio
{
    public class UsuarioRepositorio: IUsuarioRepositorio
    {
        private readonly AppDbContext _context;

        public UsuarioRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Usuario> ObterTodos() => _context.Usuarios.ToList();


        public Usuario ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> ObterPorEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email.Endereco == email);
        }

        public void Remover(bool excluido)
        {
            throw new NotImplementedException();
        }

        Task IUsuarioRepositorio.Adicionar(Usuario usuario)
        {            
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
         
            return Task.CompletedTask;
        }
    }
}
