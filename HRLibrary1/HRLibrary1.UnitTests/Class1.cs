using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Army;
using NUnit.Framework;

namespace Army.UnitTests
{
    [TestFixture]
    public class ServicemanUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var snake = CreateTestServiceman();

            Assert.AreEqual("Солид", snake.Name);
            Assert.AreEqual("Снейк", snake.Surname);
            Assert.AreEqual(0, snake.Number);
        }

        [Test]
        public void TratesTest()
        {
            var snake = CreateTestServiceman();

            snake.Rank = "солдат специального назначения";
            snake.Unit = 61524;
            snake.StartDate = new DateTime(1987, 7, 13);
            snake.Type = ServiceType.Contract;

            Assert.AreEqual("солдат специального назначения", snake.Rank);
            Assert.AreEqual(61524, snake.Unit);
            Assert.AreEqual(new DateTime(1987, 7, 13), snake.StartDate);
            Assert.AreEqual(12748, snake.ServiceTime);
            Assert.AreEqual(ServiceType.Contract, snake.Type);
        }

        [Test]
        public void ToStringTest()
        {
            var snake = CreateTestServiceman();
            Assert.AreEqual("Солид Снейк", snake.ToString());
        }

        private Serviceman CreateTestServiceman()
        {
            return new Serviceman("Солид", "Снейк", 0);
        }
    }
}


