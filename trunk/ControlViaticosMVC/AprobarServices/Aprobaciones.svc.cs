using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AprobarServices.Dominio;
using AprobarServices.Persistencia;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace AprobarServices
{    
    public class Aprobaciones : IAprobaciones
    {
        private AprobarDAO aprobarDAO = null;
        private AprobarDAO AprobarDAO
        {
            get
            {
                if (aprobarDAO == null)
                    aprobarDAO = new AprobarDAO();
                return aprobarDAO;
            }
        }

        private EmpleadoDAO empleadoDAO = null;
        private EmpleadoDAO EmpleadoDAO
        {
            get
            {
                if (empleadoDAO == null)
                    empleadoDAO = new EmpleadoDAO();
                return empleadoDAO;
            }
        }

        private UbigeoDAO ubigeoDAO = null;
        private UbigeoDAO UbigeoDAO
        {
            get
            {
                if (ubigeoDAO == null)
                    ubigeoDAO = new UbigeoDAO();
                return ubigeoDAO;
            }
        }

        public Aprobar ObtenerSolicitud(int codigoSolicitud)
        {
            return AprobarDAO.Obtener(codigoSolicitud);
        }

        public Aprobar ModificarSolicitud(int codigoSolicitud, int codigoEmpleadoSolicitante, int codigoUbigeoOrigen, int codigoUbigeoDestino, DateTime fechaSolicitud, DateTime fechaSalida, DateTime fechaRetorno, string sustentoViaje, double totalSolicitado, string flagAprobado, DateTime feAprobado, int CodigoEmpleadoAprueba)
        {
            Empleado empleadoObt = EmpleadoDAO.Obtener(codigoEmpleadoSolicitante);
            Ubigeo ubigeoO = UbigeoDAO.Obtener(codigoUbigeoOrigen);
            Ubigeo ubigeoD = UbigeoDAO.Obtener(codigoUbigeoDestino);
            
            // 1. Se obtiene el estado de Aprobación (y demás campos).
            Aprobar aprobarAModificar = new Aprobar()
            {
                CodigoSolicitud = codigoSolicitud,
                FechaSolicitud = fechaSolicitud,
                empleado = empleadoObt,
                ubigeoOrigen = ubigeoO,
                ubigeoDestino = ubigeoD,
                FechaSalida = fechaSalida,
                FechaRetorno = fechaRetorno,
                SustentoViaje = sustentoViaje,
                TotalSolicitado = totalSolicitado,
                FlagAprobado = flagAprobado,
                FeAprobado = feAprobado,
                CodigoEmpleadoAprueba = CodigoEmpleadoAprueba
            };

            // 2. Se verifica si existe presupuesto para el Area del comisionado solicitante.
            HttpWebRequest req = (HttpWebRequest)WebRequest
            .Create("http://localhost:2181/PresupuestoService.svc/Presupuestos/3");
            req.Method = "GET";

            try
            {
                // 3. Si existe Presupuesto para el Area, se verifica que el monto disponible.
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string presupuestoJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Presupuesto presupuestoObtenido = js.Deserialize<Presupuesto>(presupuestoJson);

                // 5. Si el monto solicitado es mayor o igual al monto disponible, se manda execpcion, caso contrario se Aprueba.
                if ( aprobarAModificar.TotalSolicitado > presupuestoObtenido.Ss_MontoDisponible)
                    throw new WebFaultException<ValidationException>(
                        new ValidationException()
                        {
                            CodigoError = "E003",
                            MensajeError = "El monto solicitado es mayor al presupuesto aprobado."
                        },
                            HttpStatusCode.InternalServerError
                        );
            }
            catch (WebException e)
            {
                // 4. En caso NO existe Presupuesto para el Area, se muestra mensaje.
                HttpWebResponse resError1 = (HttpWebResponse)e.Response;
                StreamReader readerError1 = new StreamReader(resError1.GetResponseStream());
                string error = readerError1.ReadToEnd();
                JavaScriptSerializer jsError1 = new JavaScriptSerializer();
                ValidationException excepcion = jsError1.Deserialize<ValidationException>(error);

                throw new WebFaultException<ValidationException>(
                     new ValidationException()
                     {
                         CodigoError = excepcion.CodigoError,
                         MensajeError = excepcion.MensajeError
                     },
                         HttpStatusCode.InternalServerError
                     );
                
            }
            //////////////

            return AprobarDAO.Modificar(aprobarAModificar);
        }

        public List<Aprobar> ListarSolicitudes()
        {
            return AprobarDAO.ListarTodos().ToList();
        }

        public List<Ubigeo> ListarUbigeos()
        {
            return UbigeoDAO.ListarTodos().ToList();
        }
    }
}
