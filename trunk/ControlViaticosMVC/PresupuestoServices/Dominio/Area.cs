using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PresupuestoServices.Dominio
{
    [DataContract]
    public class Area
    {
        [DataMember]
        public int Co_Area { get; set; }
        [DataMember]
        public string No_Descripcion { get; set; }
    }
}