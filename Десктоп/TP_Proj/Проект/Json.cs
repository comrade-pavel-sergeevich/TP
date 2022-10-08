using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

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
            if (!checkUser(login))
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
                    return true;
                    break;
                    reader.Close();
                }
            }
            reader.Close();
            return false;
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
                    reader.Close ();
                }
            }
            reader.Close();
            return "";
        }

        public User[] getAllUsers()
        {
            JsonTextReader reader = new JsonTextReader(new StreamReader("Users.json"));
            reader.SupportMultipleContent = true;
            int count = 0;
            List<User> userss = new List<User>();
            while (true)
            {
                if (!reader.Read())
                {
                    break;
                }
                JsonSerializer serializer = new JsonSerializer();
                User us = serializer.Deserialize<User>(reader);
                userss.Add(us);
                count++;
            }
            User[] users = new User[count];
            for (int i = 0; i < count; i++)
            {
                users[i] = new User();
                users[i].login = userss[i].login;
                users[i].mail = userss[i].mail;
                users[i].pass = userss[i].pass;
            }
            return users;
        }
    }
}
