using System;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = XY1(1, -1, 2) + XY1(2, -2, 2) + XY1(3, -3, 5) + XY1(4, -4, 3);
            Console.WriteLine(Math.Round(x, 3));
        }
        static double XY1(double n1, double n2, double n3)
        {
            return (n1 + Math.Pow(Math.E, n2)) / n3;
        }
    }
}
