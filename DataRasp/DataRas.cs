using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;
using Dapper;
using Student_Assistent;
namespace Student_Assistent.DataRasp
{
    class DataRas
    {
        private const string DB_CONNECTION_NAME = "DefaultDB";
        public static string LoadConnectionString(string id = DB_CONNECTION_NAME) => ConfigurationManager.ConnectionStrings[id].ConnectionString;
        public string Day { get; set; }
        public string Time { get; set; }
        public string Place { get; set; }
        public string Subject { get; set; }
        public string Type { get; set; }
        public string Teacher { get; set; }
        public DataRas() { }
        public DataRas(string _day, string _time, string _place, string _subject, string _type, string _teacher)
        {
            this.Day = _day;
            this.Time = _time;
            this.Place = _place;
            this.Subject = _subject;
            this.Type = _type;
            this.Teacher = _teacher;
        }
        public static DataRas[] GetDataRas()
        {
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string User = DBAccess.User();
                var output = connection.Query<DataRas>($"Select * from Rasp Where UserId = '{User}'").ToArray();
                return output;
            }
        }
    }
}
