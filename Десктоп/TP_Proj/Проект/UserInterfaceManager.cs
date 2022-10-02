using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект
{
    internal class UserInterfaceManager
    {
        UserInterfaceFunctions pr;
        UserManager um;
        public UserInterfaceManager(UserInterfaceFunctions pr)
        {
            this.pr = pr;
            um = new UserManager(ChosingDB());
            Start();
        }
        void Start()
        {
            pr.Hello();
            string deistvie = "vhod";
            string cur_deistvie = "vhod";
            object[] data;
            while (deistvie != "exit")
            {
                switch (deistvie)
                {
                    case "login":
                        {
                            cur_deistvie = "login";
                            data = pr.Login();
                            if (data[0] is string)
                            {
                                if ((string)data[0] == "exit")
                                {
                                    deistvie = "exit"; break;
                                }
                                if ((string)data[0] == "back")
                                {
                                    deistvie = pr.Back(cur_deistvie); break;
                                }
                            }
                            //Console.WriteLine("Отправлено для входа");
                            var response = um.Login((string)data[0], (string)data[1]);
                            if ((bool)response[0])
                            {
                                pr.LoginComplete();
                                deistvie = pr.GetDeistvie();
                                break;
                            }
                            pr.LoginError((string)response[1]);
                            //проверяем через БД, вызываем WrongPass или LoginComplete
                            
                            break;
                        }
                    case "register":
                        {
                            cur_deistvie = "register";
                            data = pr.Register();
                            if (data[0] is string)
                            {
                                if ((string)data[0] == "exit")
                                {
                                    deistvie = "exit"; break;
                                }
                                if ((string)data[0] == "back")
                                {
                                    deistvie = pr.Back(cur_deistvie); break;
                                }
                            }
                            var response = um.Register((string)data[0], (string)data[1], (string)data[2]);
                            if ((bool)response[0])
                            {
                                pr.RegisterComplete();
                                deistvie = "login";
                                break;
                            }
                            pr.RegisterError((string)response[1]);
                            break;
                        }
                    case "back":
                        {
                            deistvie = pr.Back(cur_deistvie);
                            cur_deistvie = deistvie;
                            break;
                        }
                    case "vhod":
                        {
                            pr.Vhod();
                            deistvie = pr.GetDeistvie();
                            break;
                        }
                    default:
                        {
                            deistvie = pr.GetDeistvie();
                            cur_deistvie = deistvie;
                            break;
                        }
                }
            }
            pr.Exit();
        }
        InterfaceDB ChosingDB()
        {
            object[] data = pr.ChosingDB();
            if (data[0] is string && (string)data[0] == "exit")
            {
                Environment.Exit(0);
            }
            return (InterfaceDB)data[0];
        }
        //public static implicit operator UserInterfaceManager(Program v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
