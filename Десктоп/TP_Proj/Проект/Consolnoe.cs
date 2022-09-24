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
            string mail;
            string pass;
            string pass2;
            do
            {
                Console.Write("Введите логин: ");
                login = Console.ReadLine();
            } while (login.Length < 1);
            
            do
            {
                Console.Write("Введите почту: ");
                mail = Console.ReadLine();
            } while (mail.Length < 1);

            
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
        public void Exit()
        {
            Console.WriteLine("До свидания. Для выхода нажмите любую клавишу");
            Console.ReadKey();
        }
    }
}
