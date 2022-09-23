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
        UserInf user = new UserInf();


        public void Login(string login, string pass)
        {
            string sql = $"SELECT name FROM users WHERE login = "+login;
            //bdchec();   отправка данных на проверку в БД
            user.password = pass;

        }

        public void Register(string name, string login, string pass)
        {
            string sql = "INSERT INTO users (name,login,pass) VALUES ("+name+","+login+","+pass+");";
            //bdcreate();     отправка данных для регистрации данных в БД 
            user.name = name;
            user.password = pass;


        }
    }
    



}
