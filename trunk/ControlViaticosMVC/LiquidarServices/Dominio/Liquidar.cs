using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace LiquidarServices.Dominio
{
    [DataContract]
    public class Liquidar
    {

        [DataMember(IsRequired = false)]
        public int Co_Liquidacion { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime Fe_Liquidacion { get; set; }
        [DataMember(IsRequired = false)]
        public Solicitud solicitud { get; set; }
        [DataMember(IsRequired = false)]
        public Double Ss_TotalAsignado { get; set; }
        [DataMember(IsRequired = false)]
        public Double Ss_TotalUtilizado { get; set; }
        [DataMember(IsRequired = false)]
        public Double Ss_OtrosGastos { get; set; }
        [DataMember(IsRequired = false)]
        public IList<LiquidarDetalle> Detalles { get; set; }

    }
}