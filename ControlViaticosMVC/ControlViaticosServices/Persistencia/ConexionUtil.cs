using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlViaticosServices.Persistencia
{
    public class ConexionUtil
    {
        /*
        public static string ObtenerCadena()
        {
            //return @"Data Source=MAVERICK-PC\SQLEXPRESS;Initial Catalog=CONTROLVIATICOS;Integrated Security=True;";
            //return "Data Source=(local);Initial Catalog=DB_Viaticos;Integrated Security=SSPI;";
            String cadenaConexion = @"Data Source=MAVERICK-PC\SQLEXPRESS;Initial Catalog=CONTROLVIATICOS;Integrated Security=True";

            return cadenaConexion;
        }
        */

        public static String ObtenerCadena()
        {
            return @"Data Source=MAVERICK-PC\SQLEXPRESS;Initial Catalog=CONTROLVIATICOS;Integrated Security=True";
            //return "Data Source =(local);Initial Catalog=CONTROLVIATICOS; Integrated Security=SSPI;";
        }
    }
}