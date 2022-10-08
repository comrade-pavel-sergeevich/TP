using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Проект
{
    internal class JSON : InterfaceDB
    {
        public JSON()
        {
            if (!File.Exists("Users.json"))
                File.Create("Users.json");
        }
        public bool createUser(string login, string mail, string pass)
        {
            if (checkUser(login))
            {
                return false;
            }
            else
            {
                User use = new User(login, mail, pass);
                File.AppendAllText("Users.json", JsonConvert.SerializeObject(use));
                return true;
            }
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
            bool ch_us = false;
            JsonTextReader reader = new JsonTextReader(new StreamReader("Users.json"));
            reader.SupportMultipleContent = true;

            while (true)
            {
                if (!reader.Read())
                {
                    break;
                }
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                User us = serializer.Deserialize<User>(reader);
                if (us.login == login)
                {
                    ch_us = true;
                    break;
                }
            }
            reader.Close();
            if(ch_us)
            {
                return true;
            }
            else { return false; }
        }

        public string GetPass(string login)
        {
            JsonTextReader reader = new JsonTextReader(new StreamReader("Users.json"));
            reader.SupportMultipleContent = true;
            while (true)
            {
                if (!reader.Read())
                {
                    break;
                }
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                User us = serializer.Deserialize<User>(reader);
                if (us.login == login)
                {
                    return us.pass;
                    break;
                }
            }
            reader.Close();
            //for (int i = 0; i < users.Count - 1; i++)
            //{
            //    if (users[i].login == login)
            //    {
            //        return users[i].pass;
            //    }
            //}
            return " ";
        }

        public User[] getAllUsers()
        {
            // Доделать!!!
            User[] userInf = new User[0];

            return userInf;
        }
    }
}
