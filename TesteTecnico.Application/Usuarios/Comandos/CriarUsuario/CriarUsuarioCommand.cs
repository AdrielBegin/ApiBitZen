using MediatR;
using TesteTecnico.Application.Usuarios.DTOs;

namespace TesteTecnico.Application.Usuarios.Comandos.CriarUsuario
{
    public class CriarUsuarioCommand : IRequest<UsuarioDTO>
    {
        public CriarUsuarioDTO Usuario { get; set; }

        public CriarUsuarioCommand(CriarUsuarioDTO usuario)
        {
            Usuario = usuario;
        }
    }
}
