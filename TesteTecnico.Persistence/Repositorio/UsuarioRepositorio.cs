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

        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> ObterPorEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public void Remover(bool excluido)
        {
            throw new NotImplementedException();
        }
    }
}
