using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTTarifarioServices.Persistencia
{
    public class ConexionUtil
    {
        public static string Cadena
        {
            get
            {
                //return "Data Source=(local);Initial Catalog=CONTROLVIATICOS;Integrated Security=SSPI;";
                return "Data Source=436a03ef-023b-43d6-abfc-a3810152230f.sqlserver.sequelizer.com;Initial Catalog=db436a03ef023b43d6abfca3810152230f;User ID=wdqvsnbkjuphmhba;Password=Ux3JmzR6BX6kQrEj2rXGQQtRqUHKbrdoh85gLeoAzPv2H2PfsAymzCsddjtyYg5k;";
            }
        }
    }
}