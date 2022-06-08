using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    class Program
    {
        static void Main(string[] args)
        {
            var george = new User();
            george.Login = "George032";

            var kate = new User("Kate");

            var john = new RegisteredUser("John", "qwerty", "john@yandex.ru");

            var paul = new VipUser("Paul123", "456789", "paul@gmail.com", 2400569743981555);

            var admin = new Admin("Sergei", "admin2022", "sergei@mail.ru", 2);

            var users = new[] { george, kate, john, paul, admin};

            object obj = new object();

            var RegUser = paul as RegisteredUser;

            VipUser vip = kate as VipUser;

            foreach (var user in users)
                user.PrintInfo();

            Console.ReadKey();
        }
    }
}