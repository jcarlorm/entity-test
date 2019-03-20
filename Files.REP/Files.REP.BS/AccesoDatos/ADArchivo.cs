using PEL.NBS.AccesoDatos;
using PELom.REP.BE;
using System;
using System.Data;

namespace PELom.REP.BS.AccesoDatos
{
    internal class ADArchivo : AccesoDatosBase
    {
        public long AgregarAchivo(Archivo archivo)
        {
            string sp = "[dbo].[usp_REPAgregarArchivo]";
            bd.LimpiarParametros();
            bd.AgregarParametro("idConfiguracion", archivo.IdConfiguracion);
            bd.AgregarParametro("idObjeto", archivo.IdObjeto);
            bd.AgregarParametro("codArchivoDatos", archivo.CodArchivoDatos);
            bd.AgregarParametro("codEstado", archivo.CodEstado);
            bd.AgregarParametro("nombreArchivo", archivo.NombreArchivo);
            bd.AgregarParametro("extensionArchivo", archivo.ExtensionArchivo);
            bd.AgregarParametro("codFirmaDigital", archivo.CodFirmaDigital);
            bd.AgregarParametro("mimeType", archivo.MimeType);

            bd.AgregarParametroDeSalida("Id", 1, BaseDatos.TipoBD.Numeric);

            if (bd.EjecutarNoConsulta(sp,System.Data.CommandType.StoredProcedure) > 0)
            {
                return Convert.ToInt32(bd.ObtenerValorDeParametro("Id"));
            }
            return 0;
        }

        public BE.Archivo ConsultarArchivo(string codArchivoDatos, int idConfiguracion)
        {
            BE.Archivo archivo = null;

            string sp = "[dbo].[usp_REPConsultarArchivo]";

            bd.LimpiarParametros();
            bd.AgregarParametro("idConfiguracion", idConfiguracion);
            bd.AgregarParametro("codArchivosDatos", codArchivoDatos);

            DataSet ds = bd.EjecutarDataset(sp, CommandType.StoredProcedure);
            MapeadorGenerico<BE.Archivo> mapeador = new MapeadorGenerico<BE.Archivo>();
            archivo = mapeador.CrearInstancia(ds.Tables[0].Rows[0]);

            return archivo;
        }
    }
}
