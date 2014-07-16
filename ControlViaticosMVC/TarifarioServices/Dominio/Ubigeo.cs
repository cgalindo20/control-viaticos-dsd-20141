using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace TarifarioServices.Dominio
{
    [DataContract]
    public class Ubigeo
    {
        [DataMember]
        public int Co_Ubigeo { get; set; }
        [DataMember]
        public string No_Descripcion { get; set; }
    }
}