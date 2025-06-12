using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnico.Domain.Enums;
using TesteTecnico.Domain.Excecoes;

namespace TesteTecnico.Domain.Entidades
{
    public class Reserva
    {
        public Guid Id { get; private set; }
        public int SalaId { get; private set; }
        public int UsuarioId { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public StatusReserva Status { get;  set; } = StatusReserva.Ativa;
        public DateTime DataCriacao { get; private set; } = DateTime.UtcNow;     
        public virtual Sala Sala { get; private set; }
        public virtual Usuario Usuario { get; private set; }
        public Reserva() { }
        public Reserva(int salaId, int usuarioId, DateTime inicio, DateTime fim)
        {
            if (inicio.Date != fim.Date)
                throw new ArgumentException("Reserva deve iniciar e terminar no mesmo dia");

            if (inicio >= fim)
                throw new ArgumentException("Data de início deve ser anterior à data de término");

            SalaId = salaId;
            UsuarioId = usuarioId;
            DataInicio = inicio;
            DataFim = fim;
        }

        public void Cancelar()
        {
            if (Status == StatusReserva.Cancelada)
                throw new InvalidOperationException("Reserva já está cancelada");

            Status = StatusReserva.Cancelada;
        }
        public void ValidarHorario()
        {
            if (DataInicio >= DataFim)
                throw new ValidacaoException("Hora de início deve ser anterior à hora de fim.");
        }
    }
}
