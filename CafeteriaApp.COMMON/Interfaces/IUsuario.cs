using CafeteriaApp.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaApp.COMMON.Interfaces
{
    public interface IUsuario:IGenericManager<Usuario>
    {
        Usuario Login(string nombreUsuario, string password);
    }
}
