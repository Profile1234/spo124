using NUnit.Framework;
using Model;

namespace UnitTests.Model
{
    [TestFixture]
    class InductanceTest
    {
        [Test]
        [TestCase(-10, TestName = "L = -10")]
        [TestCase(-5, TestName = "L = -5")]
        [TestCase(0, TestName = "L = 0")]
        [TestCase((float)0.4, TestName = "L = 0.4")]
        [TestCase(103, TestName = "L = 103")]
        public void RTest(float velue)
        {
            var element = new Resistor(velue);
        }

        [Test]
        [TestCase(-10, TestName = "omega = -10")]
        [TestCase(-5, TestName = "omega = -5")]
        [TestCase(0, TestName = "omega = 0")]
        [TestCase(15, TestName = "omega = 15")]
        [TestCase(103, TestName = "omega = 103")]
        public void omegaTest(float velue)
        {
            var element = new Capacitor(velue, (float)0.04);
        }
    }
}
