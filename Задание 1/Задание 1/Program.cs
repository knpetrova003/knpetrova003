// Файл Program.cs
using System;
using MyLibrary; // подключение библиотеки с определением структуры Food

namespace MyLibrary
{
    class Program
    {
        private static object halfApple;

        static void Main(string[] args)
        {
            // Создание двух объектов структуры Food с разными параметрами
            Food apple = new Food(100, 52.0);
            Food banana = new Food(150, 89.0);

            // Вывод на консоль строкового представления объектов и их калорийности
            Console.WriteLine($"Яблоко: {apple}, калорийность: {apple.Value} Ккал");
            Console.WriteLine($"Банан: {banana}, калорийность: {banana.Value} Ккал");

            // Обработка исключений при сложении и вычитании продуктов
            try
            {

            // Сложение двух объектов одинаковой калорийности
            Food fruitSalad = apple + banana;
            Console.WriteLine($"Фруктовый салат: {fruitSalad}, калорийность: {fruitSalad.Value} Ккал");

            // Вычитание двух объектов одинаковой калорийности
            Food halfApple = apple - new Food(50, 52.0);
            Console.WriteLine($"Половина яблока: {halfApple}, калорийность: {halfApple.Value} Ккал");

            }
            catch (ArgumentException e)
            {

                // Сравнение двух объектов по их весу и калорийности
                Console.WriteLine($"Яблоко и банан равны? {apple.Equals(banana)}");
            Console.WriteLine($"Яблоко и половина яблока равны? {apple.Equals(halfApple)}");

            // Ожидание нажатия клавиши для завершения программы
            Console.ReadKey();
        }
    }
}
    }
