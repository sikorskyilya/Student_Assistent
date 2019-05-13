using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Configuration;
using Dapper;

namespace Student_Assistent
{
    /// <summary>
    /// Логика взаимодействия для AddRasp.xaml
    /// </summary>
    public partial class AddRasp : Window
    {
        private const string DB_CONNECTION_NAME = "DefaultDB";
        public static string LoadConnectionString(string id = DB_CONNECTION_NAME) => ConfigurationManager.ConnectionStrings[id].ConnectionString;
        public AddRasp()
        {
            InitializeComponent();
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            string id = DBAccess.User();
            using (SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
               // connection.Query<string>($"SELECT Id FROM UserAcc WHERE UserName = '{username}' AND UserPass = '{password}';");
                
            }
            DataRasp.DataRas dataRas = new DataRasp.DataRas(Day.SelectedItem.ToString(), Time.SelectedItem.ToString(), Place.Text, Subject.Text, Type.SelectedItem.ToString(), Professor.Text);
        }
    }
}
