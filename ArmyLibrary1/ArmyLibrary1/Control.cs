using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army
{
    public class Control : Serviceman
    {
        public string CountyName;
        public string Office;

        public Control(string name, string surname, int number, string CountyName, string office) : base(name, surname, number)
        {
            CountyName = CountyName;
            Office = office;
        }

        public override string[] GetInfo()
        {
            var info = base.GetInfo();
            info[1] += $"\nНазвание округа: {CountyName}. Должность: {Office}";
            return info;
        }
    }
}