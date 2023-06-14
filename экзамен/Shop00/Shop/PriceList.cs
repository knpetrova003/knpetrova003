using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public class PriceList
    {
        List<Comodity> list;

        public PriceList(string[] records)
        {
            // Конструктор должен заполнять список товаров
            // по массиву строк в формате категория, название, цена (в этом порядке),
            // разделенные табуляцией.

            // проверить, что массив не пустой и не null
            if (records == null || records.Length == 0)
                throw new ArgumentException("Массив не может быть пустым или null");

            // создать список товаров
            list = new List<Comodity>();

            // для каждой строки в массиве
            foreach (string record in records)
            {
                // преобразовать строку в объект товара с помощью метода Parse
                Comodity comodity = Comodity.Parse(record);

                // добавить товар в список
                list.Add(comodity);
            }
        }

        public PriceList()
        {
            list = new List<Comodity>();
        }

        public Comodity Get(string category, string name)
        {
            // Метод должен вернуть товар, соответсвующий заданным категории и имени
            // Если такого товара нет, то должен возвращаться null

            // проверить, что категория и имя не пустые и не null
            if (string.IsNullOrEmpty(category) || string.IsNullOrEmpty(name))
                throw new ArgumentException("Категория и имя не могут быть пустыми или null");

            // использовать LINQ для поиска товара по категории и имени с учетом регистра
            Comodity comodity = list.FirstOrDefault(c => c.Category == category && c.Name == name);

            // вернуть найденный товар или null, если такого нет
            return comodity;
        }

        public List<Comodity> GetMany(string category, string name)
        {
            // Метод должен вернуть список товаров, соответсвующий заданным категории и имени
            // Если таких товаров нет, то должнен возпращаться пустой список.
            // Поиск должен быть контекстным и независимым от регистра.

            // проверить, что категория и имя не null
            if (category == null || name == null)
                throw new ArgumentException("Категория и имя не могут быть null");

            // использовать LINQ для поиска товаров по категории и имени без учета регистра
            List<Comodity> comodities = list.Where(c => c.Category.IndexOf(category, StringComparison.OrdinalIgnoreCase) >= 0 &&
                                                         c.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            // вернуть найденный список или пустой список, если таких нет
            return comodities;
        }
    }
}
