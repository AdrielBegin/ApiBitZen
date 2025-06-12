using TesteTecnico.Domain.Excecoes;

namespace TesteTecnico.Domain.ValueObjects
{
    public class HorarioReserva
    {
        public DateTime Inicio { get; private set; }
        public DateTime Fim { get; private set; }

        public HorarioReserva(DateTime inicio, DateTime fim)
        {
            if (fim <= inicio)
                throw new ValidacaoException("Horário final deve ser maior que horário inicial.");
            if (inicio.Date != fim.Date)
                throw new ValidacaoException("Reserva deve iniciar e finalizar no mesmo dia.");

            Inicio = inicio;
            Fim = fim;
        }
        public bool ConflitaCom(HorarioReserva outro)
        {
            return Inicio < outro.Fim && Fim > outro.Inicio;
        }
    }
}
