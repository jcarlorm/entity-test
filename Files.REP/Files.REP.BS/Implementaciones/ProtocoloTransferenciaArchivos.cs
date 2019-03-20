using System;
using System.Collections.Generic;
using PELom.REP.BE;
using System.Net;
using System.IO;
using System.ServiceModel;
using PEL.NBS.Auditoria.SI.Datos;
using PEL.NBS.Auditoria;
using PELib.Enumerados.NBS;
using PEL.NBS.BS.Utilitarios;
using PEL.NBS.AccesoRecursos;

namespace PELom.REP.BS.Implementaciones
{
    internal class ProtocoloTransferenciaArchivos : ACRepositorio
    {
        AccesoDatos.ADArchivo ADArchivo = new AccesoDatos.ADArchivo();
        public ProtocoloTransferenciaArchivos()
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
                respuesta.Mensaje = ex.Message;
                respuesta.EsValido = false;
                ex.Message.EntradaBitacora(TipoEvento.bitacora_TipoEvento_Error, ServicioPEL.REP);
            };

            try
            {
                foreach (string codArchivoDato in codsArchivosDatos)
                {
                    archivo = ADArchivo.ConsultarArchivo(codArchivoDato, configuracion.IdConfiguracion);

                    if (archivo != null)
                    {
                        var respuestaArchivo = ObtenerArchivo(configuracion, archivo);
                        if (respuestaArchivo.EsValido)
                        {
                            listaArchivos.Add(respuestaArchivo.Objeto);
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
            catch (CommunicationException ex)
            {
                errorComunicacion?.Invoke(archivo, ex);
                error(ex);
            }
            catch (Exception ex)
            {
                ErrorGeneral?.Invoke(archivo, ex);
                error(ex);
            }

            return respuesta;
        }

        public override RespuestaRetorno SalvarArchivo(Archivo[] archivos, Configuracion configuracion)
        {
            var respuesta = new RespuestaRetorno();
            Archivo archivo = null;
            try
            {
                string msjBitacora = string.Empty;
                for (int i = 0; archivos.Length > i; i++)
                {
                    archivo = archivos[i];
                    var respuestaRepositorio = GuardarRepositorio(archivo, configuracion);
                    archivo.CodArchivoDatos = respuestaRepositorio.Objeto.CodArchivoDatos;
                    if (respuestaRepositorio.EsValido)
                    {
                        archivo.IdConfiguracion = configuracion.IdConfiguracion;
                        archivo.IdArchivo = ADArchivo.AgregarAchivo(archivo);
                        AlmacenajeCompletado?.Invoke(archivo);
                    }
                    string msj = "Se agrega archivo del servicio {0} y opción {1}, asociado al objeto {2} .";
                    msjBitacora = string.Format(msj, configuracion.CodServicio, configuracion.CodOpcion, archivo.IdObjeto);

                    Bitacora.Agregar(new InfoEvento(Comun.ContextoInvocador), PEL.NBS.Auditoria.SI.Datos.Enum<ServicioPEL>.Description(ServicioPEL.REP),
                                     TipoEvento.bitacora_TipoEvento_Informacion, msjBitacora);
                   
                }
                respuesta.EsValido = true;
                respuesta.Mensaje = msjBitacora;
            }
            catch (Exception ex)
            {
                ErrorGeneral?.Invoke(archivo, ex);
                respuesta.Excepcion = ex;
                respuesta.Mensaje = ex.Message;
                respuesta.EsValido = false;
            }


            return respuesta;
        }
        protected RespuestaRetorno<Archivo> GuardarRepositorio(Archivo archivo, Configuracion configuracion)
        {
            BE.RespuestaRetorno<Archivo> resp = new BE.RespuestaRetorno<Archivo>();

            Archivo archivoRepositorio = new Archivo();
            try
            {
                string archivoExtension = archivo.NombreArchivo + "." + archivo.ExtensionArchivo;
                string fullPath = Path.Combine(configuracion.URL, archivoExtension);

                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(fullPath);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(configuracion.Usuario, configuracion.Clave);
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;

                byte[] buffer = archivo.Bytes;

                request.ContentLength = buffer.Length;

                Stream reqStream = request.GetRequestStream();
                if (request.ContentLength != 0)
                {
                    reqStream.Write(buffer, 0, buffer.Length);
                }

                archivoRepositorio.CodArchivoDatos = fullPath;


                reqStream.Flush();
                reqStream.Close();
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                string msjBitacora = "Archivo {0} cargado en el repositorio FTP, estatus : " + response.StatusDescription;

                response.Close();
                Bitacora.Agregar(new InfoEvento(Comun.ContextoInvocador), PEL.NBS.Auditoria.SI.Datos.Enum<ServicioPEL>.Description(ServicioPEL.REP),
                                     TipoEvento.bitacora_TipoEvento_Informacion, string.Format(msjBitacora, archivoExtension));
                resp.EsValido = true;
                resp.Objeto = archivoRepositorio;
            }
            catch (CommunicationException ex)
            {
                errorComunicacion?.Invoke(archivo, ex);
                throw ex;
            }

            return resp;
        }


        protected RespuestaRetorno<Archivo> ObtenerArchivo(Configuracion configuracion, Archivo archivo)
        {
            WebClient request = new WebClient();
            Archivo nuevoArchivo = archivo;
            var respuestaArchivo = new RespuestaRetorno<Archivo>()
            {
                Objeto = new Archivo()
            };

            Action finalizar = () => {
                request.Dispose();
            };

            string url = configuracion.URL + archivo.NombreArchivo + "." + archivo.ExtensionArchivo;
            request.Credentials = new NetworkCredential(configuracion.Usuario, configuracion.Clave);

            try
            {

                byte[] archivoBytes = request.DownloadData(url);
                string contenido = System.Text.Encoding.UTF8.GetString(archivoBytes);

                nuevoArchivo.Bytes = archivoBytes;
                nuevoArchivo.Contenido = contenido;
                respuestaArchivo.Objeto = nuevoArchivo;
                respuestaArchivo.EsValido = true;
            }
            catch (Exception ex)
            {
                finalizar();
                throw ex;
            }
            finally { finalizar(); }

            return respuestaArchivo;
        }
    }
}
