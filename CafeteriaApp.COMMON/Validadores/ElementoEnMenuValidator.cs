using CafeteriaApp.COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaApp.COMMON.Validadores
{
   public class ElementoEnMenuValidator: GenericValidator<ElementosEnMenu>
    {
        public ElementoEnMenuValidator()
        {
            RuleFor(e => e.IdMenuComidaCorrida).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(e => e.IdProducto).NotNull().NotEmpty().MaximumLength(50);

        }
    }
}
