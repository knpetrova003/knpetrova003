using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    // Класс для преобразования координат пикселей
    public class ReplaceOddRowsTransformer : ITransformer<EmptyParameters>
    {
        Size oldSize { get; set; }

        public Size ResultSize { get; private set; }

        public void Initialize(Size size, EmptyParameters parameters)
        {
            oldSize = size;
            ResultSize = size;
        }

        public Point? MapPoint(Point newPoint)
        {
            var x = newPoint.X;
            var y = newPoint.Y;

            // Если индекс строки нечетный или равен нулю, то заменяем его на следующий
            if (y % 2 != 0 || y == 0)
            {
                y++;
            }

            // Проверяем, что координаты в пределах изображения
            if (x < 0 || x >= oldSize.Width || y < 0 || y >= oldSize.Height)
                return null;

            return new Point(x, y);
        }
    }
}



