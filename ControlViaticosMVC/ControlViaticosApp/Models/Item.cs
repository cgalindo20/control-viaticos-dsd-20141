using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace LiquidarServices.Dominio
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public int Co_TipoViatico { get; set; }
        [DataMember]
        public Double Ss_MontoUtilizado { get; set; }
    }
}