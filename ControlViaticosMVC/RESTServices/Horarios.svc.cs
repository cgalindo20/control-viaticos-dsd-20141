using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RESTServices
{
    
    public class Horarios : IHorarios
    {

        public int ObtenerHora()
        {
            int hora =  DateTime.Now.Hour;
            return hora;
        }
    }
}
