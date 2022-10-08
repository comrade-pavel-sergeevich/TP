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
        List<User> users = new List<User>();
        public bool createUser(string login, string mail, string pass)
        {
            if (checkUser(login))
            {
                return false;
            }
            else
            {
                User use = new User(login, mail, pass);
                string JsonObject = JsonConvert.SerializeObject(use);
                users.Add(use);
                for (int i = 0; i < users.Count; i++)
                    File.AppendAllText("Users.json", JsonConvert.SerializeObject(users[i]));
                return true;
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
                //User use = new User
                //{
                //    login = login,
                //    mail = mail,
                //    pass = pass
                //};

                //user.UserInf.Add(use);
                //var UserJson = JsonConvert.SerializeObject(use, Formatting.Indented);
                //StreamWriter file = new StreamWriter("Users.json", true);
                //file.WriteLine(UserJson);
                //file.Close();


            }
            //    //var obj = new JsonObject()
            //    //{
            //    //    UserInf = new UserInf[]
            //    //{
            //    //    new UserInf
            //    //    {
            //    //        name = login,
            //    //        mail = mail,
            //    //        pass = pass
            //    //    }
            //    //}
            //    //};
            //    //var UserJson = JsonConvert.SerializeObject(obj, Formatting.Indented);
            //    //StreamWriter file = File.CreateText("Users.json");
            //    //file.WriteLine(UserJson);
            //    //file.Close();
            //    //return true;
            //    UserInf use = new UserInf
            //    {
            //        name = login,
            //        mail = mail,
            //        pass = pass
            //    };
            //    user.UserInf.Add(use);
            //    var UserJson = JsonConvert.SerializeObject(use, Formatting.Indented);
            //    StreamWriter file = new StreamWriter("Users.json", true);
            //    file.WriteLine(UserJson);
            //    file.Close();
            //    return true;
            //}
            ////var user = new UserInf();
            ////user.name = login;
            ////user.mail = mail;
            ////user.pass = pass;
            ////if (checkUser(login))
            ////{
            ////    return false;
            ////}
            ////else
            ////{
            ////    string UserJson = JsonSerializer.Serialize(user);
            ////    StreamWriter file = File.CreateText("Users.json");
            ////    file.WriteLine(UserJson);
            ////    file.Close();
            ////    return true;
            ////}
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
                users.Add(us);
            }
            reader.Close();
            for (int i = 0; i < users.Count - 1; i++)
                if (users[i].login == login)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            return false;
        }

        public string GetPass(string login)
        {
            for (int i = 0; i < users.Count - 1; i++)
            {
                if (users[i].login == login)
                {
                    return users[i].pass;
                }
            }
            return " ";
        }

        public User[] getAllUsers()
        {

            User[] userInf = new User[0];

            return userInf;
        }
    }
}
