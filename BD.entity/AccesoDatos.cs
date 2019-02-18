using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.entity
{
    public class AccesoDatos
    {
        DYNAMICSEntities db = new DYNAMICSEntities();

        public List<admin_factura_electronica> ObtieneInformacionFacturaElectronica()
        {
            var DatosFactura = from datos in db.admin_factura_electronica select datos;

            return DatosFactura.ToList();
        }
        
    }
}
