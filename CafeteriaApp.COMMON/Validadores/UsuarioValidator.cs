using CafeteriaApp.COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaApp.COMMON.Validadores
{
    public class UsuarioValidator:GenericValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(u => u.Apellidos).NotNull().MaximumLength(50).NotEmpty();
            RuleFor(u => u.Correo).NotNull().MaximumLength(50).NotEmpty().EmailAddress();
            RuleFor(u => u.Credito).GreaterThanOrEqualTo(0);
            RuleFor(u => u.Foto).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(u => u.IdTipoUsuario).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(u => u.Nombre).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(u => u.NombreDeUsuario).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(u => u.Notas).NotNull().NotEmpty();
            RuleFor(u => u.Password).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(u => u.Telefono).NotNull().NotEmpty().MaximumLength(10);
        }
    }
}
