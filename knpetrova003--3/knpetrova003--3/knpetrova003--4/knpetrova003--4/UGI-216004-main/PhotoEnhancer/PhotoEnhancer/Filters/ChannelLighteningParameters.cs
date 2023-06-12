using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    internal class ChannelsParameters
    {
        public class ChannelLighteningParameters : IParameters
        {
            public double Rk { get; set; } // Параметр для канала R
            public double Gk { get; set; } // Параметр для канала G
            public double Bk { get; set; } // Параметр для канала B

            public ParameterInfo[] GetDecription()
            {
                return new[]
                {
                new ParameterInfo()
                {
                    Name = "Коэффициент R",
                    MinValue = 0,
                    MaxValue = 10,
                    DefaultValue = 1,
                    Increment = 0.05
                },
                new ParameterInfo()
                {
                    Name = "Коэффициент G",
                    MinValue = 0,
                    MaxValue = 10,
                    DefaultValue = 1,
                    Increment = 0.05
                },
                new ParameterInfo()
                {
                    Name = "Коэффициент B",
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

}
