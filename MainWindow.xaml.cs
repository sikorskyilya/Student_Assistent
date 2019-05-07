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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Student_Assistent
{
    public partial class MainWindow : Window
    {
        public MainWindow()
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
        private void Enter(object sender, RoutedEventArgs e)
        {
            Enter enter = new Enter();
            enter.Show();
            this.Close();
        }
        private void Svern(object sender, RoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }
        private void _Registration(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

    }
}
