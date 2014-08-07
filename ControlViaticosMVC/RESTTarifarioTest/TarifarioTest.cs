using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;


namespace RESTTarifarioTest
{
    [TestClass]
    public class TarifarioTest
    {
        [TestMethod]
        public void ObtenerTarifario()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:63966/TarifarioService.svc/Tarifarios/1");
            req.Method = "GET";

            try
            {
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string tarifarioJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Tarifario tarifarioObtenido = js.Deserialize<Tarifario>(tarifarioJson);
                Assert.AreEqual("1", tarifarioObtenido.Co_EmpActualiza.ToString());
                Assert.AreEqual("2", tarifarioObtenido.Co_Ubigeo.ToString());
            }
            catch (WebException e)
            {
                HttpWebResponse resError1 = (HttpWebResponse)e.Response;
                StreamReader readerError1 = new StreamReader(resError1.GetResponseStream());
                string error = readerError1.ReadToEnd();
                JavaScriptSerializer jsError1 = new JavaScriptSerializer();
                ValidationException excepcion = jsError1.Deserialize<ValidationException>(error);
                Assert.AreEqual("El tarifario no existe.", excepcion.MensajeError);
            }
        }

        [TestMethod]
        public void crearTarifario()
        {

            string postdata = "{\"Co_Tarifa\":\"2\",\"Co_TipoViatico\":\"1\",\"Co_Ubigeo\":\"3\",\"Ss_Costo\":\"450\",\"Co_EmpActualiza\":\"1\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req1 = (HttpWebRequest)WebRequest.Create("http://localhost:63966/TarifarioService.svc/Tarifarios");
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
                Tarifario tarifario = js1.Deserialize<Tarifario>(presupuestoJson1);
                Assert.AreEqual("2", tarifario.Co_Tarifa.ToString());
                Assert.AreEqual("1", tarifario.Co_TipoViatico.ToString());
                Assert.AreEqual("450.00", tarifario.Ss_Costo.ToString());
                Assert.AreEqual("1", tarifario.Co_EmpActualiza.ToString());
            }
            catch (WebException e)
            {
                HttpWebResponse resError1 = (HttpWebResponse)e.Response;
                StreamReader readerError1 = new StreamReader(resError1.GetResponseStream());
                string error = readerError1.ReadToEnd();
                JavaScriptSerializer jsError1 = new JavaScriptSerializer();
                ValidationException excepcion = jsError1.Deserialize<ValidationException>(error);
                Assert.AreEqual("El tarifario ya existe en el sistema.", excepcion.MensajeError);
            }
        }

        [TestMethod]
        public void modificarTarifario()
        {
            string postdata = "{\"Co_Tarifa\":\"2\",\"Co_TipoViatico\":\"1\",\"Co_Ubigeo\":\"2\",\"Ss_Costo\":\"850\",\"Co_EmpActualiza\":\"1\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req1 = (HttpWebRequest)WebRequest.Create("http://localhost:63966/TarifarioService.svc/Tarifarios");
            req1.Method = "PUT";
            req1.ContentLength = data.Length;
            req1.ContentType = "application/json";
            var reqStream = req1.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res1 = null;

            res1 = (HttpWebResponse)req1.GetResponse();
            StreamReader reader1 = new StreamReader(res1.GetResponseStream());
            string tarifarioJson1 = reader1.ReadToEnd();
            JavaScriptSerializer js1 = new JavaScriptSerializer();
            Tarifario tarifario = js1.Deserialize<Tarifario>(tarifarioJson1);
            Assert.AreEqual("2", tarifario.Co_Tarifa.ToString());
            Assert.AreEqual("1", tarifario.Co_TipoViatico.ToString());
            Assert.AreEqual("450.00", tarifario.Ss_Costo.ToString());
            Assert.AreEqual("1", tarifario.Co_EmpActualiza.ToString());

        }

        [TestMethod]
        public void elimiarPresupuesto()
        {
            HttpWebRequest reqDelete = (HttpWebRequest)WebRequest.Create("http://localhost:63966/TarifarioService.svc/Tarifarios/2");
            reqDelete.Method = "DELETE";
            HttpWebResponse resDelete = (HttpWebResponse)reqDelete.GetResponse();

            //Para verificar si existe el presupuesto eliminado, 
            //se reutiliza el método GET al cual se le incluyó una exepción.


            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:63966/TarifarioService.svc/Tarifarios/2");
            req.Method = "GET";

            try
            {
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string tarifarioJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Tarifario tarifario = js.Deserialize<Tarifario>(tarifarioJson);
                Assert.AreEqual("2", tarifario.Co_Tarifa.ToString());
                Assert.AreEqual("1", tarifario.Co_TipoViatico.ToString());
            }
            catch (WebException e)
            {
                HttpWebResponse resError1 = (HttpWebResponse)e.Response;
                StreamReader readerError1 = new StreamReader(resError1.GetResponseStream());
                string error = readerError1.ReadToEnd();
                JavaScriptSerializer jsError1 = new JavaScriptSerializer();
                ValidationException excepcion = jsError1.Deserialize<ValidationException>(error);
                Assert.AreEqual("El tarifario NO existe.", excepcion.MensajeError);
            }
        }

        [TestMethod]
        public void ListarPresupuestos()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:63966/TarifarioService.svc/Tarifarios");
            req.Method = "GET";

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string tarifarioJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Tarifario> tarifarios = js.Deserialize<List<Tarifario>>(tarifarioJson);

            Assert.AreEqual("1", tarifarios.Count.ToString());

        }
    }
}
