using MediatR;
using TesteTecnico.Application.Salas.DTOs;

namespace TesteTecnico.Application.Salas.Comandos.CriarSala
{
    public class CriarSalaCommand : IRequest<SalaDTO>
    {
        public string Nome { get; set; }
        public int CapacidadeMaxima { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}
