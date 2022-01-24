﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.IO;

namespace WPF_RPG_Form
{

    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            //bool fileExists = File.Exists($"{Environment.CurrentDirectory}\\ListOfHeroes.xml");
            //if (!fileExists)
            //{
            //    Heroe.ListoOfHeroes = new List<Heroe>();
            //}
            //else
            //{
            //    Heroe.ListoOfHeroes = Seriazation.DeserializeToObject<List<Heroe>>($"{Environment.CurrentDirectory}\\ListOfHeroes.xml");
            //}


            DataBase dataBase = new DataBase();

            DG.ItemsSource = Heroe.ListoOfHeroes;
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            var widow = new HeroeCreator();
            var heroe = new Heroe();
            widow.DataContext = heroe;
            widow.ShowDialog();   
            if (widow.IsOkPressed == "add")
            {
                Heroe.ListoOfHeroes.Add(heroe);
                DG.Items.Refresh(); //??? nie potrzeba, tylko testowo
            }
        }
        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            if (DG.SelectedItem != null)
            {
                var window = new HeroeCreator();
                var Heroe = new Heroe((Heroe)DG.SelectedItem);
                window.DataContext = Heroe;
                window.ShowDialog();
                if (window.IsOkPressed == "add")
                {
                    int index = Heroe.ListoOfHeroes.IndexOf(DG.SelectedItem as Heroe);
                    Heroe.ListoOfHeroes[index] = Heroe;
                    DG.Items.Refresh();
                }
                else if (window.IsOkPressed == "delete")
                {
                    int index = Heroe.ListoOfHeroes.IndexOf(DG.SelectedItem as Heroe);
                    Heroe.ListoOfHeroes.RemoveAt(index);
                    DG.Items.Refresh();
                }

            }

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Seriazation.SerializeToXml<List<Heroe>>(Heroe.ListoOfHeroes, $"{Environment.CurrentDirectory}\\ListOfHeroes.xml");
        }

    }
}