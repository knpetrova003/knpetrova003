using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army
{
    public class Officer : Serviceman
    {
        public string UnitName;
        public string Office;

        public Officer(string name, string surname, int number, string unitName, string office) : base(name, surname, number)
        {
            UnitName = unitName;
            Office = office;
        }

        public override string[] GetInfo()
        {
            var info = base.GetInfo();
            info[1] += $"\nНазвание подразделения: {UnitName}. Должность: {Office}";
            return info;
        }
    }
}
