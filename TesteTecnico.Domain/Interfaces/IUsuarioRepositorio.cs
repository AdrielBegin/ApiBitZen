using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnico.Domain.Entidades;

namespace TesteTecnico.Domain.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Usuario ObterPorId(int id);
        IEnumerable<Usuario> ObterTodos();
        void Adicionar(Usuario usuario);
        void Atualizar(Usuario usuario);
        Task<Usuario> ObterPorEmailAsync(string email);        
        void Remover(bool excluido);
    }
}
