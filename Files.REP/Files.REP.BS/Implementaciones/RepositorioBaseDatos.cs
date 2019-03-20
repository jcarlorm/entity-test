using System;
using System.Collections.Generic;
using PELom.REP.BE;
using PEL.NBS.Auditoria.SI.Datos;
using PEL.NBS.Auditoria;
using PELib.Enumerados.NBS;
using PELom.REP.BS.AccesoDatos.RepositorioArchivo;
using PEL.NBS.AccesoRecursos;
using System.ServiceModel;
using PEL.NBS.BS.Utilitarios;

namespace PELom.REP.BS.Implementaciones
{
    internal class RepositorioBaseDatos : ACRepositorio
    {

        AccesoDatos.ADArchivo ADArchivo = new AccesoDatos.ADArchivo();
        public RepositorioBaseDatos()
        {

        }

        public override RespuestaRetorno<List<Archivo>> ObtenerArchivo(string[] codsArchivosDatos, BE.Configuracion configuracion)
        {
            List<Archivo> listaArchivos = new List<Archivo>();
            DSRepositorio ds = new DSRepositorio();
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
                foreach (string codArchivoDato in codsArchivosDatos)
                {

                     archivo = ADArchivo.ConsultarArchivo(codArchivoDato, configuracion.IdConfiguracion);
                    if (archivo != null)
                    {
                        var archivoRepositorio = ds.ObtenerArchivo(Convert.ToInt64(codArchivoDato), archivo.NombreArchivo, configuracion.URL);
                        archivo.URl = archivoRepositorio.Ruta;
                        archivo.Bytes = archivoRepositorio.Contenido;
                        archivo.CodArchivoDatos = archivoRepositorio.IdArchivoDatos.ToString();
                        archivo.Contenido = System.Text.Encoding.UTF8.GetString(archivo.Bytes);
                        listaArchivos.Add(archivo);
                    }
                    else
                    {
                        respuesta.EsValido = false;
                        respuesta.Excepcion = new Exception(string.Format(Recursos.msgrep_MensajeErrorConsultar,codArchivoDato));
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
                errorGeneral?.Invoke(archivo, ex);
                error(ex);
            }
           return respuesta;
        }



        public override RespuestaRetorno SalvarArchivo(Archivo[] archivos, BE.Configuracion configuracion)
        {
            RespuestaRetorno respuesta = new RespuestaRetorno();
            Archivo archivoCaptura = null; 
            try
            {
                DSRepositorio ds = new DSRepositorio();
                string msjBitacora = string.Empty;
                foreach (Archivo archivo in archivos)
                {
                    archivoCaptura = archivo;
                    long id = ds.AgregarArchivoRepositorio(archivo, configuracion.URL);
                    if (id > 0)
                    {
                        archivo.IdConfiguracion = configuracion.IdConfiguracion;
                        archivo.CodArchivoDatos = id.ToString();
                        archivo.IdArchivo = ADArchivo.AgregarAchivo(archivo);
                        AlmacenajeCompletado?.Invoke(archivo);
                        string msj = "Se agrega documento del servicio {0} y opción {1}, asociado al objeto {2} .";
                        msjBitacora = string.Format(msj, configuracion.CodServicio, configuracion.CodOpcion, archivo.IdObjeto);

                        Bitacora.Agregar(new InfoEvento(Comun.ContextoInvocador), PEL.NBS.Auditoria.SI.Datos.Enum<ServicioPEL>.Description(ServicioPEL.REP),
                                         TipoEvento.bitacora_TipoEvento_Informacion, msjBitacora);
                    }
                    else
                    {                                             
                        respuesta.EsValido = false;
                        respuesta.Excepcion = new Exception(string.Format(Recursos.MsgRep_MensajeErrorAgregarBD,archivo.NombreArchivo + '.' + archivo.ExtensionArchivo));
                        return respuesta;
                    }

                }
                respuesta.EsValido = true;
                respuesta.Mensaje = msjBitacora;
            }
            catch (Exception ex)
            {
                ErrorGeneral?.Invoke(archivoCaptura, ex);
                respuesta.EsValido = false;
                respuesta.Excepcion = ex;
            }

            return respuesta;
            
        }
      
    }
}
