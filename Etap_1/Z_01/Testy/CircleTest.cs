using System;
using Logika;
using Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testy
{
    [TestClass()]
    public class CircleTest
    {
    [TestMethod]
    public void CircleTests()
        {
            Orb orb = new Orb(3, 4, 5);
            Circle circle = new Circle(orb);
            Assert.AreEqual(orb.X, circle.X);
            Assert.AreEqual(orb.Y, circle.Y);  
            Assert.AreEqual(orb.Radius, circle.Radius);
        }
    }
}
