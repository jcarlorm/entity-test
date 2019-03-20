using System;
using System.Collections.Generic;
using PELom.REP.BE;
using System.IO;
using System.ServiceModel;
using PEL.NBS.Auditoria.SI.Datos;
using PEL.NBS.Auditoria;
using PELib.Enumerados.NBS;
using PEL.NBS.BS.Utilitarios;
using PEL.NBS.AccesoRecursos;

namespace PELom.REP.BS.Implementaciones
{
    internal class SistemaArchivosDstribuidos : ACRepositorio
    {
        
        AccesoDatos.ADArchivo ADArchivo = new AccesoDatos.ADArchivo();
        public SistemaArchivosDstribuidos()
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
                if (configuracion.RequiereImpersonalizar)
                {
                    Impersonaliza(configuracion);
                }

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

                respuesta.EsValido = true;
                respuesta.Objeto = listaArchivos;
            }
            catch (CommunicationException ex)
            {
                errorComunicacion?.Invoke(archivo, ex);
                error(ex);
            }
            catch (Exception ex)
            {
                errorGeneral?.Invoke(archivo, ex);
                error(ex);
            }
            finally
            {
                if (configuracion.RequiereImpersonalizar)
                    Dispose();
            }

           return respuesta;
        }

        public override RespuestaRetorno SalvarArchivo(Archivo[] archivos, Configuracion configuracion)
        {
            var respuesta = new RespuestaRetorno();
            Archivo archivoCaptura = null;
            try
            {
                string msjBitacora = string.Empty;
                if (configuracion.RequiereImpersonalizar)
                {
                    Impersonaliza(configuracion);
                }

                foreach (Archivo archivo in archivos)
                {
                    archivoCaptura = archivo;
                    var respuestaRepositorio = GuardarRepositorio(archivo, configuracion);
                    if (respuestaRepositorio.EsValido)
                    {
                        archivo.CodArchivoDatos = respuestaRepositorio.Objeto.CodArchivoDatos;
                        archivo.IdConfiguracion = configuracion.IdConfiguracion;
                        archivo.IdArchivo = new AccesoDatos.ADArchivo().AgregarAchivo(archivo);
                        AlmacenajeCompletado?.Invoke(archivo);
                    }

                    string msj = "Se agrega documento del servicio {0} y opción {1}, asociado al objeto {2} .";
                    msjBitacora = string.Format(msj, configuracion.CodServicio, configuracion.CodOpcion, archivo.IdObjeto);
                    Bitacora.Agregar(new InfoEvento(Comun.ContextoInvocador), PEL.NBS.Auditoria.SI.Datos.Enum<ServicioPEL>.Description(ServicioPEL.REP),
                                     TipoEvento.bitacora_TipoEvento_Informacion, msjBitacora);
                }
                respuesta.EsValido = true;
                respuesta.Mensaje = msjBitacora;
            }
            catch (Exception ex)
            {

                ErrorGeneral?.Invoke(archivoCaptura, ex);
                respuesta.Excepcion = ex;
                respuesta.Mensaje = ex.Message;
                respuesta.EsValido = false;
            }
            finally
            {
                if (configuracion.RequiereImpersonalizar)
                    Dispose();
            }

            return respuesta;
        }
        private RespuestaRetorno<Archivo> GuardarRepositorio(Archivo archivo, Configuracion configuracion)
        {

            BE.RespuestaRetorno<Archivo> resp = new BE.RespuestaRetorno<Archivo>();

            Archivo archivoRepositorio = new Archivo();
            try
            {
               
                string nombreDeArchivo = archivo.NombreArchivo + "." + archivo.ExtensionArchivo;
                string codArchivoDatos = configuracion.URL + "/" + nombreDeArchivo;

                if (File.Exists(codArchivoDatos))
                    File.Delete(codArchivoDatos);

                FileStream fs = new FileStream(codArchivoDatos, FileMode.CreateNew, FileAccess.Write);

                archivoRepositorio.CodArchivoDatos = codArchivoDatos;
                resp.EsValido = true;
                resp.Objeto = archivoRepositorio;

                fs.Write(archivo.Bytes, 0, (int)archivo.Bytes.Length);
                fs.Close();

            }
            catch (CommunicationException ex)
            {
                errorComunicacion?.Invoke(resp.Objeto, ex);

                throw ex;
            }

            return resp;
        }
        protected RespuestaRetorno<Archivo> ObtenerArchivo(Configuracion configuracion, Archivo archivo)
        {
            Archivo nuevoArchivo = archivo;
            var respuestaArchivo = new RespuestaRetorno<Archivo>()
            {
                Objeto = new Archivo()
            };

            try
            {
                if (File.Exists(archivo.CodArchivoDatos))
                {
                    nuevoArchivo.Bytes = File.ReadAllBytes(archivo.CodArchivoDatos);
                    string contenido = System.Text.Encoding.UTF8.GetString(nuevoArchivo.Bytes);
                    nuevoArchivo.Contenido = contenido;
                    respuestaArchivo.EsValido = true;
                    respuestaArchivo.Objeto = nuevoArchivo;
                }
               
            }
            catch (Exception ex)
            {
                ErrorGeneral?.Invoke(nuevoArchivo, ex);
                respuestaArchivo.EsValido = false;
                respuestaArchivo.Excepcion = ex;
            }

            return respuestaArchivo;
        }
    }
}
