using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RESTServices.Dominio
{
    [DataContract]
    public class Presupuesto
    {
        [DataMember]
        public int Co_Presupuesto { get; set; }
        [DataMember]
        public int Co_Area { get; set; }
        [DataMember]
        public Double Ss_MontoAsignado { get; set; }
        [DataMember]
        public Double Ss_MontoDisponible { get; set; }

    }
}