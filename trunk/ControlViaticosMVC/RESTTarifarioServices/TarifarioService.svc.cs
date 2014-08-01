using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RESTTarifarioServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TarifarioService" in code, svc and config file together.
    public class TarifarioService : ITarifarioService
    {

        public Dominio.Tarifario crearTarifario(Dominio.Tarifario tarifarioACrear)
        {
            throw new NotImplementedException();
        }

        public Dominio.Tarifario obtenerTarifario(string codigo)
        {
            throw new NotImplementedException();
        }

        public Dominio.Tarifario modificarTarifario(Dominio.Tarifario tarifarioAModificar)
        {
            throw new NotImplementedException();
        }

        public void eliminarTarifario(string codigo)
        {
            throw new NotImplementedException();
        }

        public List<Dominio.Tarifario> listarTarifarios()
        {
            throw new NotImplementedException();
        }
    }
}
