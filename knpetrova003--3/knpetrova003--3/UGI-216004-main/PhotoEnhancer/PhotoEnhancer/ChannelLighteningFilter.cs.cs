using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoEnhancer;


namespace PhotoEnhancer
{
    public class ChannelLighteningFilter : IFilter<ChannelLighteningParameters>


    {
        private ChannelLighteningParameters parameters;

        // Имя фильтра
        public string Name { get; private set; }

        // Объект для хранения параметров фильтра
        public ChannelLighteningParameters Parameters { get; private set; }

        // Конструктор класса
        public ChannelLighteningFilter()
        {
            Name = "Раздельное осветление/затемнение каналов";
            Parameters = new ChannelLighteningParameters();
        }

        // Метод для применения фильтра к изображению
        public Bitmap Process(Bitmap image)
        {
            // Вызываем метод ChannelLightening из класса Channels
            return Channels.ChannelLightening(image, Parameters.Rk, Parameters.Gk, Parameters.Bk);
        }

        // Метод для получения описания параметров фильтра
        public ParameterInfo[] GetParametersInfo()
        {
            // Создаем массив для хранения описания параметров
            ParameterInfo[] info = new ParameterInfo[3];

            // Заполняем массив данными из объекта Parameters
            info[0] = new ParameterInfo()
            {
                Name = "Коэффициент красного канала",
                MinValue = 0,
                MaxValue = 10,
                DefaultValue = 1,
                Increment = 0.05,
                Value = Parameters.Rk
            };

            info[1] = new ParameterInfo()
            {
                Name = "Коэффициент зеленого канала",
                MinValue = 0,
                MaxValue = 10,
                DefaultValue = 1,
                Increment = 0.05,
                Value = Parameters.Gk
            };

            info[2] = new ParameterInfo()
            {
                Name = "Коэффициент синего канала",
                MinValue = 0,
                MaxValue = 10,
                DefaultValue = 1,
                Increment = 0.05,
                Value = Parameters.Bk
            };

            // Возвращаем массив описания параметров
            return info;
        }

        // Метод для установки значений параметров фильтра
        public void SetParameters(double[] values)
        {
            // Устанавливаем значения параметров из массива values
            Parameters.Rk = values[0];
            Parameters.Gk = values[1];
            Parameters.Bk = values[2];
        }

    }
}
