using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BD.entity;
using System.Collections.Generic;
using System.Xml;
using AutoMapper;

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

        [TestMethod]
        public void RecorrerXML()
        {   
            string ruta = @"c:\Users\jcrojas\Desktop\errores.xml";
            string xmlErrores = System.IO.File.ReadAllText(ruta);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlErrores);


            XmlNodeList errorNodes = doc.GetElementsByTagName("Error");
            List<object> errores = new List<object>();

            foreach (XmlNode errorNode in errorNodes)
            {
                Mensaje error = new Mensaje() {
                    IdRegistro = errorNode.Attributes["IdRegistro"].Value,
                    DetalleMotivo = errorNode.Attributes["Motivo"].Value,
                    Detalle = errorNode.Attributes["Detalle"].Value
                };

                errores.Add(error);
            }

            List<string> listaRespuesta = errores.ConvertAll(input => input.ToString()); ;

            string lista = string.Join(",", listaRespuesta.ToArray());
        }


        public class Mensaje
        {
            public string IdRegistro { get; set; }
            public string DetalleMotivo { get; set; }
            public string Detalle { get; set; }

            public override string ToString()
            {
                return Detalle; 
            }
        }
        [TestMethod]
        public void Mapeo()
        {

        }
    }
    
}
