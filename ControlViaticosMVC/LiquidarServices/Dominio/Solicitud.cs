using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace LiquidarServices.Dominio
{
    [DataContract]
    public class Solicitud
    {

        [DataMember]
        public int Co_Solicitud { get; set; }
        [DataMember]
        public DateTime Fe_Solicitud { get; set; }
        [DataMember]
        public int Co_EmpSolicitante { get; set; }
        [DataMember]
        public Ubigeo ubigeoOrigen { get; set; }
        [DataMember]
        public Ubigeo ubigeoDestino { get; set; }
        [DataMember]
        public DateTime Fe_Salida { get; set; }
        [DataMember]
        public DateTime Fe_Retorno { get; set; }
        [DataMember]
        public String Tx_Sustento { get; set; }
        [DataMember]
        public Double Ss_TotalSolicitado { get; set; }
        [DataMember]
        public IList<SolicitudDetalle> Detalles { get; set; }     
        

    }
}