using CafeteriaApp.COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaApp.COMMON.Validadores
{
    public class TipoUsuarioValidator:GenericValidator<TipoUsuario>
    {
        public TipoUsuarioValidator()
        {
            RuleFor(t => t.Descripcion).NotNull().NotEmpty().MaximumLength(200);
            RuleFor(t => t.Nombre).NotNull().NotEmpty().MaximumLength(50);

        }
    }
}
