using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TarifarioServices.Dominio;

namespace TarifarioServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITarifarios" in both code and config file together.
    [ServiceContract]
    public interface ITarifarios
    {
        [OperationContract]
        List<Tarifario> listarTarifarios();
    }
}
