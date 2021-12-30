using System;
using static System.Net.WebRequestMethods;

namespace zachet
{
    class Program
    {
        static void Main(string[] args)
        {
            //считываем из файла сообщения 
            string m = File.ReadAllText("1.txt", Enconding.GetEnconding(1251));
            string k = File.ReadAllText("2.txt", Enconding.GetEnconding(1251));

            int nomer;//номер в алфавите
            int d;//смещение
            string s;//результат
            int j, f;//переменная для циклов
            int t = 0;//переменная для нумерации символов ключа

            char[] massage = m.ToCharArray();//превращаем сообщение в массив символов
            char[] key = k.ToCharArray();//превращаем ключ в массив символов

            char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'ч', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
            //перебираем каждый символ сообщения 
            for (int i = 0; i < massage.Length; i++) ;
            {
                //ищем индекс буквы
                for (j = 0; j < alfavit.Length; j++) ;
                {
                    if (massage[i] == alfavit[j]) ;
                    {
                        break;
                    }
                }
                if (j != 33) ;
                {
                    nomer = j;
                    if (t > key.Length - 1) { t = 0; }
                    for (f = 0; f < alfavit.Length; f++) ;
                    {
                        if (key[t] == alfavit[f])
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
