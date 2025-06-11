using System.Text.RegularExpressions;
using TesteTecnico.Domain.Excecoes;

namespace TesteTecnico.Domain.ValueObjects
{
    public record Email
    {
        public string Endereco { get; private set; }

        public Email(string endereco)
        {
            if (!ValidarEmail(endereco))
                throw new ValidacaoException("Email inválido.");

            Endereco = endereco;
        }

        private bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(email);
        }

        public override string ToString() => Endereco;
    }
}
