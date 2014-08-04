using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using AutorizarServices.Dominio;

namespace AutorizarServices.Dominio
{
    [DataContract]
    public class Autorizar
    {
        [DataMember]
        public int CodigoSolicitud { get; set; }
        [DataMember]
        public DateTime FechaSolicitud { get; set; }
        [DataMember]
        public Empleado empleado { get; set; }
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
        public String FlagAutorizar { get; set; }
        [DataMember]
        public DateTime FechaAutorizar { get; set; }
        [DataMember]
        public int CodigoEmpleadoAutorizar { get; set; }
    }
}