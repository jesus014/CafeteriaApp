using CafeteriaApp.COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaApp.COMMON.Validadores
{
    public class ProductoValidator:GenericValidator<Producto>
    {
        public ProductoValidator()
        {
            RuleFor(p => p.Costo).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(p => p.Descripcion).NotNull().NotEmpty();
            RuleFor(p => p.EstaEnVenta).NotNull().NotEmpty();
            RuleFor(p => p.EsPreparado).NotNull().NotEmpty();
            RuleFor(p => p.Foto).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(p => p.IdCategoria).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(p => p.Nombre).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(p => p.Stock).NotNull().NotEmpty().GreaterThanOrEqualTo(0);


        }
    }
}
