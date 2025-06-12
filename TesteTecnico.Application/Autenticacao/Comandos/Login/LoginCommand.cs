using MediatR;
using TesteTecnico.Application.Autenticacao.DTOs;

namespace TesteTecnico.Application.Autenticacao.Comandos.Login
{
    public class LoginCommand : IRequest<RespostaAutenticacaoDTO>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
