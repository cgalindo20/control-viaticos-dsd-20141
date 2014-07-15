using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlViaticosApp.Models
{
    public class Empleado
    {
        public int Co_Empleado { get; set; }
        public String Tx_PreNombre { get; set; }
        public String Tx_Ap_Paterno { get; set; }
        public String Tx_Ap_Materno { get; set; }
        public Area area { get; set; }
    }
}