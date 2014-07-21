using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.IO;

namespace RESTServices
{
  
    public class Mensajes : IMensajes
    {
        public string ObtenerSaludo()
        {
            HttpWebRequest req = WebRequest.Create(
                "http://localhost:3217/Horarios.svc/Horarios") as HttpWebRequest;
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(res.GetResponseStream());
            int hora = int.Parse(reader.ReadToEnd());

            if(hora < 12)
                return "Buenos dias son las " + hora;
            else if(hora < 19)
                return "Buenas tardes son las " + hora;
            else
                return "Buenas noches son las " + hora;
        }


    }
}
