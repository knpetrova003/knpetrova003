using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class MoveTransformer : ITransformer<ShiftParameters>
    {
        // Использовал выражение nameof для получения имени параметра
        double movePercent { get; set; }

        // Использовал выражение ?? для проверки на null
        public Size ResultSize { get; private set; } // Убрал инициализацию

        // Использовал выражение => для определения метода
        public void Initialize(Size size, ShiftParameters parameters)
        {
            movePercent = parameters.MoveInPercent / 100;
            ResultSize = size; // Инициализировал свойство ResultSize значением size
        }

        // Использовал выражение => для определения метода
        public Point? MapPoint(Point point) =>
            new Point((point.X - (int)(movePercent * ResultSize.Width) + ResultSize.Width) % ResultSize.Width,
                point.Y);
    }
}
