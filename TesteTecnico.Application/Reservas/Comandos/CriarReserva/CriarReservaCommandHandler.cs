using MediatR;
using TesteTecnico.Domain.Entidades;
using TesteTecnico.Domain.Enums;
using TesteTecnico.Domain.Excecoes;
using TesteTecnico.Domain.Interfaces;
using TesteTecnico.Domain.ValueObjects;

namespace TesteTecnico.Application.Reservas.Comandos.CriarReserva
{
    public class CriarReservaCommandHandler : IRequestHandler<CriarReservaCommand, Guid>
    {
        private readonly IReservaRepositorio _reservaRepositorio;

        public CriarReservaCommandHandler(IReservaRepositorio reservaRepositorio)
        {
            _reservaRepositorio = reservaRepositorio;
        }

        public async Task<Guid> Handle(CriarReservaCommand request, CancellationToken cancellationToken)
        {
            var dto = request.DTO;

            var reservasExistentes = await _reservaRepositorio
                .ObterReservasPorSalaEData(dto.SalaId, dto.Data);

            var novoHorario = new HorarioReserva(dto.HoraInicio, dto.HoraFim);

            if (reservasExistentes.Any(r =>
                r.Status == StatusReserva.Ativa &&
                new HorarioReserva(r.DataInicio, r.DataFim).ConflitaCom(novoHorario)))
            {
                throw new ConflitoAgendamentoException("Já existe uma reserva nesse horário.");
            }
            var dataInicio = dto.Data.Date.Add(dto.HoraInicio.TimeOfDay);

            var dataFim = dto.Data.Date.Add(dto.HoraFim.TimeOfDay);

            var reserva = new Reserva(dto.SalaId, dto.UsuarioId, dataInicio, dataFim);

            reserva.ValidarHorario();

            await _reservaRepositorio.AdicionarAsync(reserva);

            return reserva.Id;
        }
    }
}
