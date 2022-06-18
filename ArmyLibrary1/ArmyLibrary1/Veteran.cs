using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army
{
    public class Veteran : Serviceman
    {
        public string Seniority;
        public string Pension;

        public Veteran(string name, string surname, int number, string seniority, string pension) : base(name, surname, number)
        {
            Seniority = seniority;
            Pension = pension;
        }

        public override string[] GetInfo()
        {
            var info = base.GetInfo();
            info[1] += $"\nВыслуга лет: {Seniority}. Размер пенсии: {Pension}";
            return info;
        }
    }
}
