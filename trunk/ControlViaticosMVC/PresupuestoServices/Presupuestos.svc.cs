using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PresupuestoServices.Persistencia;

namespace PresupuestoServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Presupuestos : IPresupuesto
    {
        private PresupuestoDAO presupuestoDAO = null;
        private PresupuestoDAO PresupuestoDAO
        {
            get
            {
                if (presupuestoDAO == null)
                    presupuestoDAO = new PresupuestoDAO();
                return presupuestoDAO;
            }
        }

        public List<Dominio.Presupuesto> listarPresupuesto()
        {
            return PresupuestoDAO.ListarTodos().ToList();
        }
    }
}
