using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект
{
    internal interface UserInterfaceFunctions
    {
        public void Hello();
        object[] Login();
        object[] Register();
        string GetDeistvie();
        void RegisterError(string error);
        void LoginError(string error);
        void RegisterComplete();
        void LoginComplete();
        void Vhod();
        string Back(string deistvie)
        {
            switch (deistvie)
            {
                case "login": return "vhod";
                case "register": return "vhod";
                default: return ""; 
            }
        }
        void Exit();
        object[] ChosingDB();
    }
}
