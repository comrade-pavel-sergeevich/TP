using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

    
namespace Проект
{
    internal class UserManager
    {
        UserInf user = new UserInf();
        string error = "";
       
        InterfaceDB bd;
        public UserManager(InterfaceDB bd)
        {
            this.bd = bd;

        }

        public object[] Login(string login, string pass)
       {
            if (bd.checkUser(login))
            {
                Object[] result = { (Object)true, (Object)error};
                return result;
            }
            else
            {
                Object[] result = { (Object)false, (Object)error };
                return result;
            }
            
            
       }

        public object[] Register(string name, string login, string pass)
        {
            if (bd.createUser(name, login, pass))
            {
                user.name = name;
                Object[] result = { (Object)true, (Object)error};
                return result;
            }
            else
            {
                Object[] result = { (Object)false, (Object)error };
                return result;
            }





        }
    }
    



}
