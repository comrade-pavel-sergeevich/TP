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
        public UserInterfaceManager(UserInterfaceFunctions pr)
        {
            this.pr = pr;
            Start();
        }
        void Start()
        {
            pr.Hello();
            string deistvie = pr.GetDeistvie();
            object[] data;
            while (deistvie != "exit")
            {
                switch (deistvie)
                {
                    case "login":
                        {
                            data=pr.Login();
                            //проверяем через БД, вызываем WrongPass или LoginComplete
                            deistvie = pr.GetDeistvie();
                            break;
                        }
                    case "register":
                        {
                            data = pr.Register();
                            //отправляем данные в БД
                            pr.RegisterComplete();
                            deistvie = "login";
                            break;
                        }
                    default:
                        {
                            deistvie=pr.GetDeistvie();
                            break;
                        }
                }
            }
            

        }
        public static implicit operator UserInterfaceManager(Program v)
        {
            throw new NotImplementedException();
        }
    }
}
