using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LiquidarServiceTest.LiquidacionesWS;
using System.ServiceModel;

namespace LiquidarServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                LiquidacionesWS.LiquidacionesClient proxy = new LiquidacionesWS.LiquidacionesClient();

                LiquidacionesWS.Liquidar liquidar = new LiquidacionesWS.Liquidar();
                liquidar = proxy.CrearLiquidacion(DateTime.Parse("14/07/2014 0:00:00"),
                                                    int.Parse("2"),
                                                    Double.Parse("120.00"),
                                                    Double.Parse("100.00"),
                                                    Double.Parse("21.00"));

                Assert.IsNotNull(liquidar);
            }
            catch (FaultException<ValidationException> ex)
            {
                Assert.AreEqual("Otros Gastos no puede ser mayor al 20% del monto utilizado.", ex.Message);

            }
        }
    }
}
