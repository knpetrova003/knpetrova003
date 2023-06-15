using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_6
{
    // Класс для задания с текстом
    public class TextTask
    {
        // Метод для составления словаря количества вхождений различных букв в текст
        public Dictionary<char, int> GetLetterCount(string[] lines)
        {
            // Создаем пустой словарь
            var dict = new Dictionary<char, int>();
            // Проходим по всем строкам текста
            foreach (var line in lines)
            {
                // Проходим по всем символам строки
                foreach (var ch in line)
                {
                    // Если символ является буквой
                    if (char.IsLetter(ch))
                    {
                        // Приводим букву к нижнему регистру
                        var lower = char.ToLower(ch);
                        // Если словарь уже содержит такую букву, увеличиваем ее значение на 1
                        if (dict.ContainsKey(lower))
                        {
                            dict[lower]++;
                        }
                        // Иначе добавляем букву в словарь со значением 1
                        else
                        {
                            dict[lower] = 1;
                        }
                    }
                }
            }
            // Сортируем словарь по ключам (буквам) в алфавитном порядке
            return dict.OrderBy(kv => kv.Key).ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        // Метод для упорядочивания массива положительных чисел по остаткам от деления и по убыванию самих чисел
        public int[] GetSortedArray(int[] array, int divisor)
        {
            return array
                .Where(x => x > 0) // фильтруем только положительные числа
                .GroupBy(x => x % divisor) // группируем по остаткам от деления
                .OrderBy(g => g.Key) // сортируем группы по возрастанию ключей
                .SelectMany(g => g.OrderByDescending(x => x)) // объединяем группы в одну последовательность, сортируя числа по убыванию
                .ToArray(); // преобразуем в массив
        }
    }
}
