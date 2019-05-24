using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel.Impresion
{
    public class Configuracion
    {
        public Configuracion(string rutaPlantilla, string rutaDestino)
        {
            RutaPlantilla = rutaPlantilla;
            RutaDestino = rutaDestino;
        }
        protected string RutaPlantilla { get; set; }
        protected string RutaDestino { get; set; }
    }
}
