using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RESTTarifarioServices.Dominio;
using System.ServiceModel.Web;

namespace RESTTarifarioServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITarifarioService" in both code and config file together.
    [ServiceContract]
    public interface ITarifarioService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Tarifarios", ResponseFormat = WebMessageFormat.Json)]
        Tarifario crearTarifario(Tarifario tarifarioACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Tarifarios/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        Tarifario obtenerTarifario(string codigo);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Tarifarios", ResponseFormat = WebMessageFormat.Json)]
        Tarifario modificarTarifario(Tarifario tarifarioAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Tarifarios/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        void eliminarTarifario(string codigo);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Tarifarios", ResponseFormat = WebMessageFormat.Json)]
        List<Tarifario> listarTarifarios();
    }
}
