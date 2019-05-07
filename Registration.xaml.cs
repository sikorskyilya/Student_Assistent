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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        private void WindowMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void Svern(object sender, RoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }
        private void Quit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void RegistUser(object sender, RoutedEventArgs e)
        {
            string UserId = DBAccess.RegistUser(Login_text.Text, Password_text.Password);
            if(UserId == "No")
            {
                Uncorrect.Visibility = Visibility.Visible;
            }
            else
            { 
                Menu menu = new Menu(UserId);
                menu.Show();
                this.Close();
            }
        }
    }
}
