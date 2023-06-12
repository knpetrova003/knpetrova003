using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    // создаем новый класс для фильтра
    public class InterlaceFilter : ParametrizedFilter<EmptyParameters>
    {
        // конструктор класса
        public InterlaceFilter(string name)
        {
            this.name = name;
        }

        // переопределяем метод Process
        public override Photo Process(Photo original, EmptyParameters parameters)
        {
            // создаем новое изображение того же размера и типа, что и оригинал
            var result = new Photo(original.Width, original.Height);

            // проходим по всем пикселям изображения
            for (int x = 0; x < result.Width; x++)
            {
                for (int y = 0; y < result.Height; y++)
                {
                    // если строка четная, копируем пиксель из оригинала
                    if (y % 2 == 0)
                    {
                        result[x, y] = original[x, y];
                    }
                    // если строка нечетная, делаем пиксель черным
                    else
                    {
                        result[x, y] = new Pixel(0, 0, 0);
                    }
                }
            }

            // возвращаем результат
            return result;
        }
    }

}
