using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.IO;

namespace P_Lista_3_formularz
{

    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            bool fileExists = File.Exists($"{Environment.CurrentDirectory}\\PersonsList.xml");
            if (!fileExists)
            {
                Heroe.ListoOfHeroes = new List<Heroe>();
            }
            else
            {
                Heroe.ListoOfHeroes = Seriazation.DeserializeToObject<List<Heroe>>($"{Environment.CurrentDirectory}\\PersonsList.xml");
            }

            DG.ItemsSource = Heroe.ListoOfHeroes;

            Heroe.ListoOfHeroes.Add(new Heroe("kacper", HeroeType.Hunter.ToString(), 44, 25, "timeloop", "sword"));
            Heroe.ListoOfHeroes.Add(new Heroe("Jan", HeroeType.Paladin.ToString(), 554, 25, "timeloop", "sword"));

            //DG.ItemsSource = GetPlayer();
            DG.ItemsSource = Heroe.ListoOfHeroes;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button.Content.ToString() == "Add Person")
            {
                var createHeroeWindow = new HeroeCreator();
                var heroe = new Heroe();
                createHeroeWindow.DataContext = heroe;
                createHeroeWindow.ShowDialog();   
                if (createHeroeWindow.IsOkPressed)
                {
                    Heroe.ListoOfHeroes.Add(heroe);
                    DG.Items.Refresh(); //??? nie potrzeba, tylko testowo
                }
            }
            else if (button.Content.ToString() == "Edit")
            {
                if (DG.SelectedItem != null)
                {
                    int index = Heroe.ListoOfHeroes.IndexOf((Heroe)DG.SelectedItem);

                    var window = new HeroeCreator();
                    window.ShowDialog();
                }
            }

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Seriazation.SerializeToXml<List<Heroe>>(Heroe.ListoOfHeroes, $"{Environment.CurrentDirectory}\\PersonsList.xml");
        }
    }
}
