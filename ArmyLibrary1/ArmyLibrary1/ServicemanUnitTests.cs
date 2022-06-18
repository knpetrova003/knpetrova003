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
        public void ToStringTest()
        {
            var snake = CreateTestServiceman();
            Assert.AreEqual("Солид Снейк", snake.ToString());
        }

        [Test]
        public void GetInfoTest()
        {
            var snake = CreateTestServiceman();

            snake.Rank = "солдат специального назначения";
            snake.Unit = 61524;
            snake.StartDate = new DateTime(1987, 7, 13);
            snake.Type = ServiceType.Contract;
            var info = snake.GetInfo();

            Assert.AreEqual(2, info.Length);
            Assert.AreEqual("Солид Снейк", info[0]);
            Assert.AreEqual($"Номер военного билета: 0. Звание: солдат специального назначения. Номер воинской части: 61524. Дата поступления на службу: 13.07.1987. Срок службы: {snake.ServiceTime}. Тип службы: контрактная.", info[1]);
        }

        private Serviceman CreateTestServiceman()
        {
            return new Serviceman("Солид", "Снейк", 0);
        }
    }
}


