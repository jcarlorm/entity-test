//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BD.entity
{
    using System;
    
    public partial class ListaFacturasRecientes_Result
    {
        public int idFactura { get; set; }
        public int idRevisión { get; set; }
        public int idOrden { get; set; }
        public int idCliente { get; set; }
        public int idUsuario { get; set; }
        public string descripción { get; set; }
        public int descuento { get; set; }
        public double impuesto { get; set; }
        public double subtotal { get; set; }
        public double total { get; set; }
        public string tipoPago { get; set; }
        public System.DateTime fecha { get; set; }
        public int estado { get; set; }
        public int exonerado { get; set; }
        public string condicionVenta { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cedula { get; set; }
        public string placa { get; set; }
        public string nombre1 { get; set; }
        public string apellido1 { get; set; }
    }
}
