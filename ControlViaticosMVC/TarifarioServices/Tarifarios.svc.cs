using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TarifarioServices.Persistencia;
using TarifarioServices.Dominio;

namespace TarifarioServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Tarifarios" in code, svc and config file together.
    public class Tarifarios : ITarifarios
    {
        private TarifarioDAO tarifarioDAO = null;
        private TarifarioDAO TarifarioDAO
        {
            get
            {
                if (tarifarioDAO == null)
                    tarifarioDAO = new TarifarioDAO();
                return tarifarioDAO;
            }
        }

        public List<Tarifario> listarTarifarios()
        {
            return TarifarioDAO.ListarTodos().ToList();
        }
    }
}
