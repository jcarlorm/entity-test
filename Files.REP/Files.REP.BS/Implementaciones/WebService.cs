using System;
using System.Collections.Generic;
using System.Linq;
using PELom.REP.BE;
using PELib.Enumerados.NBS;
using PEL.NBS.Auditoria.SI.Datos;
using PEL.NBS.Auditoria;
using PEL.NBS.BS.Utilitarios;
using System.ServiceModel;
using PEL.NBS.AccesoRecursos;

namespace PELom.REP.BS.Implementaciones
{
    internal class WebService : ACRepositorio
    {
        AccesoDatos.ADArchivo ADArchivo = new AccesoDatos.ADArchivo();
        public class configuracionWeb
        {          
            public string soapAction { get; set; }
            public string ruta { get; set; }
        }


        public WebService()
        {

        }
        public override RespuestaRetorno<List<Archivo>> ObtenerArchivo(string[] codsArchivosDatos, Configuracion configuracion)
        {
            List<Archivo> listaArchivos = new List<Archivo>();
            var respuesta = new RespuestaRetorno<List<Archivo>>()
            {
                Objeto = new List<Archivo>()
            };

            Archivo archivo = null;
            Action<Exception> error = (ex) => {
                respuesta.Excepcion = ex;
                respuesta.EsValido = false;
                ex.Message.EntradaBitacora(TipoEvento.bitacora_TipoEvento_Error, ServicioPEL.REP);
            };
            try
            {

                var clienteREP = new PEL.NBS.AccesoCore.IEntidadREP.ClienteREP();
                configuracionWeb configura = ObtenerConfiguracionWeb(configuracion);
                foreach (string codArchivoDato in codsArchivosDatos)
                {
                     archivo = ADArchivo.ConsultarArchivo(codArchivoDato, configuracion.IdConfiguracion);
                    if (archivo != null)
                    {
                        var response = clienteREP.ObtenerArchivo(archivo.CodArchivoDatos, configura.ruta,configura.soapAction);
                        if (response != null)
                        {
                            archivo.Bytes = response.Bytes;
                            string contenido = System.Text.Encoding.UTF8.GetString(archivo.Bytes);
                            archivo.Contenido = contenido;
                            listaArchivos.Add(archivo);
                        }
                    }
                    else
                    {
                        respuesta.EsValido = false;
                        respuesta.Excepcion = new Exception(string.Format(Recursos.msgrep_MensajeErrorConsultar, codArchivoDato));
                        return respuesta;
                    }

                }

                respuesta.Objeto = listaArchivos;
                respuesta.EsValido = true;
            }
            catch(CommunicationException ex)
            {
                errorComunicacion?.Invoke(archivo, ex);
                error(ex);
            }
            catch (Exception ex)
            {
                errorGeneral?.Invoke(archivo, ex);
                error(ex);
            }

            return respuesta;
        }
        

        public override RespuestaRetorno SalvarArchivo(Archivo[] archivos, Configuracion configuracion)
        {

            RespuestaRetorno respuesta = new RespuestaRetorno();
            Archivo archivoCaptura = null;
            try
            {
                var clienteREP = new PEL.NBS.AccesoCore.IEntidadREP.ClienteREP();
                configuracionWeb configura = ObtenerConfiguracionWeb(configuracion);

                string msjBitacora = string.Empty;
                foreach (Archivo archivo in archivos)
                {
                    archivoCaptura = archivo;
                    var request = new PEL.NBS.AccesoCore.IEntidadREP.Request.ArchivoRequest()
                    {
                        NombreArchivo = archivo.NombreArchivo,
                        ExtensionArchivo = archivo.ExtensionArchivo,
                        Bytes = archivo.Bytes,
                        MimeType = archivo.MimeType
                    };

                    var response =  clienteREP.AlmacenarArchivo(request, configura.ruta,configura.soapAction);
                    if (response != null)
                    {
                        archivo.CodArchivoDatos = response.CodArchivoDatos;
                        archivo.IdConfiguracion = configuracion.IdConfiguracion;
                        archivo.IdArchivo = ADArchivo.AgregarAchivo(archivo);
                        almacenajeCompletado?.Invoke(archivo);

                        string msj = "Se agrega documento del servicio {0} y opción {1}, asociado al objeto {2} .";
                        msjBitacora = string.Format(msj, configuracion.CodServicio, configuracion.CodOpcion, archivo.IdObjeto);

                        Bitacora.Agregar(new InfoEvento(Comun.ContextoInvocador), PEL.NBS.Auditoria.SI.Datos.Enum<ServicioPEL>.Description(ServicioPEL.REP),
                                         TipoEvento.bitacora_TipoEvento_Informacion, msjBitacora);

                    }
                }

                respuesta.EsValido = true;
                respuesta.Mensaje = msjBitacora;
            }
            catch (Exception ex)
            {
                ErrorGeneral?.Invoke(archivoCaptura, ex);
                respuesta.Excepcion = ex; 
                respuesta.EsValido = false;
            }

           return respuesta;
        }
        private configuracionWeb ObtenerConfiguracionWeb(Configuracion configuracion)
        {
            configuracionWeb configura = new configuracionWeb();

            try
            {
                string[] configuraciones = configuracion.URL.Split(',');
                
                configura.soapAction = null;

                if (configuraciones.Count() > 1)
                {
                   configura.ruta = configuraciones[0].ToString();
                   configura.soapAction = configuraciones[1].ToString();     
                }
                else
                {
                    configura.ruta = configuracion.URL;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return configura;
        }
        
    }
}
