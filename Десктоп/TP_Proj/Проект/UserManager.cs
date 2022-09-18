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


        public void Login(string login, string pass)
        {
            string sql = $"SELECT name FROM users WHERE login = "+login;
            //bdchec();   отправка данных на проверку в БД
            Properties.Settings.Default.UserLog = login;  //занесение даннных логина и пароля 
            Properties.Settings.Default.UserPass = pass;  // для сохранения их в пограмме т.е при 1 удачном заходе данные сохраняются и снова вводить данные не надо

        }

        public void Register(string name, string login, string pass)
        {
            string sql = "INSERT INTO users (name,login,pass) VALUES ("+name+","+login+","+pass+");";
            //bdcreate();     отправка данных для регистрации данных в БД 

        }
    }
    



}
