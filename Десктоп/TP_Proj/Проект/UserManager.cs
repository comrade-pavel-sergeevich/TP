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
        string error = "";
       
        InterfaceDB bd;
        public UserManager(InterfaceDB bd)
        {
            this.bd = bd;

        }

        public object[] Login(string login, string pass)
       {
            
            string hashpass = bd.GetPass(login);
            object[] result = new object[2];
            if (hashpass != "")
            {
                //bool IsValidPass = BCrypt.Net.BCrypt.Verify(pass, hashpass);
                if (BCrypt.Net.BCrypt.Verify(pass, hashpass))
                {
                    result[0] = true;
                    result[1] = error;
                }
                else
                {
                    error = "Неверный пароль";
                    result[0] = false;
                    result[1] = error;
                }

            }
            else
            {
                error = "Пользователь не найден";
                result[0] = false;
                result[1] = error;
            }
            return result;

        }

        public object[] Register(string login, string email, string pass)
        {
            string hashpass = BCrypt.Net.BCrypt.HashPassword(pass);
            object[] result = new object[2];
            if (bd.createUser(login, email, hashpass))
            {
                user.login = login;
                result[0] = true;
                result[1] = error;

            }
            else
            {
                error = "Пользователь не создан";
                result[0] = false;
                result[1] = error;

            }
            return result;
        }

    }
    



}
