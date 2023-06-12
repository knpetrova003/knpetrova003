using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class ReplaceOddRowsFilter : ParametrizedFilter<EmptyParameters>
    {
        ReplaceOddRowsTransformer transformer;

        public ReplaceOddRowsFilter(string name,
            ReplaceOddRowsTransformer transformer)
        {
            this.name = name;
            this.transformer = transformer;
        }

        public override Photo Process(Photo original, EmptyParameters parameters)
        {
            var oldSize = new Size(original.Width, original.Height);
            transformer.Initialize(oldSize, parameters);

            var result = new Photo(transformer.ResultSize.Width, transformer.ResultSize.Height);

            for (var x = 0; x < result.Width; x++)
                for (var y = 0; y < result.Height; y++)
                {
                    var oldPoint = transformer.MapPoint(new Point(x, y));
                    if (oldPoint.HasValue)
                        result[x, y] = original[oldPoint.Value.X, oldPoint.Value.Y];
                }

            return result;
        }
    }
}
