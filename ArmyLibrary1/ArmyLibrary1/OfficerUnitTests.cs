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
    public class OfficerUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var boss = CreateTestOfficer();

            Assert.AreEqual("Биг", boss.Name);
            Assert.AreEqual("Босс", boss.Surname);
            Assert.AreEqual(0, boss.Number);
            Assert.AreEqual("FOXHOUND", boss.UnitName);
            Assert.AreEqual("командир наёмников", boss.Office);
        }

        [Test]
        public void ToStringTest()
        {
            var boss = CreateTestOfficer();
            Assert.AreEqual("Биг Босс", boss.ToString());
        }

        [Test]
        public void GetInfoTest()
        {
            var boss = CreateTestOfficer();

            boss.Rank = "солдат специального назначения";
            boss.Unit = 61524;
            boss.StartDate = new DateTime(1987, 7, 13);
            boss.Type = ServiceType.Contract;
            var info = boss.GetInfo();

            Assert.AreEqual(2, info.Length);
            Assert.AreEqual("Биг Босс", info[0]);
            Assert.AreEqual($"Номер военного билета: 0. Звание: солдат специального назначения. Номер воинской части: 61524. Дата поступления на службу: 13.07.1987. Срок службы: {boss.ServiceTime}. Тип службы: контрактная.\nНазвание подразделения: FOXHOUND. Должность: командир наёмников", info[1]);
        }

        private Officer CreateTestOfficer()
        {
            return new Officer("Биг", "Босс", 0, "FOXHOUND", "командир наёмников");
        }
    }
}
