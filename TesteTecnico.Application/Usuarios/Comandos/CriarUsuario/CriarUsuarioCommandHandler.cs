using AutoMapper;
using MediatR;
using TesteTecnico.Application.Autenticacao.Common.Interfaces;
using TesteTecnico.Application.Usuarios.DTOs;
using TesteTecnico.Domain.Entidades;
using TesteTecnico.Domain.Interfaces;
using TesteTecnico.Domain.ValueObjects;

namespace TesteTecnico.Application.Usuarios.Comandos.CriarUsuario
{
    public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, UsuarioDTO>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IMapper _mapper;
        private readonly IAutenticacaoService _autenticacaoService;      
        public CriarUsuarioCommandHandler(IUsuarioRepositorio usuarioRepositorio, IMapper mapper, IAutenticacaoService autenticacaoService)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
            _autenticacaoService = autenticacaoService;
        }

        public async Task<UsuarioDTO> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Usuario;
                        
            _autenticacaoService.CriarSenhaHash(dto.Senha, out var senhaHash, out var senhaSalt);

            var email = new Email(dto.Email); 

            var usuario = new Usuario(
                id: 0,
                nome: dto.Nome,
                email: email,
                senhaHash: senhaHash,
                senhaSalt: senhaSalt,
                excluido: false,
                dataCriacao: DateTime.UtcNow
            );

            await _usuarioRepositorio.Adicionar(usuario); 

            return _mapper.Map<UsuarioDTO>(usuario);
        }
    }
}
