using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class ShiftParameters : IParameters
    {
        // Использовал автоматически реализуемое свойство с лямбда-выражением
        public double MoveInPercent { get; set; } // Убрал обращение к values

        // Использовал инициализатор коллекции для создания массива
        public ParameterInfo[] GetDecription() => new[]
        {
            new ParameterInfo()
            {
                MinValue = 0,
                MaxValue = 100,

                DefaultValue = 0,
                Increment = 5,

                Name = "Сдвиг вправо в процентах",
            }
        };

        // Использовал выражение throw для генерации исключения
        public void SetValues(double[] values) // Добавил параметр values
        {
            if (values.Length != 1)
                throw new ArgumentException("Неверное количество параметров");

            MoveInPercent = values[0]; // Использовал параметр values
        }
    }
}
