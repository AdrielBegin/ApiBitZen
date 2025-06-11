using TesteTecnico.Domain.Entidades;

namespace TesteTecnico.Domain.Interfaces
{
    public interface IReservaRepositorio
    {
        Reserva ObterPorId(int id);
        IEnumerable<Reserva> ObterPorUsuario(int usuarioId);
        IEnumerable<Reserva> ObterPorSala(int salaId);
        void Adicionar(Reserva reserva);
        void Atualizar(Reserva reserva);
        void Remover(bool excluido);
    }
}
