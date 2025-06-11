namespace TesteTecnico.Domain.Excecoes
{
    public class ValidacaoException : Exception
    {
        public ValidacaoException(string message) : base(message) { }
    }
}
