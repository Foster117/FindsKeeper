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
using ViewModel;

namespace Presentation.Windows
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();

        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ((dynamic)DataContext).Password = ((PasswordBox)sender).Password;
        }

        private void RepeatPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ((dynamic)DataContext).RepeatPassword = ((PasswordBox)sender).Password;
        }
    }
}
