using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект
{
    internal interface InterfaceDB
    {
        bool createUser(string login, string mail, string pass);

        bool deleteUser(string login); // удаляем всю строку с пользователем

        bool checkUser(string login);

        UserInf[] getAllUsers();         

        string GetPass(string login);  // ищем пользователя с заданным логином. Если нашли - вернули пароль

    }
}
