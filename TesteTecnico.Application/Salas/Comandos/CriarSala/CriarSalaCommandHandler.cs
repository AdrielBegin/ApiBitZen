using MediatR;
using TesteTecnico.Application.Salas.DTOs;
using TesteTecnico.Domain.Entidades;
using TesteTecnico.Domain.Interfaces;

namespace TesteTecnico.Application.Salas.Comandos.CriarSala
{
    public class CriarSalaCommandHandler : IRequestHandler<CriarSalaCommand, SalaDTO>
    {
        private readonly ISalaRepositorio _salaRepositorio;

        public CriarSalaCommandHandler(ISalaRepositorio salaRepositorio)
        {
            _salaRepositorio = salaRepositorio;
        }

        public async Task<SalaDTO> Handle(CriarSalaCommand request, CancellationToken cancellationToken)
        {
            var sala = new Sala(request.Nome, request.CapacidadeMaxima,request.DataCriacao,request.DataExclusao ?? DateTime.MinValue);
            await _salaRepositorio.AdicionarAsync(sala);

            var salaDto = new SalaDTO
            {
                Id = sala.Id,
                Nome = sala.Nome,
                CapacidadeMaxima = sala.CapacidadeMaxima,
                DataCriacao = sala.DataCriacao,
                DataExclusao = null
            };

            return salaDto;
        }
    }
}
