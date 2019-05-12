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

namespace Student_Assistent.TexTEditor
{
    /// <summary>
    /// Логика взаимодействия для TextEd.xaml
    /// </summary>
    public partial class TextEd : Window
    {
        string _UserID;
        public TextEd(string UserId)
        {
            _UserID = UserId;
            InitializeComponent();
            UserTextVarning.Text = TexTEditor.Text.UserText(UserId, 1);
            UserTextKP.Text = TexTEditor.Text.UserText(UserId, 2);
            UserTextLab.Text = TexTEditor.Text.UserText(UserId, 3);
            UserTextAny.Text =  TexTEditor.Text.UserText(UserId, 4);
        }
        private void WindowMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void Quit(object sender, RoutedEventArgs e)
        {
            TexTEditor.Text.SaveText(_UserID, UserTextVarning.Text, UserTextKP.Text, UserTextLab.Text, UserTextAny.Text);
            this.Close();
        }
        private void Svern(object sender, RoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }
    }
}
