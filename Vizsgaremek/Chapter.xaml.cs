﻿using System;
using System.Collections.Generic;
using System.IO;
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
using Path = System.IO.Path;

namespace Vizsgaremek
{
    public partial class Chapter : Page
    {
        private Fooldal Fooldal;
        public Chapter()
        {
            InitializeComponent();
            
        }
        private void OpenFooldal_Click(object sender, RoutedEventArgs e)
        {
            Fooldal fooldal = Window.GetWindow(this) as Fooldal;

            if (fooldal != null)
            {
                fooldal.WindowState = WindowState.Normal; 
                fooldal.Activate();
                fooldal.Focus();

                Window.GetWindow(this)?.Close();
            }
            else
            {
                fooldal = new Fooldal();
                fooldal.Show();
                Window.GetWindow(this)?.Close();
            }
        }
    }
}
