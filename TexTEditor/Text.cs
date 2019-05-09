using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;
using Dapper;
namespace Student_Assistent.TexTEditor
{
    class Text
    {
        private const string DB_CONNECTION_NAME = "DefaultDB";
        public static string LoadConnectionString(string id = DB_CONNECTION_NAME) => ConfigurationManager.ConnectionStrings[id].ConnectionString;
        public static string UserText(string UserId)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                var output = connection.Query<string>($"SELECT UserId From UserTextBox Where UserId = '{UserId}';");
                if (output.Count() == 1)
                {
                    output = connection.Query<string>($"SELECT UserText FROM UserTextBox Where UserId = '{UserId}';");
                    return output.ElementAt(0).ToString();
                }
                else
                {
                    var output2 = connection.Query<string>($"SELECT UserText From UserTextBox Where UserId = '{UserId}';");
                    return output2.ElementAt(0).ToString();
                }
            }

        }
        public static void SaveText(string UserId, string Text)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                var output = connection.Query<string>($"UPDATE UserTextBox SET UserText = '{Text}' WHERE UserId = '{UserId}';");
            }
        }

    }
}
