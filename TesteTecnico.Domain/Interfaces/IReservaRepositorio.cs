using TesteTecnico.Domain.Entidades;

namespace TesteTecnico.Domain.Interfaces
{
    public interface IReservaRepositorio
    {
        Task<Reserva> ObterPorId(Guid id);
        Task<List<Reserva>> ObterReservasPorSalaEData(int salaId, DateTime data);
        IEnumerable<Reserva> ObterPorUsuario(int usuarioId);
        IEnumerable<Reserva> ObterPorSala(int salaId);
        void Adicionar(Reserva reserva);
        Task<Reserva> Atualizar(Reserva reserva);
        Task AdicionarAsync(Reserva reserva);
        void Remover(int id);
    }
}
