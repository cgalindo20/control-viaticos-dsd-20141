using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RESTServices.Persistencia;
using RESTServices.Dominio;
using LiquidarServices.Persistencia;
using System.Net;
using System.ServiceModel.Web;

namespace RESTServices
{
    public class PresupuestoService : IPresupuestoService
    {

        private PresupuestoDAO dao = new PresupuestoDAO();

        public Presupuesto CrearPresupuesto(Presupuesto presupuestoACrear)
        {
            Presupuesto presupuestoEncontrado = dao.Obtener(presupuestoACrear.Co_Presupuesto.ToString());
            if (presupuestoEncontrado != null) //Presupuesto Existe
                throw new WebFaultException<ValidationException>(
                    new ValidationException()
                    {
                        CodigoError = "E001",
                        MensajeError = "El Presupuesto ya existe."
                    },
                        HttpStatusCode.InternalServerError 
                    );
            
            return dao.Crear(presupuestoACrear);
        }

        public Presupuesto ObtenerPresupuesto(string codigo)
        {

            Presupuesto presupuestoEncontrado = dao.Obtener(codigo);
            if (presupuestoEncontrado == null) //Presupuesto NO Existe
                throw new WebFaultException<ValidationException>(
                    new ValidationException()
                    {
                        CodigoError = "E002",
                        MensajeError = "El Presupuesto NO existe."
                    },
                        HttpStatusCode.InternalServerError
                    );
            //return dao.Obtener(codigo);
            return presupuestoEncontrado;
        }

        public Presupuesto ModificarPresupuesto(Presupuesto presupuestoAModificar)
        {            
            return dao.Modificar(presupuestoAModificar);
        }

        public void EliminarPresupuesto(string codigo)
        {            
            Presupuesto presupuestoAEliminar = new Presupuesto();
            presupuestoAEliminar.Co_Presupuesto = int.Parse(codigo);
            dao.Eliminar(presupuestoAEliminar);
        }

        public List<Presupuesto> ListarPresupuestos()
        {
            return dao.ListarTodos();
        }

    }
}
