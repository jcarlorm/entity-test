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

        public List<ListarCoche> ObtieneInformacionListarCoche()
        {
            var DatosCoche = from datos in db.ListarCoche select datos;

            return DatosCoche.ToList();
        }

        public Bitacora RegistrarBitacora(Bitacora bitacora)
        {
            db.Bitacora.Add(bitacora);
            db.SaveChanges();
            return bitacora;
        }
        
        public  List<ListarCoche> ObtieneListarCoches()
        {
            var DatosCoche = from datos in db.ListarCoche select datos;

            return DatosCoche.ToList();
        }
    }
}
