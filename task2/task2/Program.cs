using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите длину стороны:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine($"Объем икосаэдра:{(5 * (3 + Math.Sqrt(5)) * a * a * a) / 12}");
            Console.WriteLine($"Площадь треугольника:{(5 * a * a * Math.Sqrt(3))}");
            Console.ReadKey();
        }
    }
}

