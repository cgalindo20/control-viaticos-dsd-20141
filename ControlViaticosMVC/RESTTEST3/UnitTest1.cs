using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace RESTTEST3
{
    
    [TestClass]
    public class PresupuestoTest
    {
    
        [TestMethod]
        public void ObtenerPresupuesto()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:2181/PresupuestoService.svc/Presupuestos/1");
            req.Method = "GET";
            
            try
            {
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string presupuestoJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Presupuesto presupuestoObtenido = js.Deserialize<Presupuesto>(presupuestoJson);
                Assert.AreEqual("1", presupuestoObtenido.Co_Presupuesto.ToString());
                Assert.AreEqual("1", presupuestoObtenido.Co_Area.ToString());
            }
            catch (WebException e)
            {
                HttpWebResponse resError1 = (HttpWebResponse)e.Response;
                StreamReader readerError1 = new StreamReader(resError1.GetResponseStream());
                string error = readerError1.ReadToEnd();
                JavaScriptSerializer jsError1 = new JavaScriptSerializer();
                ValidationException excepcion = jsError1.Deserialize<ValidationException>(error);
                Assert.AreEqual("El Presupuesto NO existe.", excepcion.MensajeError);
            }
        }

        [TestMethod]
        public void CrearPresupuesto() {
            
            string postdata = "{\"Co_Presupuesto\":\"8\",\"Co_Area\":\"3\",\"Ss_MontoAsignado\":\"120\",\"Ss_MontoDisponible\":\"80\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req1 = (HttpWebRequest)WebRequest
                .Create("http://localhost:2181/PresupuestoService.svc/Presupuestos");
            req1.Method = "POST";
            req1.ContentLength = data.Length;
            req1.ContentType = "application/json";
            var reqStream = req1.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res1 = null;

            try
            {
                res1 = (HttpWebResponse)req1.GetResponse();
                StreamReader reader1 = new StreamReader(res1.GetResponseStream());
                string presupuestoJson1 = reader1.ReadToEnd();
                JavaScriptSerializer js1 = new JavaScriptSerializer();
                Presupuesto presupuestoCreado = js1.Deserialize<Presupuesto>(presupuestoJson1);
                Assert.AreEqual("8", presupuestoCreado.Co_Presupuesto.ToString());
                Assert.AreEqual("3", presupuestoCreado.Co_Area.ToString());
                Assert.AreEqual("120", presupuestoCreado.Ss_MontoAsignado.ToString());
                Assert.AreEqual("80", presupuestoCreado.Ss_MontoDisponible.ToString());
            }
            catch (WebException e)
            {
                HttpWebResponse resError1 = (HttpWebResponse)e.Response;
                StreamReader readerError1 = new StreamReader(resError1.GetResponseStream());
                string error = readerError1.ReadToEnd();
                JavaScriptSerializer jsError1 = new JavaScriptSerializer();
                // decia:   
                //string errorMessage = jsError1.Deserialize<string>(error);
                //Assert.AreEqual("El Presupuesto ya existe.", errorMessage);
                ValidationException excepcion = jsError1.Deserialize<ValidationException>(error);
                Assert.AreEqual("El Presupuesto ya existe.", excepcion.MensajeError);
            }
        }

        [TestMethod]
        public void ModificarPresupuesto()
        {
            string postdata = "{\"Co_Presupuesto\":\"8\",\"Co_Area\":\"3\",\"Ss_MontoAsignado\":\"220\",\"Ss_MontoDisponible\":\"180\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req1 = (HttpWebRequest)WebRequest
                .Create("http://localhost:2181/PresupuestoService.svc/Presupuestos");
            req1.Method = "PUT";
            req1.ContentLength = data.Length;
            req1.ContentType = "application/json";
            var reqStream = req1.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res1 = null;

            res1 = (HttpWebResponse)req1.GetResponse();
            StreamReader reader1 = new StreamReader(res1.GetResponseStream());
            string presupuestoJson1 = reader1.ReadToEnd();
            JavaScriptSerializer js1 = new JavaScriptSerializer();
            Presupuesto presupuestoCreado = js1.Deserialize<Presupuesto>(presupuestoJson1);
            Assert.AreEqual("8", presupuestoCreado.Co_Presupuesto.ToString());
            Assert.AreEqual("3", presupuestoCreado.Co_Area.ToString());
            Assert.AreEqual("120", presupuestoCreado.Ss_MontoAsignado.ToString());
            Assert.AreEqual("80", presupuestoCreado.Ss_MontoDisponible.ToString());
           
        }


        [TestMethod]
        public void EliminarPresupuesto()
        {
            HttpWebRequest reqDelete = (HttpWebRequest)WebRequest
                .Create("http://localhost:2181/PresupuestoService.svc/Presupuestos/3");
            reqDelete.Method = "DELETE";
            HttpWebResponse resDelete = (HttpWebResponse)reqDelete.GetResponse();
            
            //Para verificar si existe el presupuesto eliminado, 
            //se reutiliza el método GET al cual se le incluyó una exepción.


            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:2181/PresupuestoService.svc/Presupuestos/3");
            req.Method = "GET";

            try
            {
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string presupuestoJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Presupuesto presupuestoObtenido = js.Deserialize<Presupuesto>(presupuestoJson);
                Assert.AreEqual("3", presupuestoObtenido.Co_Presupuesto.ToString());
                Assert.AreEqual("3", presupuestoObtenido.Co_Area.ToString());
            }
            catch (WebException e)
            {
                HttpWebResponse resError1 = (HttpWebResponse)e.Response;
                StreamReader readerError1 = new StreamReader(resError1.GetResponseStream());
                string error = readerError1.ReadToEnd();
                JavaScriptSerializer jsError1 = new JavaScriptSerializer();
                ValidationException excepcion = jsError1.Deserialize<ValidationException>(error);
                Assert.AreEqual("El Presupuesto NO existe.", excepcion.MensajeError);
            }
        }

        [TestMethod]
        public void ListarPresupuestos()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:2181/PresupuestoService.svc/Presupuestos");
            req.Method = "GET";

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string presupuestoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Presupuesto> listPresupuestoObtenido = js.Deserialize<List<Presupuesto>>(presupuestoJson);

            Assert.AreEqual("5", listPresupuestoObtenido.Count.ToString());
            
        }
    }
}
