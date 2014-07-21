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

        [DataMember]
        public int Co_Liquidacion { get; set; }
        [DataMember]
        public DateTime Fe_Liquidacion { get; set; }
        [DataMember]
        public Solicitud solicitud { get; set; }
        [DataMember]
        public Double Ss_TotalAsignado { get; set; }
        [DataMember]
        public Double Ss_TotalUtilizado { get; set; }
        [DataMember]
        public Double Ss_OtrosGastos { get; set; }
        [DataMember]
        public IList<LiquidarDetalle> Detalles { get; set; }

    }
}