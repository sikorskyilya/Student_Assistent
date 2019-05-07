using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;
using Dapper;
namespace Student_Assistent
{
    class DBAccess
    {
        private const string DB_CONNECTION_NAME = "DefaultDB";
        public static string LoadConnectionString(string id = DB_CONNECTION_NAME) => ConfigurationManager.ConnectionStrings[id].ConnectionString;
        public static string CheckUser(string username, string password)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                var output = connection.Query<User>($"SELECT Id FROM UserAcc WHERE UserName = '{username}' AND UserPass = '{password}';");
                if (output.Count() == 1)
                {
                    return output.ElementAt(0).Id.ToString();
                }
                else
                    return "No";
            }
            
        }
        public static string RegistUser(string login, string password)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString())) {
                var output = connection.Query<User>($"Select * From UserAcc Where UserName = '{login}';");
                if (output.Count() == 0)
                {
                    var Regist = connection.Query<User>($"Insert into UserAcc(UserName, UserPass) Values ('{login}', '{password}');");
                    var output2 = connection.Query<User>($"Select * From UserAcc Where UserName = '{login}';");
                    return output2.ElementAt(0).Id.ToString();
                }
                else
                {
                    return "lol";
                }
            }
        }
    }
}
