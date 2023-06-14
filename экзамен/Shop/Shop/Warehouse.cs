using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public class Warehouse
    {
        Dictionary<Comodity, int> dict;

        public Warehouse(string[] records, PriceList list)
        {
            // Конструктор дожен по записям в фомате категория, название, количество
            // (именно в этом порядке) и по заданному прайс-листу заполнить словаь склада товарами
            // На склад дожлны быть помещены только товары, имеющиеся в прайс-листе.

            // проверить, что массив не пустой и не null
            if (records == null || records.Length == 0)
                throw new Exception("Массив не может быть пустым или null");

            // создать словарь склада
            dict = new Dictionary<Comodity, int>();

            // для каждой строки в массиве
            foreach (string record in records)
            {
                // разбить строку по символу табуляции
                string[] parts = record.Split('\t');

                // проверить, что строка содержит три части
                if (parts.Length != 3)
                    throw new Exception("Строка должна содержать три части, разделенные табуляцией");

                // преобразовать третью часть в целое число
                int quantity;
                if (!int.TryParse(parts[2], out quantity))
                    throw new Exception("Количество должно быть целым числом");

                // найти товар в прайс-листе по категории и имени
                Comodity comodity = list.Get(parts[0], parts[1]);

                // если такой товар есть в прайс-листе
                if (comodity != null)
                {
                    // добавить товар и его количество в словарь склада
                    dict.Add(comodity, quantity);
                }
            }
        }

        public void Add(Comodity comodity, int count)
        {
            // Метод должен добавлять на склад товар в указанном количестве

            // проверить, что товар и количество не null и не отрицательное
            if (comodity == null || count < 0)
                throw new ArgumentException("Товар и количество не могут быть null или отрицательными");

            // если товар уже есть на складе
            if (dict.ContainsKey(comodity))
            {
                // увеличить его количество на заданное значение
                dict[comodity] += count;
            }
            else
            {
                // иначе добавить товар и его количество в словарь склада
                dict.Add(comodity, count);
            }
        }

        public void Sale(Comodity comodity, int count)
        {
            // Метод должен регистрировать продажу товара со склада.
            // Если такого товара нет, то дожно выбрасываться исключение
            // с сообщением "Необходимого товара нет на складе".
            // Если товар есть, но в недостаточном количестве,
            // то должно выбрасываться исключение
            // с сообщением "Необходимого количества нет на складе".
            // Если товар полностью распродан, он не долен числиться на складе.

            // проверить, что товар и количество не null и не отрицательное
            if (comodity == null || count < 0)
                throw new ArgumentException("Товар и количество не могут быть null или отрицательными");

            // если товар есть на складе
            if (dict.ContainsKey(comodity))
            {
                // если его количество больше или равно заданному
                if (dict[comodity] >= count)
                {
                    // уменьшить его количество на заданное значение
                    dict[comodity] -= count;

                    // если товар полностью распродан
                    if (dict[comodity] == 0)
                    {
                        // удалить его из словаря склада
                        dict.Remove(comodity);
                    }
                }
                else
                {
                    // иначе выбросить исключение с сообщением "Необходимого количества нет на складе"
                    throw new Exception("Необходимого количества нет на складе");
                }
            }
            else
            {
                // иначе выбросить исключение с сообщением "Необходимого товара нет на складе"
                throw new Exception("Необходимого товара нет на складе");
            }
        }



        public int Count(Comodity comodity)
        {
            // Метод должен подсчитывать количество заданного товара на складе;

            // проверить, что товар не null
            if (comodity == null)
                throw new ArgumentException("Товар не может быть null");

            // если товар есть на складе
            if (dict.ContainsKey(comodity))
            {
                // вернуть его количество
                return dict[comodity];
            }
            else
            {
                // иначе вернуть ноль
                return 0;
            }
        }

        public int CountAll()
        {
            // Метод должен подсчитывать общее количество товаров на складе;

            // использовать LINQ для суммирования всех значений в словаре склада
            int total = dict.Values.Sum();

            // вернуть общее количество
            return total;
        }
    }
}
