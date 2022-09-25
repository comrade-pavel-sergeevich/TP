using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект
{
    internal class Consolnoe : UserInterfaceFunctions
    {
        string cur_deistvie = "hello";
        public void Hello()
        {
            Console.WriteLine("Вы запустили...");
        }
        public object[] ChosingDB()
        {
            object? a;
            do
            {
                Console.WriteLine("Для дальнейшей работы нужно указать расположение базы данных");
                Console.Write("Для выбора удалённой БД \"1\"\nДля выбора локальной БД введите \"2\": ");
                a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                        {                
                            return new object[] { new DB() };
                        }
                    case "2":
                        {
                            return new object[] { new JSON() };
                        }
                }
            } while (true);
        }
        public object[] Login()
        {
            cur_deistvie = "login";
            string login;
            string pass;
            for (; ; )
            {
                do
                {
                    WriteAboutBack();
                    Console.Write("Введите логин: ");
                    login = Console.ReadLine();
                }
                while (login.Length < 1);
                if (login == "back") { return new object[] { "back" }; }
                do
                {
                    Console.Write("Введите пароль: ");
                    pass = Console.ReadLine();
                }
                while (pass.Length < 1);
                if (pass == "back") continue;
                break;
            }
            return new object[] { login, pass };
        }
        public object[] Register()
        {
            cur_deistvie = "register";
            string login = null;
            string mail = null;
            string pass = null;
            string pass2 = null;
            int step = 0;
            while (true)
            {
                switch (step)
                {
                    case 0:
                        {
                            do
                            {
                                WriteAboutBack();
                                Console.Write("Введите логин: ");
                                login = Console.ReadLine();
                            } while (login.Length < 1);
                            if (login == "back") { return new object[] { "back" }; }
                            goto case 1;
                        }
                    case 1:
                        {
                            do
                            {
                                Console.Write("Введите почту: ");
                                mail = Console.ReadLine();
                            } while (mail.Length < 1);
                            if (mail == "back") { goto case 0; }
                            goto case 2;
                        }
                    case 2:
                        {
                            for (; ; )
                            {
                                do
                                {
                                    Console.Write("Введите пароль: ");
                                    pass = Console.ReadLine();
                                }
                                while (pass.Length < 1);
                                if (pass == "back") { goto case 1; }
                                do
                                {
                                    Console.Write("Введите пароль ещё раз: ");
                                    pass2 = Console.ReadLine();
                                } while (pass2.Length < 1);
                                if (pass2 == "back") { goto case 2; }
                                if (pass != pass2) { Console.WriteLine("Пароли не совпадают, попробуйте ещё раз "); continue; }
                                break;
                            }
                            break;
                        }
                }
                break;
            }
            return new object[] { login, mail, pass };
        }
        public void Vhod()
        {
            cur_deistvie = "vhod";
            Console.Write("Для входа в профиль введите \"1\", для регистрации — \"2\", для выхода — \"exit\"\nПереход к ");
        }
        public string GetDeistvie()
        {
            switch (cur_deistvie)
            {
                case "vhod":
                    {
                        for (; ; )
                        {
                            switch (Console.ReadLine())
                            {

                                case "1": { return "login"; }
                                case "2": { return "register"; }
                                case "exit": { return "exit"; }
                                default: { Vhod(); break; }
                            }
                        }
                    }
                default: return "vhod";
            }
        }
        public void RegisterComplete()
        {
            Console.WriteLine("Вы успешно зарегистрировались");
        }
        public void LoginComplete()
        {
            Console.WriteLine("Вы вошли в аккаунт");
        }
        public void Exit()
        {
            Console.WriteLine("До свидания. Для выхода нажмите любую клавишу");
            Console.ReadKey();
        }
        void WriteAboutBack()
        {
            Console.WriteLine("Для отмены ввода или возрата в предыдущее меню введите\"back\"");
        }
    }
}
