using CafeteriaApp.COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaApp.COMMON.Validadores
{
    public class MenuComidaCorridaValidator: GenericValidator<MenuComidaCorrida>
    {
        public MenuComidaCorridaValidator()
        {
            RuleFor(m => m.Costo).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(m => m.Descripcion).NotNull().NotEmpty();
            RuleFor(m => m.EstaEnVenta).NotNull().NotEmpty();
            RuleFor(m => m.Foto).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(m => m.Nombre).NotEmpty().NotNull().MaximumLength(100);
        }
    }
}
