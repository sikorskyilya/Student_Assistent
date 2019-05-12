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
        public static string UserText(string UserId, int i)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                var output = connection.Query<string>($"SELECT UserId From UserTextBox Where UserId = '{UserId}';");
                if (output.Count() == 0)
                {
                    using (SQLiteConnection connection1 = new SQLiteConnection(LoadConnectionString()))
                    {
                        var output1 = connection.Query<string>($"Insert into UserTextBox(UserId) Values ('{UserId}');");
                    }
                }
                output = connection.Query<string>($"SELECT UserId From UserTextBox Where UserId = '{UserId}';");
                if (output.Count() == 1)
                {
                    switch(i)
                    {
                        case 1:
                            {
                                output = connection.Query<string>($"SELECT ifnull(TextVarning, 'Внесите свою первую запись') FROM UserTextBox Where UserId = '{UserId}';");
                                return output.ElementAt(0).ToString();
                            }
                        case 2:
                            {
                                output = connection.Query<string>($"SELECT ifnull(TextKP,'Внесите свою первую запись') FROM UserTextBox Where UserId = '{UserId}';");
                                return output.ElementAt(0).ToString();
                            }
                        case 3:
                            {
                                output = connection.Query<string>($"SELECT ifnull(TextLab,'Внесите свою первую запись') FROM UserTextBox Where UserId = '{UserId}';");
                                return output.ElementAt(0).ToString();
                            }
                        case 4:
                            {
                                output = connection.Query<string>($"SELECT ifnull(TextAny,'Внесите свою первую запись') FROM UserTextBox Where UserId = '{UserId}';");
                                return output.ElementAt(0).ToString();
                            }

                    }
                }
                return "errror";
            }
             
        }
        public static void SaveText(string UserId, string TextVar, string TextKP, string TextLab, string TextAny)
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                var output = connection.Query<string>($"UPDATE UserTextBox SET TextVarning = '{TextVar}', TextKP = '{TextKP}', TextLab = '{TextLab}', TextAny = '{TextAny}' WHERE UserId = '{UserId}';");
            }
        }

    }
}
