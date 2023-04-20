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

namespace Rezervacni_system
{
    /// <summary>
    /// Interakční logika pro SubWindow.xaml
    /// </summary>
    public partial class SubWindow : Window
    {

        public string Atributes { get; set; }

        public SubWindow(String Atributes)
        {
            InitializeComponent();


            this.Atributes = Atributes;

            string[] location = Atributes.Split('_');

            Label.Content = "Sedadlo -" + " řada: " + location[1] + " číslo: " + location[2];
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
