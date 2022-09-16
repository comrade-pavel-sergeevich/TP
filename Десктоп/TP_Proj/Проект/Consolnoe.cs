using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект
{
    internal class Consolnoe:UserInterfaceFunctions
    {
        public void Hello()
        {
            Console.WriteLine("Вы запустили...");
        }
        public object[] Login ()
        {
            Console.Write("Введите логин: ");
            string login = Console.ReadLine();
            Console.Write("Введите пароль: ");
            string pass = Console.ReadLine();
            return new object[] { login,pass};
        }
        public object[] Register()
        {
            Console.Write("Введите логин: ");
            string login = Console.ReadLine();
            Console.Write("Введите почту: ");
            string mail = Console.ReadLine();
            Console.Write("Введите пароль: ");
            string pass = Console.ReadLine();
            Console.Write("Введите пароль ещё раз: ");
            string pass2 = Console.ReadLine();
            return new object[] { login,mail,pass };
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
