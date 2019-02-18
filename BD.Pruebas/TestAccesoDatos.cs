using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BD.entity;
using System.Collections.Generic;

namespace BD.Pruebas
{
    [TestClass]
    public class TestAccesoDatos
    {
        [TestMethod]
        public void TestObtieneFacturaElectronicaParametros()
        {
            AccesoDatos conexion = new AccesoDatos();

            List<admin_factura_electronica> facturaElectronica = conexion.ObtieneInformacionFacturaElectronica();
            
            Assert.IsTrue(facturaElectronica.Count > 0);

        }
    }
}
