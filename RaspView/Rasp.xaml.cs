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

namespace Student_Assistent.RaspView
{
    /// <summary>
    /// Логика взаимодействия для Rasp.xaml
    /// </summary>
    public partial class Rasp : Window
    {
        public Rasp()
        {
            InitializeComponent();
            Loaded += Rasp_Loader;
        }
        private void Rasp_Loader(object sender, RoutedEventArgs e)
        {
            DataContext = new RaspVievModel.RasViewModel();
        }
    }
}
