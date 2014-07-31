using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ControlViaticosServices.Dominio
{
    [DataContract]
    public class TipoViatico
    {
        [DataMember]
        public int Co_TipoViatico { get; set; }
        [DataMember]
        public String No_Descripcion { get; set; }
    }
}