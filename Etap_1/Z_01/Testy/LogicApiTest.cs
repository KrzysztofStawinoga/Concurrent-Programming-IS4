using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Logika;

namespace Logic.Tests
{
    [TestClass]
    public class LogicApiTest
    {
        [TestMethod]
        public void GeneralLogicApiTest()
        {
            AbstractLogicApi api = AbstractLogicApi.CreateApi();
            api.CreateScene(500, 250, 5, 25);
            //List<Orb> orbList = api.GetOrbs();
            Assert.AreEqual(5, api.GetOrbs().Count);
            Assert.AreEqual(25, api.GetOrbs()[0].Radius);

            Assert.IsFalse(api.IsEnabled());
            
            api.Enable();
            Assert.IsTrue(api.IsEnabled());

            api.Disable();
            Assert.IsFalse(api.IsEnabled());
        }

    }
}