﻿using System;
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
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        string UserId;
        public Menu(string User)
        {
            UserId = User;
            InitializeComponent();
            Useriii.Text = UserId;
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
        private void TextEditor(object sender, RoutedEventArgs e)
        {
            TexTEditor.TextEd textEd = new TexTEditor.TextEd(UserId);
            textEd.Show();
        }
        private void Rasp(object sender, RoutedEventArgs e)
        {
            RaspView.Rasp rasp = new RaspView.Rasp();
            rasp.Show();
        }
        private void AddRasp(object sender, RoutedEventArgs e)
        {
            AddRasp addRasp = new AddRasp();
            addRasp.Show();
        }
    }
}
