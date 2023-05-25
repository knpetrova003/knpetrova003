using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ShiftRight
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Получаем изображение из элемента Image
            BitmapSource bitmap = image.Source as BitmapSource;

            // Проверяем, что изображение существует
            if (bitmap == null)
            {
                MessageBox.Show("Нет изображения");
                return;
            }

            // Получаем параметр N из элемента Slider
            int N = (int)slider.Value;

            // Вычисляем число пикселей для сдвига вправо
            int shift = (int)(bitmap.PixelWidth * N / 100.0);

            // Создаем новое изображение с тем же размером и форматом
            WriteableBitmap newBitmap = new WriteableBitmap(BitmapSource.Create(bitmap.PixelWidth, bitmap.PixelHeight, bitmap.DpiX, bitmap.DpiY, PixelFormats.Bgr32, bitmap.Palette, null, 0));
            // Копируем пиксели из старого изображения в новое с учетом сдвига
            for (int y = 0; y < bitmap.PixelHeight; y++)
            {
                for (int x = 0; x < bitmap.PixelWidth; x++)
                {
                    // Вычисляем новую координату x с учетом сдвига и цикличности
                    int newX = (x + shift) % bitmap.PixelWidth;

                    // Получаем цвет пикселя из старого изображения по координатам (x, y)
                    Color color = GetPixelColor(bitmap, x, y);

                    // Устанавливаем цвет пикселя в новом изображении по координатам (newX, y)
                    SetPixelColor(newBitmap, newX, y, color);
                }
            }

            // Устанавливаем новое изображение в элемент Image
            image.Source = newBitmap;
        }

        // Метод для получения цвета пикселя из изображения по координатам
        private Color GetPixelColor(BitmapSource bitmap, int x, int y)
        {
            // Создаем массив для хранения байтов пикселя
            int bytesPerPixel = bitmap.Format.BitsPerPixel / 8;
            byte[] pixelData = new byte[bytesPerPixel];

            // Копируем байты пикселя из изображения в массив
            int stride = bitmap.PixelWidth * bytesPerPixel;
            bitmap.CopyPixels(new Int32Rect(x, y, 1, 1), pixelData, stride, 0);

            // Возвращаем цвет пикселя в зависимости от формата изображения
            switch (bitmap.Format)
            {
                case PixelFormats.Bgra32:
                    return Color.FromArgb(pixelData[3], pixelData[2], pixelData[1], pixelData[0]);
                case PixelFormats.Bgr32:
                    return Color.FromRgb(pixelData[2], pixelData[1], pixelData[0]);
                case PixelFormats.Bgr24:
                    return Color.FromRgb(pixelData[2], pixelData[1], pixelData[0]);
                case PixelFormats.Bgr565:
                    ushort value = BitConverter.ToUInt16(pixelData, 0);
                    byte r = (byte)((value & 0xF800) >> 8);
                    byte g = (byte)((value & 0x07E0) >> 3);
                    byte b = (byte)((value & 0x001F) << 3);
                    return Color.FromRgb(r, g, b);
                default:
                    throw new NotSupportedException("Unsupported pixel format");
            }
        }

        // Метод для установки цвета пикселя в изображении по координатам
        private void SetPixelColor(WriteableBitmap bitmap, int x, int y, Color color)
        {
            // Создаем массив для хранения байтов пикселя
            int bytesPerPixel = bitmap.Format.BitsPerPixel / 8;

            byte[] pixelData = new byte[bytesPerPixel];

// Записываем байты пикселя в массив в зависимости от формата изображения
switch (bitmap.Format)
{
    case PixelFormats.Bgra32:
        pixelData[0] = color.B;
        pixelData[1] = color.G;
        pixelData[2] = color.R;
        pixelData[3] = color.A;
        break;
    case PixelFormats.Bgr32:
        pixelData[0] = color.B;
        pixelData[1] = color.G;
        pixelData[2] = color.R;
        break;
    case PixelFormats.Bgr24:
        pixelData[0] = color.B;
        pixelData[1] = color.G;
        pixelData[2] = color.R;
        break;
    case PixelFormats.Bgr565:
        ushort value = (ushort)(((color.R & 0xF8) << 8) | ((color.G & 0xFC) << 3) | ((color.B & 0xF8) >> 3));
        pixelData[0] = (byte)(value & 0xFF);
        pixelData[1] = (byte)(value >> 8);
        break;
    default:
        throw new NotSupportedException("Unsupported pixel format");
}

// Записываем байты пикселя в изображение
int stride = bitmap.PixelWidth * bytesPerPixel;
bitmap.WritePixels(new Int32Rect(x, y, 1, 1), pixelData, stride, 0);
        }
    }
}