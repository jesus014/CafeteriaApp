using System;
using System.Collections.Generic;
using System.Text;
using CafeteriaApp.COMMON.Entidades;
using FluentValidation;

namespace CafeteriaApp.COMMON.Validadores
{
    public abstract class GenericValidator<T>: AbstractValidator <T> where T:BaseDTO
    {
        public GenericValidator()
        {
            RuleFor(c => c.Id).NotNull().NotEmpty().MaximumLength(50).WithMessage("EL valor del Id no puede ser nulo o exceder de 50 caracteres");

        }
    }
}
