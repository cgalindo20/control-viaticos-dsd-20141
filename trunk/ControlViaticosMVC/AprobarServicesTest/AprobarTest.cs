using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace AprobarServicesTest
{
    [TestClass]
    public class AprobarTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                AprobarWS.AprobacionesClient proxy = new AprobarWS.AprobacionesClient();

                AprobarWS.Aprobar aprobar = new AprobarWS.Aprobar();
                aprobar = proxy.ModificarSolicitud( 3,
                                                    1,
                                                    2,
                                                    3,
                                                    DateTime.Parse("05/08/2014 6:00:00"),
                                                    DateTime.Parse("05/08/2014 6:00:00"),
                                                    DateTime.Parse("05/08/2014 6:00:00"),
                                                    "XXXXX",
                                                    150,
                                                    "A",
                                                    DateTime.Parse("05/08/2014 6:00:00"),
                                                    3);


                Assert.IsNotNull(aprobar);
            }
            catch (FaultException<ValidationException> ex)
            {
                Assert.AreEqual("El monto solicitado es mayor al presupuesto aprobado.", ex.Detail.MensajeError);

            }
        }
    }

}
