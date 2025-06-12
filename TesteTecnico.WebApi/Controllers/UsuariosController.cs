using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteTecnico.Application.Usuarios.Comandos.CriarUsuario;
using TesteTecnico.Application.Usuarios.DTOs;
using TesteTecnico.Domain.Entidades;
using TesteTecnico.Domain.ValueObjects;

namespace TesteTecnico.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpPost("usuarios")]
        public async Task<IActionResult> CriarUsuario([FromBody] CriarUsuarioDTO dto)
        {
            var command = new CriarUsuarioCommand(dto);
            var resultado = await _mediator.Send(command);
            return CreatedAtAction(nameof(ObterUsuarioPorId), new { id = resultado.Id }, resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterUsuarioPorId(int id)
        {
            // Aqui você implementa o Get para pegar o usuário por ID
            return Ok();
        }
    }
}
