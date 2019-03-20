using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using PELom.REP.BS;

using System.Collections.Generic;
using PELom.REP.BE;

namespace PELom.REP.Pruebas
{
    [TestClass]
    public class Repositorio
    {
        
        [TestMethod]
        public void AgregarFTP()
        {
            string fileName1 = @"C:\Users\fsanchez\Desktop\Caja de Ande\caja ande requerido.txt";
            string fileName2 = @"C:\Users\fsanchez\Desktop\Caja de Ande\Guia Instalación Cliente VPN Remoto.pdf";


            byte[] archivo1 = FileToByteArray(fileName1);
            byte[] archivo2 = FileToByteArray(fileName2);


            ManejadorArchivos manejador = new ManejadorArchivos();
            Archivo arch = new Archivo();
            List<Archivo> lista = new List<Archivo>();
            Configuracion configura = new Configuracion();
            configura.CodTipoConfiguracion = PELib.Enumerados.REP.TipoConfiguracion.FTP;
            configura.Usuario = "Fabi";
            configura.Clave = "fabia123";
            configura.URL = "ftp://127.0.0.1/";
            configura.IdConfiguracion = 1;
                
            arch.Bytes = archivo1;
            arch.ExtensionArchivo = "txt";
            arch.NombreArchivo = "caja ande requerido";
            arch.MimeType = "plain/txt";
            arch.CodEstado = 1;
            arch.IdObjeto = 11;

            lista.Add(arch);
            arch = new Archivo();

            arch.Bytes = archivo2;
            arch.ExtensionArchivo = "pdf";
            arch.NombreArchivo = "Guia Instalación Cliente VPN Remoto";
            arch.MimeType = "application/pdf";
            arch.CodEstado = 1;
            arch.IdObjeto = 11;
            lista.Add(arch);

            bool respuesta =   manejador.AlmacenarArchivo(lista.ToArray(), configura);
            RespuestaRetorno r = new RespuestaRetorno();
            Assert.IsTrue(respuesta);
            return;
            

        }

        public byte[] FileToByteArray(string fileName)
        {
            try
            {
                
                byte[] fileData = null;

                using (FileStream fs = File.OpenRead(fileName))
                {
                    using (BinaryReader binaryReader = new BinaryReader(fs))
                    {
                        fileData = binaryReader.ReadBytes((int)fs.Length);
                    }
                }
                return fileData;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [TestMethod]
        public void ConsultarArchivos()
        {
            ManejadorArchivos manejador = new ManejadorArchivos();
            Configuracion configura = new Configuracion();
            string[] codArchivoDato = new string[1];
            configura.CodTipoConfiguracion = PELib.Enumerados.REP.TipoConfiguracion.FTP;

            switch (configura.CodTipoConfiguracion)
            {
                case PELib.Enumerados.REP.TipoConfiguracion.WS:
                    configura.IdConfiguracion = 1;
                    configura.URL = "http://localhost/SimuladorRepositorioWcf/Service1.svc,http://tempuri.org/IService1/ObtenerArchivo"; /*"http://localhost/SimuladorRepositorio/ArchivoRepositorio.asmx";*/
                    codArchivoDato[0] = "1";
                    break;
                case PELib.Enumerados.REP.TipoConfiguracion.BD:
                    configura.IdConfiguracion = 2;
                    configura.URL = "Data Source=127.0.0.1;Initial Catalog=PELRepositorioArchivos;Pooling=False;User Id=PEL-IB_USR;Password=Pel123123*";
                    codArchivoDato[0] = "1";
                    break;
                case PELib.Enumerados.REP.TipoConfiguracion.DFS:

                    configura.IdConfiguracion = 4;
                    configura.RequiereImpersonalizar = true;
                    configura.Puerto = "2,0";
                    configura.Usuario = "fsanchez";
                    configura.Clave = "Fabian84";
                    configura.URL = "//peldatos/IngSoftware/Base Datos";
                    codArchivoDato[0] = "//peldatos/IngSoftware/Base Datos/caja ande requerido.txt";

                    break;
                case PELib.Enumerados.REP.TipoConfiguracion.FTP:
                    configura.IdConfiguracion = 1;
                    configura.Usuario = "Fabi";
                    configura.Clave = "fabia123";
                    configura.URL = "ftp://127.0.0.1/";
                    codArchivoDato[0] = "ftp://127.0.0.1/caja ande requerido.txt";
                    break;
                default:
                    break;
            }

            

           var  arc = manejador.ConsultarArchivos(codArchivoDato, configura);
            Assert.IsNotNull(arc);
            return;
        }

        [TestMethod]
        public void AgregarBD()
        {
            string fileName1 = @"C:\Users\fsanchez\Desktop\Caja de Ande\caja ande requerido.txt";
            ManejadorArchivos manejador = new ManejadorArchivos();
            Configuracion configura = new Configuracion();
            configura.CodTipoConfiguracion = PELib.Enumerados.REP.TipoConfiguracion.BD;
            configura.IdConfiguracion = 2;
            configura.URL = "Data Source=127.0.0.1;Initial Catalog=PELRepositorioArchivos;Pooling=False;User Id=PEL-IB_USR;Password=Pel123123*";
            List<Archivo> lista = new List<Archivo>();
            Archivo arch = new Archivo();
            byte[] archivo = FileToByteArray(fileName1);
            
            arch.Bytes = archivo;
            arch.ExtensionArchivo = "txt";
            arch.NombreArchivo = "caja ande requerido";
            arch.MimeType = "plain/txt";
            arch.CodEstado = (int)PELib.Enumerados.NBS.EstadoArchivos.Registrado;
            arch.IdObjeto = 33;
            arch.Contenido = System.Text.Encoding.UTF8.GetString(arch.Bytes);
            arch.URl = @"C:\Users\fsanchez\Desktop\Caja de Ande\caja ande requerido.txt";
            lista.Add(arch);
           bool respuesta =manejador.AlmacenarArchivo(lista.ToArray(), configura);
            Assert.IsTrue(respuesta);
            return;

        }
        [TestMethod]
        public void AgregarDFS()
        {
            string fileName1 = @"C:\Users\fsanchez\Desktop\Caja de Ande\caja ande requerido.txt";
            ManejadorArchivos manejador = new ManejadorArchivos();
            Configuracion configura = new Configuracion();
            configura.CodTipoConfiguracion = PELib.Enumerados.REP.TipoConfiguracion.DFS;
            configura.IdConfiguracion = 4;
            configura.URL = "//peldatos/IngSoftware/Base Datos";
            configura.Usuario = "fsanchez";
            configura.Clave = "Fabian84";
            configura.RequiereImpersonalizar = true;
            configura.Puerto = "2,0";
            List<Archivo> lista = new List<Archivo>();
            Archivo arch = new Archivo();
            byte[] archivo = FileToByteArray(fileName1);

            arch.Bytes = archivo;
            arch.ExtensionArchivo = "txt";
            arch.NombreArchivo = "caja ande requerido";
            arch.MimeType = "plain/txt";
            arch.CodEstado = (int)PELib.Enumerados.NBS.EstadoArchivos.Registrado;
            arch.IdObjeto = 33;        
            lista.Add(arch);
            bool respuesta = manejador.AlmacenarArchivo(lista.ToArray(), configura);
            Assert.IsTrue(respuesta);
            return;
        }
        [TestMethod]
        public void ConsultaConfiguracion()
        {
            ManejadorArchivos manejador = new ManejadorArchivos();
           
            var configura = manejador.ConsultarConfiguracion(4);
            Assert.IsNotNull(configura);
            return;
        }
        [TestMethod]
        public void AgregarWS()
        {
            ManejadorArchivos manejador = new ManejadorArchivos();

            Configuracion configura = new Configuracion();
            configura.CodTipoConfiguracion = PELib.Enumerados.REP.TipoConfiguracion.WS;
            configura.IdConfiguracion = 1;
            string fileName1 = @"C:\Users\fsanchez\Desktop\Caja de Ande\caja ande requerido.txt";
            // los dos url presentados son uno para asmx y el otro wcf 

            configura.URL = /*"http://localhost/SimuladorRepositorio/ArchivoRepositorio.asmx";*/ "http://localhost/SimuladorRepositorioWcf/Service1.svc,http://tempuri.org/IService1/EnvioArchivo";           
            configura.RequiereImpersonalizar = false;
            List<Archivo> lista = new List<Archivo>();
            Archivo arch = new Archivo();
            byte[] archivo = FileToByteArray(fileName1);

            string base64 = Convert.ToBase64String(archivo);

            arch.Bytes = archivo;
            arch.ExtensionArchivo = "txt";
            arch.NombreArchivo = "caja ande requerido";
            arch.MimeType = "plain/txt";
            arch.CodEstado = (int)PELib.Enumerados.NBS.EstadoArchivos.Registrado;
            arch.IdObjeto = 33;
            lista.Add(arch);
            bool respuesta = manejador.AlmacenarArchivo(lista.ToArray(), configura);
            Assert.IsTrue(respuesta);
            return;
        }


    }
}
