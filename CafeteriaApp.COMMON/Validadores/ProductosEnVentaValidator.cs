using CafeteriaApp.COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaApp.COMMON.Validadores
{
    public class ProductosEnVentaValidator:GenericValidator<ProductosEnVenta>
    {
        public ProductosEnVentaValidator()
        {
            RuleFor(p => p.Cantidad).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(p => p.Costo).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(p => p.Entregado).NotNull().NotEmpty();
            RuleFor(p => p.IdMenu).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(p => p.IdProducto).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(p => p.IdVenta).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(p => p.Preparado).NotNull().NotEmpty();
            RuleFor(p => p.Preparando).NotNull().NotEmpty();
        }
    }
}
