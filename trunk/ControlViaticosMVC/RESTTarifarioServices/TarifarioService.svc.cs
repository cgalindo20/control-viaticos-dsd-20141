using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RESTTarifarioServices.Dominio;
using RESTTarifarioServices.Persistencia;
using System.ServiceModel.Web;
using System.Net;

namespace RESTTarifarioServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TarifarioService" in code, svc and config file together.
    public class TarifarioService : ITarifarioService
    {

        TarifarioDAO dao = new TarifarioDAO();

        public Tarifario crearTarifario(Tarifario nuevoTarifario)
        {

            Tarifario tarifario = dao.Obtener(nuevoTarifario.Co_Tarifa.ToString());
            if (tarifario != null)
                throw new WebFaultException<ValidationException>(
                    new ValidationException()
                    {
                        CodigoError = "E001",
                        MensajeError = "El tarifario ya existe."
                    },
                        HttpStatusCode.InternalServerError
                    );

            return dao.crear(nuevoTarifario);
        }

        public Tarifario obtenerTarifario(string codigo)
        {
            Tarifario tarifario = dao.Obtener(codigo);
            if (tarifario == null)
                throw new WebFaultException<ValidationException>(
                    new ValidationException()
                    {
                        CodigoError = "E002",
                        MensajeError = "El tarifario NO existe."
                    },
                        HttpStatusCode.InternalServerError
                    );
            return tarifario;
        }

        public Tarifario modificarTarifario(Dominio.Tarifario tarifarioAModificar)
        {
            return dao.Modificar(tarifarioAModificar);
        }

        public void eliminarTarifario(string codigo)
        {
            dao.Eliminar(new Tarifario() { Co_Tarifa = int.Parse(codigo) });
        }

        public List<Tarifario> listarTarifarios()
        {
            return dao.ListarTodos();
        }
    }
}
