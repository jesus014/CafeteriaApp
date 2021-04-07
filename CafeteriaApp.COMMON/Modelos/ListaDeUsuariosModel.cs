using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaApp.COMMON.Modelos
{
    public class ListaDeUsuariosModel:AbstractModel
    {
        public string TipoDeUsuario { get; set; }
        
        public string NombreDeUsuario { get; set; }
        
        public string Nombre { get; set; }
        
        public decimal Credito { get; set; }
    }
}
