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
    }
}
