namespace TesteTecnico.Domain.Excecoes
{
    public class ConflitoAgendamentoException : Exception
    {
        public ConflitoAgendamentoException(string message) : base(message) { }
    }
}
