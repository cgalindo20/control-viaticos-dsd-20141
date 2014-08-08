﻿using System;
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
using System.Messaging;

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
        
        public Aprobar AprobarSolicitud(int codigoSolicitud, int codigoUbigeoOrigen, int codigoUbigeoDestino, DateTime fechaSolicitud, DateTime fechaSalida, DateTime fechaRetorno, string sustentoViaje, double totalSolicitado, string flagAprobado, DateTime feAprobado, int CodigoEmpleadoAprueba)
        {
            Ubigeo ubigeoO = UbigeoDAO.Obtener(codigoUbigeoOrigen);
            Ubigeo ubigeoD = UbigeoDAO.Obtener(codigoUbigeoDestino);
            
            // 1. Se obtiene el estado de Aprobación (y demás campos).
            Aprobar aprobarAModificar = new Aprobar()
            {
                CodigoSolicitud = codigoSolicitud,
                FechaSolicitud = fechaSolicitud,
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

            //Enviar mensaje de Aprobacion o Rechazo
            string rutaColaIn = @".\private$\indestructiblesOut";
            if (!MessageQueue.Exists(rutaColaIn))
                MessageQueue.Create(rutaColaIn);
            MessageQueue colaIn = new MessageQueue(rutaColaIn);
            Message mensajeIn = new Message();
            mensajeIn.Label = "Solicitud de Viatico Aprobada";
            mensajeIn.Body = new ViaticoMsg()
            {
                CodigoSolicitud = aprobarAModificar.CodigoSolicitud,
                FechaSolicitud = aprobarAModificar.FechaSolicitud,
                FlagAprobar = flagAprobado,
                FechaAprobar = feAprobado,
                CodigoEmpleadoAprobar = CodigoEmpleadoAprueba

            };
            colaIn.Send(mensajeIn);

            //return AprobarDAO.Modificar(aprobarAModificar);
            return aprobarAModificar;
        }

        public List<Aprobar> ListarSolicitudes()
        {
            //1. Obtener las Solicitudes de Viaticos para Aprobar
            string rutaColaIn = @".\private$\indestructiblesIn";
            if (!MessageQueue.Exists(rutaColaIn))
                MessageQueue.Create(rutaColaIn);
            MessageQueue colaIn = new MessageQueue(rutaColaIn);
            colaIn.Formatter = new XmlMessageFormatter(new Type[] { typeof(ViaticoMsg) });
            Message mensajeIn = colaIn.Receive();
            ViaticoMsg viaticoMsg = (ViaticoMsg)mensajeIn.Body;
            Console.WriteLine("Asunto Recibido: " + mensajeIn.Label);
            Console.WriteLine("Viatico Recibido: " + viaticoMsg.CodigoSolicitud + ", Total Solicitado: " + viaticoMsg.TotalSolicitado);
            Console.ReadLine();

            //2. Leer la Solicitud y mostrarlo en el List 
            Aprobar[] viaticoArr = new Aprobar[1];

            for (int i = 0; i < 1; i++) //Lo ideal es detectar la cantidad de mensajes y mostrarlos todos
            {
                Aprobar viaticoAprobar = new Aprobar();
                viaticoAprobar.CodigoSolicitud = viaticoMsg.CodigoSolicitud;
                viaticoAprobar.FechaSolicitud = viaticoMsg.FechaSolicitud;
                viaticoAprobar.ubigeoOrigen = viaticoMsg.ubigeoOrigen;
                viaticoAprobar.ubigeoDestino = viaticoMsg.ubigeoDestino;
                viaticoAprobar.FechaSalida = viaticoMsg.FechaSalida;
                viaticoAprobar.FechaRetorno = viaticoMsg.FechaRetorno;
                viaticoAprobar.SustentoViaje = viaticoMsg.SustentoViaje;
                viaticoAprobar.TotalSolicitado = viaticoMsg.TotalSolicitado;
                viaticoArr[i] = viaticoAprobar;
            }

            //
            return viaticoArr.ToList();

        }

        public List<Ubigeo> ListarUbigeos()
        {
            return UbigeoDAO.ListarTodos().ToList();
        }

        public class ViaticoMsg
        {
            public int CodigoSolicitud { get; set; }
            public DateTime FechaSolicitud { get; set; }
            public int CodigoEmpleadoSolicitante { get; set; }
            public Ubigeo ubigeoOrigen { get; set; }
            public Ubigeo ubigeoDestino { get; set; }
            public DateTime FechaSalida { get; set; }
            public DateTime FechaRetorno { get; set; }
            public String SustentoViaje { get; set; }
            public Double TotalSolicitado { get; set; }
            public String FlagAutorizar { get; set; }
            public DateTime FechaAutorizar { get; set; }
            public int CodigoEmpleadoAutorizar { get; set; }
            public String FlagAprobar { get; set; }
            public DateTime FechaAprobar { get; set; }
            public int CodigoEmpleadoAprobar { get; set; }

        }

    }
}
