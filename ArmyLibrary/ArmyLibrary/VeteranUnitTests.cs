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
    public class VeteranUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var boss = CreateTestVeteran();

            Assert.AreEqual("Биг", boss.Name);
            Assert.AreEqual("Босс", boss.Surname);
            Assert.AreEqual(0, boss.Number);
            Assert.AreEqual("30", boss.Seniority);
            Assert.AreEqual("35000", boss.Pension);
        }

        [Test]
        public void ToStringTest()
        {
            var boss = CreateTestVeteran();
            Assert.AreEqual("Биг Босс", boss.ToString());
        }

        [Test]
        public void GetInfoTest()
        {
            var boss = CreateTestVeteran();

            boss.Rank = "лейтенант";
            boss.Unit = 2374;
            boss.StartDate = new DateTime(1977, 7, 13);
            boss.Type = ServiceType.Contract;
            var info = boss.GetInfo();

            Assert.AreEqual(2, info.Length);
            Assert.AreEqual("Биг Босс", info[0]);
            Assert.AreEqual($"Номер военного билета: 0. Звание: лейтенант. Номер воинской части: 2374. Дата поступления на службу: 13.07.1977. Срок службы: {boss.ServiceTime}. Тип службы: контрактная.\nВыслуга лет: 30. Размер пенсии: 35000", info[1]);
        }

        private Veteran CreateTestVeteran()
        {
            return new Veteran("Биг", "Босс", 0, "30", "35000");
        }
    }
}