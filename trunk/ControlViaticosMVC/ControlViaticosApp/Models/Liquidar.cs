using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlViaticosApp.Models
{
    public class Liquidar
    {
        public int Co_Liquidacion { get; set; }
        public DateTime Fe_Liquidacion { get; set; }
        public Viatico solicitud { get; set; }
        public Double Ss_TotalAsignado { get; set; }
        public Double Ss_TotalUtilizado { get; set; }
        public Double Ss_OtrosGastos { get; set; }
    }
}