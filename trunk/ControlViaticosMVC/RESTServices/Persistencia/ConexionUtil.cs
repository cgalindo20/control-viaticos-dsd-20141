using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTServices.Persistencia
{
    public class ConexionUtil
    {
        public static string Cadena
        {
            get
            {
                return "Data Source=(local);Initial Catalog=PRESUPUESTO;Integrated Security=SSPI;";
                //return @"Data Source=MAVERICK-PC\SQLEXPRESS;Initial Catalog=CONTROLVIATICOS;Integrated Security=True";
            }
        }
    }
}