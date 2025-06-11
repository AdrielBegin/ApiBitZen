using TesteTecnico.Domain.Entidades;

namespace TesteTecnico.Domain.Interfaces
{
    public interface ISalaRepositorio
    {
        public interface ISalaRepositorio
        {
            Sala ObterPorId(int id);
            IEnumerable<Sala> ObterTodas();
            void Adicionar(Sala sala);
            void Atualizar(Sala sala);
            void Remover(int id);
        }
    }
}
