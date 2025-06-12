using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteTecnico.Application.Autenticacao.Comandos.Login;

namespace TesteTecnico.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacaoController : Controller
    {
        private readonly IMediator _mediator;

        public AutenticacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var resultado = await _mediator.Send(command);
            return Ok(resultado);
        }
    }
}
