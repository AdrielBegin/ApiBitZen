using MediatR;
using TesteTecnico.Application.Reservas.DTOs;

namespace TesteTecnico.Application.Reservas.Comandos.CriarReserva
{
    public class CriarReservaCommand : IRequest<Guid>
    {
        public CriarReservaDTO DTO { get; set; }
        public CriarReservaCommand(CriarReservaDTO dto)
        {
            DTO = dto;
        }
    }
}
