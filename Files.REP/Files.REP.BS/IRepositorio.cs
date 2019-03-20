using PELom.REP.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PELom.REP.BS
{
    public interface IRepositorio
    {
        RespuestaRetorno<List<Archivo>> ObtenerArchivo(string[] codsArchivosDatos, Configuracion configuracion);
        RespuestaRetorno SalvarArchivo(Archivo[] archivo, Configuracion configuracion);
        RespuestaRetorno<Archivo> ValidarArchivo(Archivo archivo);
    }
}
