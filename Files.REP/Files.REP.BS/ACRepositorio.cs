using System;
using System.Collections.Generic;
using PELom.REP.BE;
using PELib.Enumerados.REP;
using PEL.NBS.SI.Datos.Mensaje;
using PELom.REP.BS.Implementaciones;
using System.Linq;

namespace PELom.REP.BS
{
    internal abstract class ACRepositorio : IRepositorio
    {
        protected Action<Archivo, Exception> errorComunicacion;
        protected Action<Archivo> almacenajeCompletado;
        protected Action<Archivo, Exception> errorGeneral;
        Impersonalizacion.Imperzonalizar impersonalizacion = new Impersonalizacion.Imperzonalizar();
        
        public Action<Archivo, Exception> ErrorComunicacion
        {
            get
            {
                return errorComunicacion;
            }

            set
            {
                errorComunicacion = value;
            }
        }

        public Action<Archivo> AlmacenajeCompletado
        {
            get
            {
                return almacenajeCompletado;
            }

            set
            {
                almacenajeCompletado = value;
            }
        }

        public Action<Archivo, Exception> ErrorGeneral
        {
            get
            {
                return errorGeneral;
            }

            set
            {
                errorGeneral = value;
            }
        }
        
        public abstract BE.RespuestaRetorno<List<Archivo>> ObtenerArchivo(string[] codsArchivosDatos, Configuracion configuracion);
        public abstract BE.RespuestaRetorno SalvarArchivo(Archivo[] archivo, Configuracion configuracion);
        
        public virtual BE.RespuestaRetorno<Archivo> ValidarArchivo(Archivo archivo)
        {
            var respuesta = new BE.RespuestaRetorno<Archivo>()
            {
                Objeto = new Archivo()
            };
            respuesta.EsValido = true;
            return respuesta;
        }

        public static ACRepositorio InstanciarCanal(Configuracion configuracion)
        {

            switch (configuracion.CodTipoConfiguracion)
            {
                case TipoConfiguracion.WS:
                    return new WebService();
                case TipoConfiguracion.BD:
                    return new RepositorioBaseDatos();
                case TipoConfiguracion.DFS:
                    return new SistemaArchivosDstribuidos();
                case TipoConfiguracion.FTP:
                    return new ProtocoloTransferenciaArchivos();
                default:
                    throw new NotImplementedException();

            }


        }
        public BE.RespuestaRetorno ValidarFirma(Configuracion configuraion)
        {
            BE.RespuestaRetorno respuesta = new BE.RespuestaRetorno();
            respuesta.EsValido = true;
            return respuesta;
        }
        protected void Impersonaliza(Configuracion configuracion)
        {

            string usuario = configuracion.Usuario;
            string dominio = string.Empty;
            string tipoImpersonalizacion = string.Empty;
            string tipoProveedorImpersonalizacion = string.Empty;
            string[] login = configuracion.Usuario.Split('/');
            string[] codigosImpersonalizacion = configuracion.Puerto.Split(',');
            if (login.Count() > 1)
            {
                dominio = login[0];
                usuario = login[1];
            }
            if (codigosImpersonalizacion.Count() > 2)
            {
                tipoImpersonalizacion = codigosImpersonalizacion[1];
                tipoImpersonalizacion = codigosImpersonalizacion[2];

            }
            else if (codigosImpersonalizacion.Count() > 1)
            {
                tipoImpersonalizacion = codigosImpersonalizacion[0];
                tipoProveedorImpersonalizacion = codigosImpersonalizacion[1];
            }

           

            impersonalizacion.Impersonalizar(usuario, configuracion.Clave, dominio, tipoImpersonalizacion, tipoProveedorImpersonalizacion);

        }
        protected void Dispose()
        {
            impersonalizacion.Dispose();
        }
        
    }
}
