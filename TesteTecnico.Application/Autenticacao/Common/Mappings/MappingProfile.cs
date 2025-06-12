using AutoMapper;
using TesteTecnico.Application.Autenticacao.DTOs;
using TesteTecnico.Application.Reservas.DTOs;
using TesteTecnico.Application.Salas.DTOs;
using TesteTecnico.Application.Usuarios.Comandos.CriarUsuario;
using TesteTecnico.Application.Usuarios.DTOs;
using TesteTecnico.Domain.Entidades;

namespace TesteTecnico.Application.Autenticacao.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<CriarUsuarioCommand, Usuario>();            
            CreateMap<Sala, SalaDTO>(); 
            CreateMap<SalaDTO, Sala>();
            CreateMap<Reserva, ReservaDTO>();
            CreateMap<ReservaDTO, Reserva>();
            CreateMap<Usuario, RespostaAutenticacaoDTO>();
            CreateMap<RegistrarDTO, Usuario>();
        }
    }
}
