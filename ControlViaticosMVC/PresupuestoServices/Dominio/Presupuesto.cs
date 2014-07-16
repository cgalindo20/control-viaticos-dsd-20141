using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PresupuestoServices.Dominio
{
    [DataContract]
    public class Presupuesto
    {
        [DataMember]
        public int Co_Presupuesto { get; set; }
        [DataMember]
        public int Co_Area { get; set; }
        [DataMember]
        public decimal Ss_MontoAsignado { get; set; }
        [DataMember]
        public decimal Ss_MontoDisponible { get; set; }
    }
}