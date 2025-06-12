using MediatR;

namespace TesteTecnico.Application.Reservas.Comandos.CancelarReserva
{
    public class CancelarReservaCommand : IRequest<Unit>
    {
        public Guid ReservaId { get; set; }

        public CancelarReservaCommand(Guid reservaId)
        {
            ReservaId = reservaId;
        }
    }
}
