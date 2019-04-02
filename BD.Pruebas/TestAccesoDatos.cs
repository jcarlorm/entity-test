using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BD.entity;
using System.Collections.Generic;
using System.Xml;
using AutoMapper;
using BD.Pruebas.Empleado;
using BD.Pruebas.EmpleadoView;

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

            Empleado.Empleado employee = new Empleado.Empleado
            {
                Name = "John SMith",
                Email = "john@codearsenal.net",
                Address = new Address
                {
                    Country = "USA",
                    City = "New York",
                    Street = "Wall Street",
                    Number = 7
                },
                Position = "Manager",
                Gender = true,
                Age = 35,
                YearsInCompany = 5,
                StartDate = new DateTime(2007, 11, 2)
            };

            Mapper.Initialize(cfg => {
                cfg.CreateMap<Empleado.Empleado, EmpleadoView.Empleado>()
                    .ForMember(ev => ev.Address,
                               m => m.MapFrom(a => a.Address.City + ", " +
                                                   a.Address.Street + " " +
                                                   a.Address.Number)
                              )
                   .ForMember(dest => dest.Gender,
                               m => m.MapFrom<GenderResolver>())
                   .ForMember(dest => dest.StartDate, m => m.MapFrom<DateFormatter>());
            });

            var model = Mapper.Map<EmpleadoView.Empleado>(employee);
        

        }
    }

   

    public class GenderResolver : IValueResolver<Empleado.Empleado, EmpleadoView.Empleado, string>
    {
        public string Resolve(Empleado.Empleado source, EmpleadoView.Empleado destination, string destMember, ResolutionContext context)
        {
            return source.Gender ? "Man" : "Female";
        }
    }

    public class DateFormatter : IValueResolver<Empleado.Empleado, EmpleadoView.Empleado , string>
    {
        public string Resolve(Empleado.Empleado source, EmpleadoView.Empleado destination, string destMember, ResolutionContext context)
        {
            return source.StartDate.ToShortDateString();
        }
    }
}
