using CL.Core.InputModel;
using FluentValidation;

namespace CL.Manager.Validation;

public class NovoClienteValidator : AbstractValidator<NovoCliente>
{
    public NovoClienteValidator()
    {
        RuleFor(novoCliente => novoCliente.Nome).NotNull().NotEmpty()
            .MinimumLength(7)
            .MaximumLength(100);
        RuleFor(novoCliente => novoCliente.Nascimento).NotNull().NotEmpty()
            .LessThan(DateTime.Now)
            .GreaterThan(DateTime.Now.AddYears(-120))
            .WithMessage("Seu nascimento deve ser inferior à data de hoje, e você não pode ter mais que 120 anos.");
        RuleFor(novoCliente => novoCliente.Sexo).NotNull().NotEmpty()
            .Must(Testa)
            .WithMessage("O sexo deve ser M ou F");
        RuleFor(novoCliente => novoCliente.Telefone).NotNull().NotEmpty()
            .Matches("[2-9]{2}-([0-9]{8}|[0-9]{9})")
            .WithMessage("O telefone deve obdecer  o formato XX-XXXXXXXX ou XX-XXXXXXXXX");
        RuleFor(novoCliente => novoCliente.Documento).NotNull().NotEmpty()
            .MinimumLength(7)
            .MaximumLength(15);
    }

    private bool Testa(char sexo)
    {
        return sexo == 'M' || sexo == 'F';
    }
}
