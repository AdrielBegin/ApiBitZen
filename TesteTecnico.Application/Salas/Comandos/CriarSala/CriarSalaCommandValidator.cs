using FluentValidation;

namespace TesteTecnico.Application.Salas.Comandos.CriarSala
{
    public class CriarSalaCommandValidator : AbstractValidator<CriarSalaCommand>
    {
        public CriarSalaCommandValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().MaximumLength(100);
            RuleFor(x => x.CapacidadeMaxima).GreaterThan(0);
        }
    }
}
