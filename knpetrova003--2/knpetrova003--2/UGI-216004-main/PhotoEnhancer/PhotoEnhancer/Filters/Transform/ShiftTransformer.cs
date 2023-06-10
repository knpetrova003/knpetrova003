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
        double movePercent { get; set; }

        public Size ResultSize { get; private set; }

        public void Initialize(Size size, ShiftParameters parameters)
        {
            movePercent = parameters.MoveInPercent / 100;
            ResultSize = size;
        }

        public Point? MapPoint(Point point)
        {
            return new Point((point.X - (int)(movePercent * ResultSize.Width) + ResultSize.Width) % ResultSize.Width,
                point.Y);
        }
    }
}