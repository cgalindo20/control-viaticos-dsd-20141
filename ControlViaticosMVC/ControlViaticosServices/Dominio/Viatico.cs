using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ControlViaticosServices.Dominio
{
    [DataContract]
    public class Viatico
    {
        [DataMember]
        public int CodigoSolicitud { get; set; }
        [DataMember]
        public DateTime FechaSolicitud { get; set; }
        [DataMember]
        public int CodigoEmpleadoSolicitante { get; set; }
        [DataMember]
        public Ubigeo ubigeoOrigen { get; set; }
        [DataMember]
        public Ubigeo ubigeoDestino { get; set; }
        [DataMember]
        public DateTime FechaSalida { get; set; }
        [DataMember]
        public DateTime FechaRetorno { get; set; }
        [DataMember]
        public String SustentoViaje { get; set; }        
        [DataMember]
        public Double TotalSolicitado { get; set; }
        [DataMember]
        public IList<ViaticoDetalle> Detalles { get; set; }        

    }
}