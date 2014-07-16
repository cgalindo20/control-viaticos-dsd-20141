using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TarifarioServiceTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                TarifariosServices.TarifariosClient proxy = new TarifariosServices.TarifariosClient();
            }
            catch (Exception e)
            {
            }
        }
    }
}
