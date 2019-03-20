using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PELom.REP.BS.AccesoDatos.RepositorioArchivo
{
    public class ArchivoRepositorio
    {
        public long IdArchivoDatos { get; set; }
        public string Nombre { get; set; }
        public byte[] Contenido { get; set; }
        public string Ruta { get; set; }
        public string Extension { get; set; }
        public string Mimetype { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
