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
        //InterfaceDB bd = new InterfaceDB();

       public bool Login(string login, string pass)
       {
            //string sql = $"SELECT name FROM users WHERE login = "+login;
            /*if (bd.checkUser(login))
            {
                return true;
            }
            else*/
                return false;
            
       }

        public bool Register(string name, string login, string pass)
        {
            //string sql = "INSERT INTO users (name,login,pass) VALUES ("+name+","+login+","+pass+");";
            /*if (bd.createUser(name, login, pass))
            {
                user.name = name;
                return true;
            }
            else*/
                return false;

            


        }
    }
    



}
