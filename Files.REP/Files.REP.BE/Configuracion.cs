using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using PELib.Enumerados.REP;

namespace PELom.REP.BE
{
    [Serializable,DataContract]
    public class Configuracion
    {
        [DataMember]
        public int IdConfiguracion { get; set; }
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public string Clave { get; set; }
        [DataMember]
        public string URL { get; set; }
        [DataMember]
        public int CodEstado { get; set; }
        [DataMember]
        public int CodServicio { get; set; }
        [DataMember]
        public int CodOpcion { get; set; }
        [DataMember]
        public string Puerto { get; set; }
        [DataMember]
        public string CodEntidad { get; set; }
        [DataMember]
        public string Canal { get; set; }
        [DataMember]
        public TipoConfiguracion CodTipoConfiguracion { get; set; }
        [DataMember]
        public string CodPais { get; set; }
        [DataMember]
        public string CodCultura { get; set; }
        [DataMember]
        public bool RequiereFirma { get; set; }
        [DataMember]
        public bool RequiereImpersonalizar { get; set; }
        [DataMember]
        public int CodObjeto { get; set; }

    }
}
