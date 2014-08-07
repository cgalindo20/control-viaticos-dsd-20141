using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RESTTarifarioTest
{
    public class Tarifario
    {
        public int Co_Tarifa { get; set; }
        public int Co_TipoViatico { get; set; }
        public int Co_Ubigeo { get; set; }
        public decimal Ss_Costo { get; set; }
        public int Co_EmpActualiza { get; set; }
    }
}