using FluentValidation;

namespace TesteTecnico.Application.Usuarios.Comandos.CriarUsuario
{
    public class CriarUsuarioCommandValidator : AbstractValidator<CriarUsuarioCommand>
    {
        public CriarUsuarioCommandValidator()
        {
            RuleFor(x => x.Usuario.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(100);

            RuleFor(x => x.Usuario.Email)
                .NotEmpty().WithMessage("Email é obrigatório.")
                .EmailAddress().WithMessage("Email inválido.");

            RuleFor(x => x.Usuario.Senha)
                .NotEmpty().WithMessage("Senha é obrigatória.")
                .MinimumLength(6).WithMessage("Senha deve ter no mínimo 6 caracteres.");
        }
    }
}
