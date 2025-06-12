using TesteTecnico.Domain.Entidades;

namespace TesteTecnico.Domain.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Usuario ObterPorId(int id);
        IEnumerable<Usuario> ObterTodos();
        Task Adicionar(Usuario usuario);
        void Atualizar(Usuario usuario);
        Task<Usuario> ObterPorEmailAsync(string email);        
        void Remover(bool excluido);
    }
}
