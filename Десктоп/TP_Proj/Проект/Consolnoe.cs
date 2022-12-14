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
            Console.WriteLine("\nПрограмма успешно запущена");
        }
        public object[] ChosingDB()
        {
            object? a;
            do
            {
                Console.WriteLine("\nДля дальнейшей работы нужно указать расположение базы данных");
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
            Console.WriteLine("\nВход в аккаунт:");
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
                if (login == "exit") { return new object[] { "exit" }; }
                do
                {
                    Console.Write("Введите пароль: ");
                    pass = Console.ReadLine();
                }
                while (pass.Length < 1);
                if (pass == "back") continue;
                if (pass == "exit") { return new object[] { "exit" }; }
                break;
            }
            return new object[] { login, pass };
        }
        public object[] Register()
        {
            Console.WriteLine("\nРегистрация нового пользователя:");
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
                            if(login == "exit") { return new object[] { "exit" }; }
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
                            if (mail == "exit") { return new object[] { "exit" }; }
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
                                if (pass == "exit") { return new object[] { "exit" }; }
                                do
                                {
                                    Console.Write("Введите пароль ещё раз: ");
                                    pass2 = Console.ReadLine();
                                } while (pass2.Length < 1);
                                if (pass2 == "back") { goto case 2; }
                                if (pass2 == "exit") { return new object[] { "exit" }; }
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
            Console.Write("\nДля входа в профиль введите \"1\", для регистрации — \"2\", для выхода — \"exit\"\nПереход к ");
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
            Console.WriteLine("Вы успешно зарегистрировались\n");
        }
        public void RegisterError(string error)
        {
            Console.WriteLine("Ошибка регистрации:\n"+error+"\n");
        }
        public void LoginError(string error)
        {
            Console.WriteLine("\nОшибка авторизации:\n" + error+"\n");
        }
        public void LoginComplete()
        {
            Console.WriteLine("\nВы вошли в аккаунт\n");
        }
        public void Exit()
        {
            Console.WriteLine("\nДо свидания. Для выхода нажмите любую клавишу");
            Console.ReadKey();
        }
        void WriteAboutBack()
        {
            Console.WriteLine("Для отмены ввода или возрата в предыдущее меню введите \"back\"");
        }
    }
}
