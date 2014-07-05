using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlViaticosServices.Persistencia
{
    public class ConexionUtil
    {
        public static string ObtenerCadena()
        {
            //return "Data Source=.\\SQLExpress;Initial Catalog=DB_Canchitas;Integrated Security=SSPI;";
            return "Data Source=(local);Initial Catalog=DB_Viaticos;Integrated Security=SSPI;";
        }
    }
}