using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnico.Application.Autenticacao.DTOs;

namespace TesteTecnico.Application.Autenticacao.Comandos.Login
{
    public class LoginCommand : IRequest<RespostaAutenticacaoDTO>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
