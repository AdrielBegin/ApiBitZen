using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteTecnico.Application.Salas.Comandos.CriarSala;

namespace TesteTecnico.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SalasController : Controller
    {
        private readonly IMediator _mediator;

        public SalasController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CriarSala([FromBody] CriarSalaCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = await _mediator.Send(command);
         
            return Ok(resultado);
        }
    }
}
