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
    public class ControlUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var boss = CreateTestControl();

            Assert.AreEqual("Биг", boss.Name);
            Assert.AreEqual("Босс", boss.Surname);
            Assert.AreEqual(0, boss.Number);
            Assert.AreEqual("Западный военный округ", boss.CountyName);
            Assert.AreEqual("лейтенант", boss.Office);
        }

        [Test]
        public void ToStringTest()
        {
            var boss = CreateTestControl();
            Assert.AreEqual("Биг Босс", boss.ToString());
        }

        [Test]
        public void GetInfoTest()
        {
            var boss = CreateTestControl();

            boss.Rank = "лейтенант";
            boss.Unit = 611312;
            boss.StartDate = new DateTime(1987, 8, 13);
            boss.Type = ServiceType.Contract;
            var info = boss.GetInfo();

            Assert.AreEqual(2, info.Length);
            Assert.AreEqual("Биг Босс", info[0]);
            Assert.AreEqual($"Номер военного билета: 0. Звание: лейтенант. Номер воинской части: 611312. Дата поступления на службу: 13.08.1987. Срок службы: {boss.ServiceTime}. Тип службы: контрактная.\nНазвание округа: Западный военный округ. Должность: лейтенант", info[1]);
        }

        private Control CreateTestControl()
        {
            return new Control("Биг", "Босс", 0, "Western Military County", "лейтенант");
        }
    }
}