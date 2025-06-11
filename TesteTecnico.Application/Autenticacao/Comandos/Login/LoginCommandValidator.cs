using FluentValidation;

namespace TesteTecnico.Application.Autenticacao.Comandos.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Senha).NotEmpty().MinimumLength(6);
        }
    }
}
