using CafeteriaApp.COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaApp.COMMON.Validadores
{
    public class PaqueteValidator:GenericValidator<Paquete>
    {
        public PaqueteValidator()
        {
            RuleFor(p => p.Descripcion).NotNull().NotEmpty();
            RuleFor(p => p.Costo).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(p => p.EstaEnVenta).NotNull().NotEmpty();
            RuleFor(p => p.Nombre).NotNull().NotEmpty().MaximumLength(100);
        }
    }
}
