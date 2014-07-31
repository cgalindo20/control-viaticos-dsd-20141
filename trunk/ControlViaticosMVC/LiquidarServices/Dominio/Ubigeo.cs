using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace LiquidarServices.Dominio
{
    [DataContract]
    public class Ubigeo
    {
        [DataMember]
        public int CodigoUbigeo { get; set; }
        [DataMember]
        public String NoDescripcion { get; set; }
    }
}