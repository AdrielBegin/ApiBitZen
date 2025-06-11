using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnico.Application.Autenticacao.Common.Interfaces;
using TesteTecnico.Application.Autenticacao.DTOs;
using TesteTecnico.Application.Usuarios.DTOs;
using TesteTecnico.Domain.Excecoes;
using TesteTecnico.Domain.Interfaces;

namespace TesteTecnico.Application.Autenticacao.Comandos.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, RespostaAutenticacaoDTO>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IAutenticacaoService _autenticacaoService;

        public LoginCommandHandler(IUsuarioRepositorio usuarioRepositorio, IAutenticacaoService autenticacaoService)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _autenticacaoService = autenticacaoService;
        }

        public async Task<RespostaAutenticacaoDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepositorio.ObterPorEmailAsync(request.Email);
            if (usuario == null)
                throw new ValidacaoException("Usuário ou senha inválidos.");

            var senhaValida = _autenticacaoService.VerificarSenha(request.Senha, usuario.SenhaHash, usuario.SenhaSalt);
            if (!senhaValida)
                throw new ValidacaoException("Usuário ou senha inválidos.");

            var token = _autenticacaoService.GerarToken(usuario);

            return new RespostaAutenticacaoDTO
            {
                Token = token,
                Nome = usuario.Nome,
                Email = usuario.Email.ToString(),
            };
        }
    }
}
