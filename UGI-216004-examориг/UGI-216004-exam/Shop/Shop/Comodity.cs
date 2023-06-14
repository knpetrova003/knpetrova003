using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public class Comodity
    {
        public string Category { get; }
        public string Name { get; }
        public int Price { get; }

        public Comodity(string category, string name, int price)
        {
            Category = category;
            Name = name;
            Price = price;
        }

        public static Comodity Parse(string record)
        {
            // написать метод, который по строке в формате
            // категория, название, цена (в этом порядке), разделенные табуляцией,
            // возвращает объект товара

            // проверить, что строка не пустая и не null
            if (string.IsNullOrEmpty(record))
                throw new ArgumentException("Строка не может быть пустой или null");

            // разбить строку по символу табуляции
            string[] parts = record.Split('\t');

            // проверить, что строка содержит три части
            if (parts.Length != 3)
                throw new FormatException("Строка должна содержать три части, разделенные табуляцией");

            // преобразовать третью часть в целое число
            int price;
            if (!int.TryParse(parts[2], out price))
                throw new FormatException("Цена должна быть целым числом");

            // создать и вернуть объект товара с соответствующими свойствами
            return new Comodity(parts[0], parts[1], price);
        }

        public override string ToString()
        {
            //переопределить метод так, чтобы возвращалась строка в формате
            // категория, название, цена (в этом порядке), разделенные табуляцией

            // использовать интерполяцию строк для формирования результата
            return $"{Category}\t{Name}\t{Price}";
        }

    }
}
