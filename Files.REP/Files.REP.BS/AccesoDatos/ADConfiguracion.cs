using PEL.NBS.AccesoDatos;
using System;
using System.Data;

namespace PELom.REP.BS.AccesoDatos
{
    internal class ADConfiguracion : AccesoDatosBase
    {
        public int AgregarConfiguracion(BE.Configuracion configuracion)
        {
            int idConfiguracion = 0;
            string sp = "[dbo].[usp_REPAgregarConfiguracion]";
            bd.AgregarParametro("usuario", configuracion.Usuario);
            bd.AgregarParametro("clave", configuracion.Clave);
            bd.AgregarParametro("url", configuracion.URL);
            bd.AgregarParametro("codEstado", configuracion.CodEstado);
            bd.AgregarParametro("codObjeto", configuracion.CodObjeto);
            bd.AgregarParametro("codServicio", configuracion.CodServicio);
            bd.AgregarParametro("codOpcion", configuracion.CodOpcion);
            bd.AgregarParametro("puerto", configuracion.Puerto);
            bd.AgregarParametro("codEntidad", configuracion.CodEntidad);
            bd.AgregarParametro("canal", configuracion.Canal);
            bd.AgregarParametro("codTipoConfiguracion", (int)configuracion.CodTipoConfiguracion);
            bd.AgregarParametro("codPais", configuracion.CodPais);
            bd.AgregarParametro("codCultura", configuracion.CodCultura);
            bd.AgregarParametro("requiereFirma", configuracion.RequiereFirma);
            bd.AgregarParametro("requiereImpersonalizar", configuracion.RequiereImpersonalizar);

            bd.AgregarParametroDeSalida("Id", 1, BaseDatos.TipoBD.Numeric);
            bd.EjecutarNoConsulta(sp, System.Data.CommandType.StoredProcedure);

            // Obtenemos el id de para el histórico y lo retornamos.                
            idConfiguracion = Convert.ToInt32(bd.ObtenerValorDeParametro("Id"));

            return idConfiguracion;
        }
        public BE.Configuracion ObtenerConfiguracion(int idConfiguracion)
        {
            BE.Configuracion configuracion = null;
            string sp = "[dbo].[usp_REPObtenerConfiguracion]";

            MapeadorGenerico<BE.Configuracion> mapeador = new MapeadorGenerico<BE.Configuracion>();

            bd.LimpiarParametros();
            bd.AgregarParametro("IdConfiguracion", idConfiguracion);
            DataSet ds = bd.EjecutarDataset(sp, CommandType.StoredProcedure);

            configuracion = mapeador.CrearInstancia(ds.Tables[0].Rows[0]);

            return configuracion;
        
        }
       
    }
}
