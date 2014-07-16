using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace TarifarioServices.Dominio
{
    [DataContract]
    public class Tarifario
    {
        [DataMember]
        public int Co_Tarifa { get; set; }
        [DataMember]
        public int Co_TipoViatico { get; set; }
        [DataMember]
        public Ubigeo Co_Ubigeo { get; set; }
        [DataMember]
        public decimal Ss_Costo { get; set; }
        [DataMember]
        public int Co_EmpActualiza { get; set; }
    }
}