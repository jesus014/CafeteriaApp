using CafeteriaApp.COMMON.Entidades;
using CafeteriaApp.DAL.MsSQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CafeteriaApp.Test.DAL.MsSQL
{
    [TestClass]
    public class PruebasDALSql
    {
        [TestMethod]

        public void TestTipoUsuario()
        {
            try
            {
                var repositorio = FabricRepository.TipoUsuario();
                int numAntes = repositorio.Read.Count();
                var dato = repositorio.Create(new TipoUsuario()
                {
                    Nombre="test",
                    Descripcion="master"
                });
                Assert.IsNotNull(dato, "No se pudo crear el objeto"+ repositorio.Error);
                dato.Nombre = "Modificado";
                dato.Descripcion = "Modificada";
                var datoModificado = repositorio.Update(dato);
                Assert.IsNotNull(datoModificado, "No se modifico el dato" + repositorio.Error);
                Assert.AreEqual(dato.Nombre, datoModificado.Nombre);
                Assert.IsTrue(repositorio.Delete(datoModificado.Id));
                Assert.AreEqual(numAntes, repositorio.Read.Count(), "La cantidad de registros despues del crud no es igual");
            }
            catch (System.Exception ex)
            {

                Assert.Fail(ex.Message);
            }
        }
    }
}
