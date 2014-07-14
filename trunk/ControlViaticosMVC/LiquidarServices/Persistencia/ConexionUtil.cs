using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiquidarServices.Persistencia
{
    public class ConexionUtil
    {
        public static String ObtenerCadena()
        {
            return "Data Source =(local);Initial Catalog=CONTROLVIATICOS; Integrated Security=SSPI;";
        }

    }
}