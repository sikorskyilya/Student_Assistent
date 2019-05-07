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

namespace Student_Assistent
{
    /// <summary>
    /// Логика взаимодействия для Enter.xaml
    /// </summary>
    /// 
    public partial class Enter : Window
    {
        public string UserId;
        public Enter()
        {
            InitializeComponent();
        }
        private void WindowMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void Quit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Svern(object sender, RoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        public void CheckUser(object sender, RoutedEventArgs e)
        {
            UserId = DBAccess.CheckUser(this.Login_text.Text, this.Password_text.Password);
            if ( UserId == null || UserId == "No")
            {
                Uncorrect.Visibility = Visibility.Visible;
            }
            else
            {
                Menu menu = new Menu(UserId.ToString());
                menu.Show();
                this.Close();
            }
        }
    }
}
