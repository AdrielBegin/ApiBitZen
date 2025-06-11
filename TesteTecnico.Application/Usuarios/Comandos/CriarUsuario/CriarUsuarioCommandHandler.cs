using AutoMapper;
using MediatR;
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

        public CriarUsuarioCommandHandler(IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var email = new Email(request.Usuario.Email);
            
            
            
            var usuario = new Usuario(
                id: 0, 
                nome: request.Usuario.Nome,
                email: email,
                senhaHash: null,
                senhaSalt: null,
                excluido: false,
                dataCriacao: DateTime.UtcNow
                );

            _usuarioRepositorio.Adicionar(usuario);

            return _mapper.Map<UsuarioDTO>(usuario);
        }
    }
}
