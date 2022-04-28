using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Logika;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace Testy
{
    [TestClass()]
    public class ModelApiTest
    {
        [TestMethod()]
        public void GeneralModelApiTest()
        {
            AbstractLogicApi logicApi = AbstractLogicApi.CreateApi();
            AbstractModelApi modelApi = AbstractModelApi.CreateApi(logicApi);
            modelApi.CreateScene(10, 5);
            ObservableCollection<Circle> collection = modelApi.GetAllCircles();
            Assert.IsNotNull(collection);
            Assert.AreEqual(10, collection.Count);
            foreach (Circle c in collection)
            {
                Assert.AreEqual(5, c.Radius);
            }

            Assert.IsFalse(modelApi.IsEnabled());

            modelApi.Enable();
            Assert.IsTrue(modelApi.IsEnabled());

            modelApi.Disable();
            Assert.IsFalse(modelApi.IsEnabled());
        }
    }
}
