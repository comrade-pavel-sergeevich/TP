using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace Проект
{
    internal class Connect
    {
        static string connStr = "Server=127.0.0.1; UserId=admin; Password=1234; Database=TP; Port=3306;";
        static MySqlConnection conn = new MySqlConnection(connStr);
        public bool Regist(string name, string mail, string password, string password2)
        {
            conn.Open();
            string sql = $"SELECT name FROM users WHERE name = \"{name}\"";
            string add_sql = $"INSERT INTO users (name, mail, password ) VALUES ('{name}', '{mail}', '{password}')";

            MySqlCommand command = new MySqlCommand(sql, conn); //делаем запрос
            MySqlCommand command_add = new MySqlCommand(add_sql, conn);

            var check = command.ExecuteScalar(); //получили ник из запроса 
            //string res_name;

            if (check != null)
                return false;
            else
            {
                command_add.ExecuteNonQuery();

                conn.Close();

                return true;
            }
   


        }
        public bool Autoriz(string name, string password)
        {
            conn.Open();

            string sql = $"SELECT name FROM users WHERE name =  \"{name}\" AND password= \"{password}\"";

            MySqlCommand command = new MySqlCommand(sql, conn); //делаем запрос

            var check = command.ExecuteScalar(); //получили строку

            conn.Close();

            if (check == null)
                return false;
            else
            {
                return true;
            }

        }
    }
}
