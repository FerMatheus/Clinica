using CL.Core.InputModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Manager.Validation;

public class AlteraClienteValidator : AbstractValidator<AlteraCliente>
{
    public AlteraClienteValidator()
    {
        RuleFor(clienteAlterado => clienteAlterado.Id).NotNull().NotEmpty().GreaterThan(0);
        Include(new NovoClienteValidator());
    }
}
