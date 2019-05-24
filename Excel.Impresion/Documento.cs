using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelLib = Microsoft.Office.Interop.Excel;

namespace Excel.Impresion
{
    public class Documento : Configuracion
    {
        public static ExcelLib.Application AppExcel { get; set; }
        public static ExcelLib.Workbook Libro { get; set; }
        public Documento(string rutaPlantilla, string rutaDestino) : base(rutaPlantilla, rutaDestino) { }

        public void Crear(Dictionary<string,string> campos, Dictionary<string, List<string>> detalle = null, string lineaDetalle = null)
        {
            AppExcel = new ExcelLib.Application();
            AppExcel.Visible = false;
            AppExcel.DisplayAlerts = false;

            Libro = AppExcel.Workbooks.Open(RutaPlantilla);

            EscribirCamposNoDinamicos(campos);
            if (detalle != null) EscribirFila(detalle, lineaDetalle);

            Libro.SaveAs(RutaDestino);
            AppExcel.Quit();
        }

        Action<Dictionary<string, string>> EscribirCamposNoDinamicos = campos => {
            foreach (KeyValuePair<string, string> item in campos)
            {
                EscribirEnPosicion(item.Key, item.Value);
            }
        };

        Action<Dictionary<string, List<string>>, string> EscribirFila = (detalle, lineaDetalle) => {
            int contadorFilas = 0;
            ExcelLib._Worksheet hoja = Libro.Sheets[1];
            ExcelLib.Range celda;
            var ubicacion = lineaDetalle.ToCharArray();
            Columna columnaInicial = (Columna)Enum.Parse(typeof(Columna), ubicacion[0].ToString());
            int filaInicial = int.Parse(ubicacion[1].ToString());


            foreach (KeyValuePair<string, List<string>> item in detalle)
            {
                if (contadorFilas > 0) {
                    celda = hoja.Cells[filaInicial + contadorFilas, columnaInicial.ToString()];
                    celda.Insert();
                }
                else celda = hoja.Cells[filaInicial, columnaInicial.ToString()];

                Columna moverColumna = columnaInicial;

                item.Value.ForEach(valor => {
                    celda.Value = valor;
                    moverColumna++;
                    celda = hoja.Cells[filaInicial, moverColumna.ToString()];
                });
                
                contadorFilas++;
            }
        };


        static void EscribirEnPosicion(string posicion, string valor , bool nuevaFila = false)
        {
            ExcelLib._Worksheet hoja = Libro.Sheets[1];
            var ubicacion = posicion.ToCharArray();

            ExcelLib.Range celda = hoja.Cells[int.Parse(ubicacion[1].ToString()), ubicacion[0].ToString()];
            celda.Value = valor;
        }

    }
}
