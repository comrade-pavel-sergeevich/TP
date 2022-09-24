﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект
{
    internal class UserInterfaceManager
    {
        UserInterfaceFunctions pr;
        UserManager um = new UserManager();
        public UserInterfaceManager(UserInterfaceFunctions pr)
        {
            this.pr = pr;
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
                            data =pr.Login();
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
                            Console.WriteLine("Отправлено для входа");
                            um.Login((string)data[0], (string) data[1]);
     
                            //проверяем через БД, вызываем WrongPass или LoginComplete
                            deistvie = pr.GetDeistvie();
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
                            if (um.Register((string)data[0], (string)data[1], (string)data[2])) {
                                pr.RegisterComplete();
                                deistvie = "login";
                            }
                            //отправляем данные в БД
                            
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
                            deistvie=pr.GetDeistvie();
                            cur_deistvie = deistvie;
                            break;
                        }
                }
            }
            pr.Exit();
        }      
        //public static implicit operator UserInterfaceManager(Program v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
