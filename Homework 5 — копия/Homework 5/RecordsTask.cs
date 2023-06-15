using System;
using System.Collections.Generic;
using System.Linq;

public class RecordsTask
{
    // Метод для вывода информации о годах и месяцах с суммарной длительностью занятий более 10% от года
    public void PrintNumberOfMonthsPerYear(List<Record> db)
    {
        db
            .GroupBy(r => r.Year) // группируем записи по годам
            .Select(g => new // преобразуем каждую группу в объект
            {
                Year = g.Key, // год
                Months = g.GroupBy(r => r.Month) // подгруппируем записи по месяцам
                    .Count(mg => mg.Sum(r => r.Duration) > 0.1 * g.Sum(r => r.Duration)) // подсчитаем количество месяцев с суммарной длительностью более 10% от суммарной длительности за год
            })
            .Where(x => x.Months > 0) // фильтруем года, в которых есть такие месяцы
            .OrderByDescending(x => x.Months) // сортируем по убыванию количества месяцев
            .ThenBy(x => x.Year) // затем по возрастанию номера года
            .ToList() // преобразуем в список
            .ForEach(x => Console.WriteLine($"{x.Year} {x.Months}")); // выводим на консоль
    }
}