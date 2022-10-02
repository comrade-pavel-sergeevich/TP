using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Проект
{
    internal class UserManager
    {
        User user = new User();
        InterfaceDB bd;
        public UserManager(InterfaceDB bd)
        {
            this.bd = bd;
        }
        public object[] Login(string login, string pass)
        {
            string hashpass = bd.GetPass(login);
            object[] result = new object[] { false, null };
            if (hashpass != "")
            {
                if (BCrypt.Net.BCrypt.Verify(pass, hashpass))
                {
                    result[0] = true;
                    //result[1] = error;
                    return result;
                }
                //error = "Неверный пароль";
                result[1] = "Неверный пароль";
                return result;
            }
            //error = "Пользователь не найден";
            result[1] = "Пользователь не найден";
            return result;
        }
        public object[] Register(string login, string email, string pass)
        {
            string hashpass = BCrypt.Net.BCrypt.HashPassword(pass);
            object[] result = new object[] { false, null };
            if (bd.createUser(login, email, hashpass))
            {
                user.login = login;
                result[0] = true;
                return result;

            }
            //error = "Пользователь не создан";
            result[1] = "Пользователь не создан";
            return result;
        }
    }
}
