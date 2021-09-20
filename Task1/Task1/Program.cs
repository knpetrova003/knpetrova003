using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)

        {
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Анна Ахматова Всё расхищено, предано, продано.");
            {
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.Yellow;
                {
                    Console.WriteLine("О, как на склоне наших лет Нежней мы любим и суеверней…");
                    Console.ReadKey();
                    Console.WriteLine("Сияй, сияй, прощальный свет Любви последней, зари вечерней!");
                    Console.ReadKey();
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Анна Ахматова Всё расхищено, предано, продано.");
                        Console.WriteLine("О, как на склоне наших лет Нежней мы любим и суеверней…");
                        Console.WriteLine("Сияй, сияй, прощальный свет Любви последней, зари вечерней!");
                    }
                }
            }

            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

        }
    }
}



