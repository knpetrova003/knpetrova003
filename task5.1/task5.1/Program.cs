using System;

namespace task5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Слово перевозка,  веревка и повозка
            string str = "";

            str = "перевозка";//п-0 е-1 р-2 е-3 в-4 о-5 з-6 к-7 а-8
            Console.WriteLine(str);

            string result = str.Substring(4, 1)
                + str.Substring(1, 4)
                + str.Substring(7, 2);


            Console.WriteLine(result);
            string resalt = str.Substring(0,1)
                +str.Substring(5, 1)
                +str.Substring(4);

            Console.WriteLine(resalt);
            Console.ReadKey();



        }
    }
}

