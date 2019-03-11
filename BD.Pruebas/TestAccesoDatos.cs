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
        public void TestListarCoche()
        {
            List<ListarCoche> listaCoches = conexion.ObtieneInformacionListarCoche();

            Assert.IsTrue(listaCoches.Count > 0);
        }

        [TestMethod]
        public void TestAgregarBitacora()
        {
            Bitacora evento = new Bitacora();
            evento.evento = "Evento de prueba";
            evento.metodo = "metodo de prueba";

            conexion.RegistrarBitacora(evento);

        }
    }
}
