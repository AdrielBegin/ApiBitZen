using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteTecnico.Application.Reservas.Comandos.CancelarReserva;
using TesteTecnico.Application.Reservas.Comandos.CriarReserva;
using TesteTecnico.Application.Reservas.DTOs;

namespace TesteTecnico.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CriarReserva([FromBody] CriarReservaDTO dto)
        {
            var id = await _mediator.Send(new CriarReservaCommand(dto));
            return CreatedAtAction(nameof(CriarReserva), new { id }, dto);
        }

        [HttpPost("{id}/cancelar")]
        public async Task<IActionResult> CancelarReserva(Guid id)
        {
            await _mediator.Send(new CancelarReservaCommand(id));
            return NoContent();
        }
    }
}
