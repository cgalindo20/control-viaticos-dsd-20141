using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RESTServices
{
    
    [ServiceContract]
    public interface IHorarios
    {
        [OperationContract]
        [WebGet(UriTemplate="Horarios", ResponseFormat = WebMessageFormat.Json)]
        int ObtenerHora();
    }
}
