using NUnit.Framework;
using Model;

namespace UnitTests.Model
{
    [TestFixture]
    class ResistorTest
    {
        [Test]
        [TestCase(-10, TestName = "R = -10")]
        [TestCase(-5, TestName = "R = -5")]
        [TestCase(0, TestName = "R = 0")]
        [TestCase(50, TestName = "R = 50")]
        [TestCase(103, TestName = "R = 103")]
        public void RTest(float velue)
        {
            var element = new Resistor(velue);
        }
    }
}
