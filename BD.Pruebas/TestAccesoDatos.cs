using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BD.entity;
using System.Collections.Generic;

namespace BD.Pruebas
{
    [TestClass]
    public class TestAccesoDatos
    {
        AccesoDatos conexion = new AccesoDatos();


        [TestMethod]
        public void TestObtieneFacturaElectronicaParametros()
        {

            List<admin_factura_electronica> facturaElectronica = conexion.ObtieneInformacionFacturaElectronica();
            
            Assert.IsTrue(facturaElectronica.Count > 0);

        }

        [TestMethod]
        public void TestObtieneListarCoche()
        {
            List<ListarCoche> listaCoches = conexion.ObtieneListarCoches();
            Assert.IsTrue(listaCoches.Count > 0);
        }
    }
}
