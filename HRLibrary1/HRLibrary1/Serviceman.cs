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

        public void PrintInfo()
        {
            Console.WriteLine($"{Rank} {this} ({Number})");

            var type = "";
            switch (Type)
            {
                case ServiceType.Contract:
                    type = "контрактная";
                    break;
                case ServiceType.Draft:
                    type = "срочная";
                    break;
            }

            Console.WriteLine($"Номер воинской части: {Unit}\nДата поступления на службу: {StartDate}\nСрок службы: {ServiceTime}\nТип службы: {type}");
        }
    }
}
