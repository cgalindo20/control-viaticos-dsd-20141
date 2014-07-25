using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RESTServices.Dominio;
using System.ServiceModel.Web;

namespace RESTServices
{
    
    [ServiceContract]
    public interface IPresupuestoService
    {
        [OperationContract]
        [WebInvoke(Method="POST", UriTemplate = "Presupuestos", ResponseFormat = WebMessageFormat.Json)]
        Presupuesto CrearPresupuesto(Presupuesto presupuestoACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Presupuestos/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        Presupuesto ObtenerPresupuesto(string codigo);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Presupuestos", ResponseFormat = WebMessageFormat.Json)]
        Presupuesto ModificarPresupuesto(Presupuesto presupuestoAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Presupuestos/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarPresupuesto(string codigo);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Presupuestos", ResponseFormat = WebMessageFormat.Json)]
        List <Presupuesto> ListarPresupuestos();
    }
}
