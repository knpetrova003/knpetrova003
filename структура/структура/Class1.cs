using System;
// Файл Food.cs
using MyLibrary;

namespace MyLibrary
{
    // Структура Food (продукт питания)
    public struct Food // здесь заменить class на struct
    {
        // Поля / свойства структуры
        // Weight (вес продукта питания в граммах) — положительное целое число
        public int Weight { get; set; }
        // Calorie (калорийность —количество килокалорий в 100 г продукта) — положительное число с плавающей точкой, округленное до одного знака после запятой
        public double Calorie { get; set; }
        // Value— количество килокалорий в данном продукте; только для чтения
        public double Value => Weight * Calorie * 0.01;

        // Конструктор с параметрами для задания значений полей / свойств
        public Food(int weight, double calorie)
        {
            Weight = weight;
            Calorie = calorie;
        }

        // Переопределение метода ToString() для возвращения строкового представления структуры
        public override string ToString()
        {
            return $"{Weight} г калорийности {Calorie} Ккал/100 г";
        }

        // Переопределение метода Equals() для сравнения двух продуктов по их весу и калорийности
        public override bool Equals(object obj)
        {
            if (obj is Food other)
            {
                return Weight == other.Weight && Calorie == other.Calorie;
            }
            return false;
        }


        // Переопределение оператора + для сложения продуктов одинаковой калорийности
        public static Food operator +(Food a, Food b)
        {
            if (a.Calorie != b.Calorie)
            {
                throw new ArgumentException("Нельзя складывать продукты разной калорийности");
            }
            return new Food(a.Weight + b.Weight, a.Calorie);
        }

        // Переопределение оператора - для вычитания продуктов одинаковой калорийности
        public static Food operator -(Food a, Food b)
        {
            if (a.Calorie != b.Calorie)
            {
                throw new ArgumentException("Нельзя вычитать продукты разной калорийности");
            }
            if (a.Weight < b.Weight)
            {
                throw new ArgumentException("Нельзя вычитать продукт с большим весом");
            }
            return new Food(a.Weight - b.Weight, a.Calorie);
        }
    }
}

