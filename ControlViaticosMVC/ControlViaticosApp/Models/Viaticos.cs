using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlViaticosApp.Models
{
    public class Viaticos
    {
        public int Codigo { get; set; }
        public String ApellidosNombres { get; set; }
        public String Cargo { get; set; }
        public String Area { get; set; }
        public String CentroCosto { get; set; }
        public String JustificacionViaje { get; set; }
        public String LugarPartida { get; set; }
        public String LugarDestino { get; set; }
        public String FomaPago { get; set; }
        public int NumeroDias { get; set; }
        public Double MontoViaticoDiario { get; set; }
        public Double MontoTotal { get; set; }
        public String Estado { get; set; }

    }
}