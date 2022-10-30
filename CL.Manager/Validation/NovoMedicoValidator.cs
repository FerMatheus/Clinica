using CL.Core.ModelViews.Medico;
using FluentValidation;

namespace CL.Manager.Validation;

public class NovoMedicoValidator : AbstractValidator<NovoMedico>
{
	public NovoMedicoValidator()
	{
		RuleFor(m => m.Nome).NotNull()
			.NotEmpty()
			.MinimumLength(7)
			.MaximumLength(100);
		RuleFor(m => m.CRM).NotNull()
			.NotEmpty()
			.GreaterThan(0);
	}
}
