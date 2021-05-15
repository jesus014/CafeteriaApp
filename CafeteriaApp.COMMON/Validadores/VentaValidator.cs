using CafeteriaApp.COMMON.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaApp.COMMON.Validadores
{
    public class VentaValidator:GenericValidator<Venta>
    {
        public VentaValidator()
        {
            RuleFor(v => v.EsVentaMovil).NotNull();
            RuleFor(v => v.FechaHora).NotNull().NotEmpty();
            RuleFor(v => v.IdCliente).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(v => v.IdVendedor).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(v => v.MontoTotal).NotNull().NotEmpty().GreaterThan(0);



        }
    }
}
