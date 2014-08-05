using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace AprobarServices.Dominio
{
    [DataContract]
    public class Empleado
    {
        [DataMember]
        public int CoEmpleado { get; set; }
        [DataMember]
        public String TxPreNombre { get; set; }
        [DataMember]
        public String TxAp_Paterno { get; set; }
        [DataMember]
        public String TxAp_Materno { get; set; }
        //public Area area { get; set; }
    }
}