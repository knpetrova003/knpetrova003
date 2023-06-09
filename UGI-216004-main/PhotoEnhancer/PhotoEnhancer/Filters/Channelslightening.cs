using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class ChannelLighteningParameters : IParameters
    {
        public double Rk { get; set; }
        public double Gk { get; set; }
        public double Bk { get; set; }

        public ParameterInfo[] GetDecription()
        {
            return new[]
            {
                new ParameterInfo()
                {
                    Name = "Rk",
                    MinValue = 0,
                    MaxValue = 10,
                    DefaultValue = 1,
                    Increment = 0.05
                },
                new ParameterInfo()
                {
                    Name = "Gk",
                    MinValue = 0,
                    MaxValue = 10,
                    DefaultValue = 1,
                    Increment = 0.05
                },
                new ParameterInfo()
                {
                    Name = "Bk",
                    MinValue = 0,
                    MaxValue = 10,
                    DefaultValue = 1,
                    Increment = 0.05
                }
            };
        }

        public void SetValues(double[] values)
        {
            Rk = values[0];
            Gk = values[1];
            Bk = values[2];
        }
    }
}
