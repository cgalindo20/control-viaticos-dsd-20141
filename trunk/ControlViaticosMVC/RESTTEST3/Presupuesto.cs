using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RESTTEST3
{
    
    public class Presupuesto
    {
        public int Co_Presupuesto { get; set; }
        public int Co_Area { get; set; }
        public Double Ss_MontoAsignado { get; set; }
        public Double Ss_MontoDisponible { get; set; }

    }
}