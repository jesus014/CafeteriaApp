using CafeteriaApp.COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaApp.COMMON.Validadores
{
    public class CategoriaDeProductoValidator:GenericValidator<CategoriaDeProducto>
    {
        public CategoriaDeProductoValidator()
        {
            RuleFor(c => c.Descripcion).NotEmpty().NotNull().WithMessage("la descripcion no puede quedar vacia").MaximumLength(200);
            RuleFor(c => c.Nombre).NotNull().MaximumLength(50).NotEmpty();

        }
    }
}
