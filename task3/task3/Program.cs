using System;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("x=");
            double x = Convert.ToDouble(Console.ReadLine());
            double y = Math.Abs(2 * Math.Sin(-3 * Math.Abs((x + 1) / 2)));
            Console.WriteLine("y={0}", y);
            Console.ReadLine();
        }
    }
}
