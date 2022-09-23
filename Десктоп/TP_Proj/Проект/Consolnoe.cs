using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект
{
    internal class Consolnoe : UserInterfaceFunctions
    {
        public void Hello()
        {
            Console.WriteLine("Вы запустили...");
        }
        public object[] Login()
        {
            string login;
            do
            {
                Console.Write("Введите логин: ");
                login = Console.ReadLine();
            }
            while (login.Length < 1);
            string pass;
            do
            {
                Console.Write("Введите пароль: ");
                pass = Console.ReadLine();
            }
            while (pass.Length < 1);
            return new object[] { login, pass };
        }
        public object[] Register()
        {
            string login;
            do
            {
                Console.Write("Введите логин: ");
                login = Console.ReadLine();
            } while (login.Length < 1);
            string mail;
            do
            {
                Console.Write("Введите почту: ");
                mail = Console.ReadLine();
            } while (mail.Length < 1);

            string pass;
            string pass2;
            for (; ; )
            {
                do
                {
                    Console.Write("Введите пароль: ");
                    pass = Console.ReadLine();
                }
                while (pass.Length < 1);


                do
                {
                    Console.Write("Введите пароль ещё раз: ");
                    pass2 = Console.ReadLine();
                } while (pass2.Length < 1);
                if (pass != pass2) { Console.WriteLine("Пароли не совпадают, попробуйте ещё раз "); continue; }
                break;
            }

            return new object[] { login, mail, pass };
        }
        public string GetDeistvie()
        {
            //для первого экрана:
            Console.Write("Для входа в профиль введите \"1\", для регистрации — \"2\"\nПереход к ");
            switch (Console.ReadLine())
            {
                case "1": { return "login"; }
                case "2": { return "register"; }
                default: { return null; }
            }
            //при появлении других нужно будет переписать по-другому, это вам не формы
        }
        public void RegisterComplete()
        {
            Console.WriteLine("Вы успешно зарегистрировались");
        }
    }
}
