using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logika;

namespace Testy
{
    [TestClass]
    public class OrbTest
    {
        Orb orb = new Orb(5, 10, 15);

        [TestMethod]
        public void GetterTest()
        {
            Assert.AreEqual(5, orb.X);
            Assert.AreEqual(10, orb.Y);
            Assert.AreEqual(15, orb.Radius);
        }

        [TestMethod]
        public void SetterTest()
        {
            orb.X = 10;
            orb.Y = 15;
            orb.Radius = 20;

            Assert.AreEqual(10, orb.X);
            Assert.AreEqual(15, orb.Y);
            Assert.AreEqual(20, orb.Radius);
        }
    }
}