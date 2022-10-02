using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Проект
{
    internal class DB: InterfaceDB
    {
        static string connStr = "Server=127.0.0.1; UserId=admin; Password=1234; Database=TP; Port=3306;";   //подключение
        static MySqlConnection conn = new MySqlConnection(connStr);

        public bool createUser(string login, string mail, string pass)
        {
            string add_sql = $"INSERT INTO users (name, mail, password ) VALUES ('{login}', '{mail}', '{pass}')"; //добавление

            if (checkUser(login))   // если такой уже есть - выходим 
            {
                return false;
            }
            else
            {
                conn.Open();
                MySqlCommand command_add = new MySqlCommand(add_sql, conn);
                command_add.ExecuteScalar();
                conn.Close();

                return true;
            }
        }

        public bool deleteUser(string login)
        {
            string sql_delete = $"DELETE FROM users WHERE name = \"{login}\"";

            if (checkUser(login))  //если есть - удаляем
            {
                conn.Open();
                MySqlCommand command_delete = new MySqlCommand(sql_delete, conn);
                conn.Close();

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkUser(string login)
        {
            string sql_check = $"SELECT name FROM users WHERE name = \"{login}\"";  // проверка на то, что юзер существует

            conn.Open();
            MySqlCommand command = new MySqlCommand(sql_check, conn);
            var check = command.ExecuteScalar();

            if (check != null) //если такой уже есть - true
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }
        }

        public string GetPass(string login)
        {
            string sql_pass = $"SELECT password FROM users WHERE name = \"{login}\"";

            if (checkUser(login))
            {
                conn.Open();

                MySqlCommand command = new MySqlCommand(sql_pass, conn);
                var result = command.ExecuteScalar();

                conn.Close();

                return Convert.ToString(result);
            }
            return "";
        }

        public User[] getAllUsers()
        {
            User[] userData = new User[3];

            string sql_data = $"SELECT name FROM users";
            string sql_count = $"SELECT COUNT(*) FROM users";

            conn.Open();

            MySqlCommand command = new MySqlCommand(sql_data, conn);
            MySqlCommand command_count = new MySqlCommand(sql_count, conn);

            MySqlDataReader reader = command.ExecuteReader();         // получаем несколько строк
            var count = command_count.ExecuteScalar();   // количество человек

            conn.Close();

            for(int i=0; i<Convert.ToInt32(count); i++)
            {
                userData[i].login = reader.GetName(0);
                userData[i].mail = reader.GetName(1);
                userData[i].pass = reader.GetName(2);
            }
            

            return userData;
        }


    }
}
