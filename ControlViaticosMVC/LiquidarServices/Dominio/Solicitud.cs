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
    }
}