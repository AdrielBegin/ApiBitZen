using MediatR;
using TesteTecnico.Domain.Enums;
using TesteTecnico.Domain.Excecoes;
using TesteTecnico.Domain.Interfaces;

namespace TesteTecnico.Application.Reservas.Comandos.CancelarReserva
{
    public class CancelarReservaCommandHandler : IRequestHandler<CancelarReservaCommand, Unit>
    {
        private readonly IReservaRepositorio _reservaRepositorio;

        public CancelarReservaCommandHandler(IReservaRepositorio reservaRepositorio)
        {
            _reservaRepositorio = reservaRepositorio;
        }


        public async Task<Unit> Handle(CancelarReservaCommand request, CancellationToken cancellationToken)
        {
            var reserva = await _reservaRepositorio.ObterPorId(request.ReservaId);
            

            if (reserva == null)
                throw new ValidacaoException("Reserva não encontrada.");

            reserva.Status = StatusReserva.Cancelada;
            await _reservaRepositorio.Atualizar(reserva);

            return Unit.Value;
        }

    }
}
