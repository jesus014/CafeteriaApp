using CafeteriaApp.COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaApp.COMMON.Validadores
{
    public class ElementoEnPaqueteValidator:GenericValidator<ElementoEnPaquete>
    {
        public ElementoEnPaqueteValidator()
        {
            RuleFor(e => e.Cantidad).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(e => e.Descripcion).NotNull().NotEmpty().MaximumLength(2000);
            RuleFor(e => e.Foto).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(e => e.IdMenuComidaCorrida).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(e => e.IdPaquete).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(e => e.IdProducto).NotNull().NotEmpty().MaximumLength(50);


        }
    }
}
