using PEL.NBS.AccesoDatos;
using PELom.REP.BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PELom.REP.BS.AccesoDatos.RepositorioArchivo
{
    internal class DSRepositorio
    {
        private BaseDatosSql CrearBaseDatos(string cadenaConexion)
        {
            return new BaseDatosSql(cadenaConexion);
        }

        public long AgregarArchivoRepositorio(Archivo archivo, string cadenaConexion)
        {
            BaseDatosSql db = CrearBaseDatos(cadenaConexion);

            try
            {

                string sp = "[dbo].[sp_REPAgregarArchivoDatos]";

                db.LimpiarParametros();
                db.AgregarParametro("nombre", archivo.NombreArchivo);
                db.AgregarParametro("contenido", archivo.Bytes);
                db.AgregarParametro("ruta", archivo.URl);
                db.AgregarParametro("extension", archivo.ExtensionArchivo);
                db.AgregarParametro("mimetype", archivo.MimeType);
                db.AgregarParametro("fechaHora", DateTime.Now);

                db.AgregarParametroDeSalida("idArchivoDatos", 1, BaseDatos.TipoBD.Integer);
                db.EjecutarNoConsulta(sp, System.Data.CommandType.StoredProcedure);
                return Convert.ToInt64(db.ObtenerValorDeParametro("idArchivoDatos"));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.CerrarConexion();
            }

        }

        public ArchivoRepositorio ObtenerArchivo(long idArchivoDato, string nombre, string cadenaConexion)
        {
            BaseDatosSql bd = new BaseDatosSql(cadenaConexion);
            try
            {
                ArchivoRepositorio archivo = null;
                string sp = "[dbo].[sp_REPObtenerArchivoDatos]";

                bd.LimpiarParametros();
                bd.AgregarParametro("idArchivoDatos", idArchivoDato);
                if (!string.IsNullOrEmpty(nombre))
                    bd.AgregarParametro("nombreArchivo", nombre);

                MapeadorGenerico<ArchivoRepositorio> mapeador = new MapeadorGenerico<ArchivoRepositorio>();
                DataSet ds = bd.EjecutarDataset(sp, CommandType.StoredProcedure);
                archivo = mapeador.CrearInstancia(ds.Tables[0].Rows[0]);

                return archivo;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                bd.CerrarConexion();
            }
        }
    }
}
