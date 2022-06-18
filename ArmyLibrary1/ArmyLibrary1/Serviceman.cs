using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army
{
    public enum ServiceType
    {
        Draft,
        Contract
    }

    public class Serviceman
    {
        public string Name;
        public string Surname;
        public readonly int Number;

        public string Rank;
        public int Unit;
        public DateTime StartDate;

        public int ServiceTime
        {
            get
            {
                TimeSpan Span = DateTime.Today - StartDate;
                return Span.Days;
            }
        }

        public ServiceType Type;

        public Serviceman(string name, string surname, int number)
        {
            Name = name;
            Surname = surname;
            Number = number;
        }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }

        public virtual string[] GetInfo()
        {
            var info = new string[2];
            info[0] = ToString();

            string type;
            if (Type == ServiceType.Contract)
                type = "контрактная";
            else
                type = "срочная";

            info[1] = $"Номер военного билета: {Number}. Звание: {Rank}. Номер воинской части: {Unit}. Дата поступления на службу: {StartDate:d}. Срок службы: {ServiceTime}. Тип службы: {type}.";
            return info;
        }
    }
}

