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
        void RegisterComplete();
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
    }
}
