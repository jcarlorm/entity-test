using PELom.REP.BE;
using PELom.REP.BS.AccesoDatos;
using System;
using System.Collections.Generic;
using System.IO;

namespace PELom.REP.BS
{
    public class ManejadorArchivos
    {
        public bool AlmacenarArchivo(Archivo[] archivo, Configuracion configuracion, Action<Archivo> alCompletar = null,
            Action<Archivo, Exception> errorComunicacion = null, Action<Archivo, Exception> errorGeneral = null)
        {
            var medioEnvio = ACRepositorio.InstanciarCanal(configuracion);
            RespuestaRetorno respuesta = new RespuestaRetorno();

            bool firma = false;
            if (configuracion.RequiereFirma)
            {
               var firmaRespuesta =   ValidarFirmaArchivo(configuracion);
                firma = firmaRespuesta.EsValido;
            }

            medioEnvio.AlmacenajeCompletado = alCompletar;
            medioEnvio.ErrorComunicacion = errorComunicacion;
            medioEnvio.ErrorGeneral = errorGeneral;

            var respue = medioEnvio.SalvarArchivo(archivo, configuracion);
            respuesta.EsValido = respue.EsValido;
            respuesta.Mensaje = respue.Mensaje;

            return respuesta.EsValido;

        }
       
        public RespuestaRetorno<List<Archivo>> ConsultarArchivos(string[] codArchiDatos,Configuracion configuracion,
            Action<Archivo, Exception> errorComunicacion = null, Action<Archivo, Exception> errorGeneral = null)
        {
            var medioEnvio = ACRepositorio.InstanciarCanal(configuracion);
            
            medioEnvio.ErrorComunicacion = errorComunicacion;
            medioEnvio.ErrorGeneral = errorGeneral;
            var resp = medioEnvio.ObtenerArchivo(codArchiDatos, configuracion);

            return resp;
        }
        

        public RespuestaRetorno<Configuracion> ConsultarConfiguracion(int idConfiguracion)
        {
            RespuestaRetorno<Configuracion> respuesta = new RespuestaRetorno<Configuracion>()
            {
                Objeto = new Configuracion()
            };

            try
            {
                ADConfiguracion ADConfiguracion = new ADConfiguracion();
                respuesta.Objeto = ADConfiguracion.ObtenerConfiguracion(idConfiguracion);
                respuesta.EsValido = true;
            }
            catch (Exception ex)
            {
                respuesta.Excepcion = ex;
                respuesta.EsValido = false;
               
            }

            return respuesta;
        }

        public RespuestaRetorno ValidarFirmaArchivo(Configuracion configuracion)
        {
            RespuestaRetorno respuesta = new RespuestaRetorno();
            var medioEnvio = ACRepositorio.InstanciarCanal(configuracion);

            respuesta = medioEnvio.ValidarFirma(configuracion);

            return respuesta;

        }
    }
}
