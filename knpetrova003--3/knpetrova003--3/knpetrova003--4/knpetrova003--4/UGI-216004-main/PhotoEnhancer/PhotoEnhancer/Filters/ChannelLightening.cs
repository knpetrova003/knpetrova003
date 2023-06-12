using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    internal class Channels
    {
        // Функция, которая принимает изображение в формате Bitmap и три параметра для каналов R, G и B
        public static Bitmap ChannelLightening(Bitmap image, double Rk, double Gk, double Bk)
        {
            // Создаем новое изображение того же размера и формата
            Bitmap result = new Bitmap(image.Width, image.Height, image.PixelFormat);

            // Проходим по всем пикселям изображения
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    // Получаем цвет текущего пикселя
                    Color pixel = image.GetPixel(x, y);

                    // Вычисляем новые значения для каналов R, G и B по формуле X new=k*X old
                    double Rnew = Rk * pixel.R;
                    double Gnew = Gk * pixel.G;
                    double Bnew = Bk * pixel.B;

                    // Обрезаем значения до диапазона от 0 до 255
                    Rnew = Math.Max(0, Math.Min(255, Rnew));
                    Gnew = Math.Max(0, Math.Min(255, Gnew));
                    Bnew = Math.Max(0, Math.Min(255, Bnew));

                    // Создаем новый цвет из полученных значений
                    Color newPixel = Color.FromArgb((int)Rnew, (int)Gnew, (int)Bnew);

                    // Устанавливаем новый цвет для пикселя в результирующем изображении
                    result.SetPixel(x, y, newPixel);
                }
            }

            // Возвращаем результирующее изображение
            return result;
        }

    }
}
