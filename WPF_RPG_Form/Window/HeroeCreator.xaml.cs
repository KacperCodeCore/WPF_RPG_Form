﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_RPG_Form
{
    /// <summary>
    /// Interaction logic for PersonCreator.xaml
    /// </summary>
   
    public partial class HeroeCreator : Window
    {
        public static int lvl;
        private Regex intRegex = new Regex(@"^[1-9]{1}[0-9]*$");
        public string IsOkPressed { get; set; }
        
        public HeroeCreator()
        {
            InitializeComponent();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            IsOkPressed = "add";
            this.Close();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            IsOkPressed = "delete";
            this.Close();
        }

        private void Mana_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = Mana.Text;
            if (!intRegex.IsMatch(text))
            {
                Mana.Text = (100 + lvl).ToString();
            }
            else if (Convert.ToInt32(text) > 100)
            {
                Mana.Text = (100 + lvl).ToString();
            }
        }

        private void Hp_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = Hp.Text;
            if (!intRegex.IsMatch(text))
            {
                Hp.Text = (100 + lvl).ToString();
            }
            else if (Convert.ToInt32(text) > 100)
            {
                Hp.Text = (100 + lvl).ToString();
            }
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Name.Text.Length == 0)
            {
                Name.Text = "H";
            }
        }
    }
    
}

