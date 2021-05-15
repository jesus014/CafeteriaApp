using CafeteriaApp.COMMON.Entidades;
using CafeteriaApp.COMMON.Interfaces;
using CafeteriaApp.DAL.MsSQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
                    Nombre = "test",
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

        [TestMethod]

        public void TestCategoriaDeProducto()
        {
            try
            {
                var repositorio = FabricRepository.CategoriaDeProducto();
                int numAntes = repositorio.Read.Count();
                var dato = repositorio.Create(new CategoriaDeProducto()
                {
                    Nombre = "Prueba Unitaria",
                    Descripcion = "master"
                });
                Assert.IsNotNull(dato, "No se pudo crear el objeto" + repositorio.Error);
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

        [TestMethod]

        public void TestElementoEnMenu()
        {
            try
            {
                var repositorioMenu = FabricRepository.MenuComidaCorrida();
                var repositorioProducto = FabricRepository.Producto();
                var repositorioCategoria = FabricRepository.CategoriaDeProducto();
                var repositorioElementoEnMenu = FabricRepository.ElementosEnMenu();

                var menu = repositorioMenu.Create(new MenuComidaCorrida()
                {
                    Costo = 45,
                    Descripcion = "Menu de prueba rapida",
                    EstaEnVenta = true,
                    Foto = "prueba.png",
                    Nombre="plato"
                });
                var categoria = repositorioCategoria.Create(new CategoriaDeProducto()
                {
                    Descripcion="prueba",
                    Nombre="prueba"
                });
                var producto = repositorioProducto.Create(new Producto()
                {
                    Stock = 20,
                    Costo = 25,
                    Descripcion = "producto",
                    EsPreparado = true,
                    EstaEnVenta = true,
                    Foto = "fotodeprueba",
                    IdCategoria = categoria.Id,
                    Nombre = "prueba"

                });
                int numAntes = repositorioElementoEnMenu.Read.Count();

                var elementoEnMenu = repositorioElementoEnMenu.Create(new ElementosEnMenu()
                {
                    IdMenuComidaCorrida = menu.Id,
                    IdProducto=producto.Id
                });
                Assert.IsNotNull(elementoEnMenu, "No se pudo crear el objeto" + repositorioElementoEnMenu.Error);
                var producto2 = repositorioProducto.Create(new Producto()
                {
                    Stock = 10,
                    Costo = 10,
                    Descripcion = "otro producto",
                    EsPreparado = true,
                    EstaEnVenta = true,
                    Foto = "otro.jpg",
                    IdCategoria = categoria.Id,
                    Nombre = "otro producto"
                });
                elementoEnMenu.IdProducto = producto2.Id;
                var elementoModificado = repositorioElementoEnMenu.Update(elementoEnMenu);
                Assert.IsNotNull(elementoModificado, "no se modifico el elemento en menu" + repositorioElementoEnMenu.Error);
                Assert.IsTrue(repositorioElementoEnMenu.Delete(elementoModificado.Id), "no se puede eliminar" + repositorioElementoEnMenu.Error);
                Assert.AreEqual(numAntes, repositorioElementoEnMenu.Read.Count());
                Assert.IsTrue(repositorioProducto.Delete(producto2.Id), "no se puede eleminiar el producto 2" + repositorioProducto.Error);
                Assert.IsTrue(repositorioProducto.Delete(producto.Id), "no se puede eleminiar el producto 1" + repositorioProducto.Error);
                Assert.IsTrue(repositorioCategoria.Delete(categoria.Id), "no se puede eleminiar el producto 1" + repositorioCategoria.Error);
                Assert.IsTrue(repositorioMenu.Delete(menu.Id), "no se puede eleminiar el menu" + repositorioMenu.Error);

               
            }
            catch (System.Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        [TestMethod]

        public void TestMenuComidaCorrida()
        {
            try
            {
                var repositorio = FabricRepository.MenuComidaCorrida();
                int numAntes = repositorio.Read.Count();
                var menu = repositorio.Create(new MenuComidaCorrida()
                {
                    Costo = 1,
                    Descripcion = "Menu de prueba rapida",
                    EstaEnVenta = true,
                    Foto = "prueba.png",
                    Nombre = "plato"
                });
                Assert.IsNotNull(menu, "No se pudo crear el objeto" + repositorio.Error);
                menu.Nombre = "modificado";
                menu.Descripcion = "modificado";
                var datoModificado = repositorio.Update(menu);
                Assert.IsNotNull(datoModificado, "no se modifico el elemento en menu" + repositorio.Error);
                Assert.AreEqual(menu.Nombre,datoModificado.Nombre);
                Assert.IsTrue(repositorio.Delete(datoModificado.Id));
                Assert.AreEqual(numAntes, repositorio.Read.Count(), "la cantidad");


            }
            catch (System.Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]

        public void TestPaquete()
        {
            try
            {
                var repositorio = FabricRepository.Paquete();
                int numAntes = repositorio.Read.Count();
                var dato = repositorio.Create(new Paquete()
                {
                    Costo=15,
                    Descripcion="Paquete de prueba",
                    EstaEnVenta=true,
                    Nombre="plato"
                });
                Assert.IsNotNull(dato, "No se pudo crear el objeto" + repositorio.Error);
                dato.Nombre = "modificado";
                dato.Descripcion = "modificado";
                var datoModificado = repositorio.Update(dato);
                Assert.IsNotNull(datoModificado, "no se modifico el elemento en menu" + repositorio.Error);
                Assert.AreEqual(dato.Nombre, datoModificado.Nombre);
                Assert.IsTrue(repositorio.Delete(datoModificado.Id));
                Assert.AreEqual(numAntes, repositorio.Read.Count(), "la cantidad");


            }
            catch (System.Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        
        [TestMethod]

        public void TestProductoEnVenta()
        {
            try
            {
                var repositorio = FabricRepository.ProductosEnVenta();
               // int numAntes = repositorio.Read.Count();
                
                var menu = FabricRepository.MenuComidaCorrida().Create(new MenuComidaCorrida()
                {
                    Costo = 15,
                    Descripcion = "Paquete de prueba",
                    EstaEnVenta = true,
                    Foto = "fads",
                    Nombre = "plato"
                  
                   
                });
                var categoria =FabricRepository.CategoriaDeProducto().Create(new CategoriaDeProducto()
                {
                    Nombre = "Prueba Unitaria",
                    Descripcion = "master"
                });
                var producto = FabricRepository.Producto().Create(new Producto()
                {
                    Stock = 20,
                    Costo = 25,
                    Descripcion = "producto",
                    EsPreparado = true,
                    EstaEnVenta = true,
           
                    Foto = "fotodeprueba",
                    IdCategoria = categoria.Id,
                    Nombre = "prueba"
                });

                var tCliente = FabricRepository.TipoUsuario().Create(new TipoUsuario()
                {
                    Descripcion="clliente",
                    Nombre="cliente",
                });
                IGenericRepository<Usuario> FabricUsuario = FabricRepository.Usuario();
                var cliente = FabricUsuario.Create(new Usuario()
                {
                    Apellidos = "cliente",
                    Correo = "cliente@hotmail.com",
                    Credito = 300,
                    Foto = "vsd",
                    IdTipoUsuario = tCliente.Id,
                    Nombre = "cliente",
                    NombreUsuario = "cliente1",
                    Notas = "prueba",
                    Password = "sadas",
                    Telefono = "1234"
                });
                //Assert.IsNull(cliente, FabricUsuario.Error);
                var vendedor = FabricRepository.Usuario().Create(new Usuario()
                {
                    Apellidos = "vendedor",
                    Correo = "vendedor@hotmail.com",
                    Nombre = "cliente",
                    IdTipoUsuario=tCliente.Id,
                    Foto="ds",
                    NombreUsuario = "vendedor",
                    Notas = "prueba",
                    Password = "sadas",
                    Telefono = "1234"
                });

                var venta = FabricRepository.Venta().Create(new Venta()
                {
                    EsVentaMovil = false,
                    IdCliente = cliente.Id,
                    IdVendedor=vendedor.Id,
                    MontoTotal=35,
                    FechaHora=DateTime.Now
                });
                int numAntes = repositorio.Read.Count();
                var dato = repositorio.Create(new ProductosEnVenta()
                {
                    Cantidad=1,
                    Costo=35,
                    Entregado=true,
                    Preparado=true,
                    Preparando=false,
                    IdProducto=producto.Id,
                    IdVenta=venta.Id

                });
                Assert.IsNotNull(dato, "No se pudo crear el objeto" + repositorio.Error);
                dato.Preparado = false;
                var datoModificado = repositorio.Update(dato);
                Assert.IsNotNull(datoModificado, "no se modifico el elemento en menu" + repositorio.Error);
                Assert.AreEqual(dato.Preparado, datoModificado.Preparado);
                Assert.IsTrue(repositorio.Delete(datoModificado.Id));
                Assert.AreEqual(numAntes, repositorio.Read.Count(), "la cantidad");
                Assert.IsTrue(FabricRepository.Venta().Delete(venta.Id), "error al eliminar venta");
                Assert.IsTrue(FabricRepository.Usuario().Delete(vendedor.Id), "error al eliminar vendedor");
                Assert.IsTrue(FabricRepository.Usuario().Delete(cliente.Id), "error al eliminar vendedor");
                Assert.IsTrue(FabricRepository.TipoUsuario().Delete(tCliente.Id), "error al eliminar vendedor");
                Assert.IsTrue(FabricRepository.Producto().Delete(producto.Id), "error al eliminar vendedor");
                Assert.IsTrue(FabricRepository.CategoriaDeProducto().Delete(categoria.Id), "error al eliminar vendedor");
                Assert.IsTrue(FabricRepository.MenuComidaCorrida().Delete(menu.Id), "error al eliminar vendedor");



            }
            catch (System.Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void TestUsuario()
        {
            try
            {
                var repositorio = FabricRepository.Usuario();
                int numAntes = repositorio.Read.Count();
                var tipo = FabricRepository.TipoUsuario().Create(new TipoUsuario()
                {
                   Descripcion="prueba",
                   Nombre="Prueba"
                });
                var dato = repositorio.Create(new Usuario()
                {
                    Apellidos = "cliente",
                    Correo = "user@hotmail.com",
                    Credito = 300,
                    Foto = "vsd",
                    IdTipoUsuario = tipo.Id,
                    Nombre = "cliente",
                    NombreUsuario = "cliente1",
                    Password = "sadas",
                    Telefono = "1234"
                });
                Assert.IsNotNull(dato, "No se pudo crear el objeto" + repositorio.Error);
                dato.Nombre = "modificado";
                var datoModificado = repositorio.Update(dato);
                Assert.IsNotNull(datoModificado, "no se modifico el elemento en menu" + repositorio.Error);
                Assert.AreEqual(dato.Nombre, datoModificado.Nombre);
                Assert.IsTrue(repositorio.Delete(datoModificado.Id));
                Assert.AreEqual(numAntes, repositorio.Read.Count(), "la cantidad");
                Assert.IsTrue(FabricRepository.TipoUsuario().Delete(tipo.Id), "no se elimino el usuario");


            }
            catch (System.Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void TestVenta()
        {
            try
            {
                var repositorio = FabricRepository.Venta();
                //int numAntes = repositorio.Read.Count();
                var tCliente = FabricRepository.TipoUsuario().Create(new TipoUsuario()
                {
                    Descripcion = "prueba",
                    Nombre = "Prueba"
                }); 
                var tVendedor = FabricRepository.TipoUsuario().Create(new TipoUsuario()
                {
                    Descripcion = "vendedor",
                    Nombre = "vendedor"
                });
                var cliente = FabricRepository.Usuario().Create(new Usuario()
                {
                    Apellidos = "cliente",
                    Correo = "cliente@hotmail.com",
                    Credito = 300,
                    Foto = "vsd",
                    IdTipoUsuario = tCliente.Id,
                    Nombre = "cliente",
                    NombreUsuario = "cliente1",
                    Notas = "prueba",
                    Password = "sadas",
                    Telefono = "1234"
                });
                var vendedor = FabricRepository.Usuario().Create(new Usuario()
                {
                    Apellidos = "cliente",
                    Correo = "cliente@hotmail.com",
                    Credito = 300,
                    Foto = "vsd",
                    IdTipoUsuario = tCliente.Id,
                    Nombre = "cliente",
                    NombreUsuario = "Vendedor4",
                    Notas = "prueba",
                    Password = "sadas",
                    Telefono = "1234"
                });
                int numAntes = repositorio.Read.Count();
                var dato = repositorio.Create(new Venta()
                {
                    EsVentaMovil=false,
                    FechaHora=DateTime.Now,
                    IdCliente=cliente.Id,
                    IdVendedor=vendedor.Id,
                    MontoTotal=600
                });
                Assert.IsNotNull(dato, "No se pudo crear el objeto" + repositorio.Error);
                dato.MontoTotal = 3;
                var datoModificado = repositorio.Update(dato);
                Assert.IsNotNull(datoModificado, "no se modifico el elemento en menu" + repositorio.Error);
                Assert.AreEqual(dato.MontoTotal, datoModificado.MontoTotal);
                Assert.IsTrue(repositorio.Delete(datoModificado.Id));
                Assert.AreEqual(numAntes, repositorio.Read.Count(), "la cantidad");
                Assert.IsTrue(FabricRepository.Usuario().Delete(vendedor.Id), "no se elimino el usuario");
                Assert.IsTrue(FabricRepository.Usuario().Delete(cliente.Id), "no se elimino el usuario");
                Assert.IsTrue(FabricRepository.TipoUsuario().Delete(tCliente.Id), "no se elimino el usuario");
                Assert.IsTrue(FabricRepository.TipoUsuario().Delete(tVendedor.Id), "no se elimino el usuario");


            }
            catch (System.Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
