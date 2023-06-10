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
        public double MoveInPercent { get; set; }
        public ParameterInfo[] GetDecription()
        {
            return new[]
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
        }

        public void SetValues(double[] values)
        {
            MoveInPercent = values[0];
        }
    }
}
