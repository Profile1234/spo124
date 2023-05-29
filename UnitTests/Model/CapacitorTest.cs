using NUnit.Framework;
using Model;

namespace UnitTests.Model
{
    [TestFixture]
    class CapacitorTest
    {
        [Test]
        [TestCase(-10, TestName = "C = -10")]
        [TestCase(-5, TestName = "C = -5")]
        [TestCase(0, TestName = "C = 0")]
        [TestCase((float)0.4, TestName = "C = 0.4")]
        [TestCase(102, TestName = "C = 102")]
        public void CTest(float velue)
        {
            var element = new Capacitor(2, velue);
        }

        [Test]
        [TestCase(-10, TestName = "omega = -10")]
        [TestCase(-5, TestName = "omega = -5")]
        [TestCase(0, TestName = "omega = 0")]
        [TestCase(15, TestName = "omega = 15")]
        [TestCase(103, TestName = "omega = 103")]
        public void omegaTest(float velue)
        {
            var element = new Capacitor(velue, (float)0.000004);
        }
    }
}
