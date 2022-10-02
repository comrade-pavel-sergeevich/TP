using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

namespace Проект
{
    internal class JSON : InterfaceDB
    {
        JsonObject user = new JsonObject();
        public bool createUser(string login, string mail, string pass)
        {
            if (checkUser(login))
            {
                return false;
            }
            else
            {
                //var obj = new JsonObject()
                //{
                //    UserInf = new UserInf[]
                //{
                //    new UserInf
                //    {
                //        name = login,
                //        mail = mail,
                //        pass = pass
                //    }
                //}
                //};
                //var UserJson = JsonConvert.SerializeObject(obj, Formatting.Indented);
                //StreamWriter file = File.CreateText("Users.json");
                //file.WriteLine(UserJson);
                //file.Close();
                //return true;
                User use = new User
                {
                    login = login,
                    mail = mail,
                    pass = pass
                };
                
                user.UserInf.Add(use);
                var UserJson = JsonConvert.SerializeObject(use, Formatting.Indented);
                StreamWriter file = new StreamWriter("Users.json", true);
                file.WriteLine(UserJson);
                file.Close();
                return true;
            }
            //var user = new UserInf();
            //user.name = login;
            //user.mail = mail;
            //user.pass = pass;
            //if (checkUser(login))
            //{
            //    return false;
            //}
            //else
            //{
            //    string UserJson = JsonSerializer.Serialize(user);
            //    StreamWriter file = File.CreateText("Users.json");
            //    file.WriteLine(UserJson);
            //    file.Close();
            //    return true;
            //}
        }
        public bool deleteUser(string login)
        {
            if (checkUser(login) == false)
            {
                return false;
            }
            else
            {

                return true;
            }
        }

        public bool checkUser(string login)
        {
            string json = File.ReadAllText("Users.json");
            return true;
        }

        public string GetPass(string login)
        {
            return "Да";
        }

        public User[] getAllUsers()
        {
            User[] userInf = new User[0];

            return userInf;
        }
    }
}
