using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logika;

namespace Testy
{
    [TestClass]
    public class SceneTest
    {
        Scene scene = new Scene(500, 250);
        [TestMethod]
        public void GetterTest()
        {
            Assert.AreEqual(500, scene.Width);
            Assert.AreEqual(250, scene.Height);

            scene.GenerateOrbList(5, 25);

            Assert.AreEqual(5, scene.Orbs.Count);
            Assert.AreEqual(25, scene.Orbs[0].Radius);

            Assert.AreEqual(false, scene.Enabled);
        }

        [TestMethod]
        public void SetterTest()
        {
            scene.Enabled = true;

            Assert.AreEqual(true, scene.Enabled);
        }
    }
}
