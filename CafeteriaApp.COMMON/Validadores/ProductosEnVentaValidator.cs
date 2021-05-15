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
           
            RuleFor(p => p.IdVenta).NotNull().NotEmpty().MaximumLength(50);
           
        }
    }
}
