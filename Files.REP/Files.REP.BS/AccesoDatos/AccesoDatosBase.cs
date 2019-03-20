using PEL.NBS.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PELom.REP.BS.AccesoDatos
{
    internal class AccesoDatosBase : IDisposable
    {
        protected BaseDatos bd;

        /// <summary>
        /// Constructor para inicializar la conexión a la base de datos.
        /// </summary>
        public AccesoDatosBase()
        {
            bd = AdministradorBaseDatos.CrearBaseDeDatosInternetBanking();
        }

        /// <summary>
        /// Cierra la conexión del DS.
        /// </summary>
        public void Dispose()
        {
            bd.CerrarConexion();
        }
    }
}
