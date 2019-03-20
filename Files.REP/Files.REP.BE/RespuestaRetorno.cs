using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PELom.REP.BE
{
    [KnownType(typeof(RespuestaRetorno))]
    [DataContract, Serializable]
    public class RespuestaRetorno : PEL.NBS.SI.Datos.Mensaje.Respuesta
    {

    }

    [KnownType(typeof(RespuestaRetorno<Archivo>))]
    [KnownType(typeof(RespuestaRetorno<Configuracion>))]
    [DataContract, Serializable]
    public class RespuestaRetorno<TipoGenerico> : PEL.NBS.SI.Datos.Mensaje.Respuesta<TipoGenerico>
    {

    }

}
