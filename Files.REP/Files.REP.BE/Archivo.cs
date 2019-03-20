using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PELom.REP.BE
{
    [DataContract, Serializable]
    public class Archivo
    {
        [DataMember]
        public long IdArchivo { get; set; }
        [DataMember]
        public int IdConfiguracion { get; set; }
        [DataMember]
        public int IdObjeto { get; set; }
        [DataMember]
        public string CodArchivoDatos { get; set; }
        [DataMember]
        public int CodEstado { get; set; }
        [DataMember]
        public string NombreArchivo { get; set; }
        [DataMember]
        public string ExtensionArchivo { get; set; }
        [DataMember]
        public string CodFirmaDigital { get; set; }
        [DataMember]
        public string URl { get; set; }
        [DataMember]
        public byte[] Bytes {get;set;}
        [DataMember]
        public string MimeType { get; set; }
        [DataMember]
        public string Contenido { get; set; }
    }
}
