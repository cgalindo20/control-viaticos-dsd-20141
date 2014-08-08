using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RESTServices.Dominio
{
    [DataContract]
    public class Viatico
    {
        [DataMember]
        public int Co_Solicitud { get; set; }

        [DataMember(IsRequired = false)]
        public DateTime Fe_Solicitud { get; set; }

        [DataMember(IsRequired = false)]
        public Double Ss_TotalSolicitado { get; set; }

        [DataMember(IsRequired = false)]
        public String Fl_Autorizado { get; set; }

        [DataMember(IsRequired = false)]
        public DateTime Fe_Autorizado { get; set; }

        [DataMember(IsRequired = false)]
        public int Co_EmpAutoriza { get; set; }

        [DataMember(IsRequired = false)]
        public String Fl_Aprobado { get; set; }

        [DataMember(IsRequired = false)]
        public DateTime Fe_Aprobado { get; set; }

        [DataMember(IsRequired = false)]
        public int Co_EmpAprueba { get; set; }
    }
}