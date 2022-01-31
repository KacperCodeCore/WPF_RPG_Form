using System;
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
         DataBase dataBase = new DataBase();
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


            dataBase.ConectHeroe();

            DG.ItemsSource = Heroe.ListoOfHeroes;
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            //var widow = new HeroeCreator();
            //var heroe = new Heroe();
            //widow.DataContext = heroe;
            //widow.ShowDialog();   
            //if (widow.IsOkPressed == "add")
            //{
            //    Heroe.ListoOfHeroes.Add(heroe);
            //    DG.Items.Refresh(); //??? nie potrzeba, tylko testowo
            //}
            var widow = new HeroeCreator();
            var heroe = new Heroe();
            widow.DataContext = heroe;
            widow.ShowDialog();
            if (widow.IsOkPressed == "add")
            {
                dataBase.AddHeroe(heroe.name, heroe.type, heroe.hp, heroe.mana, heroe.skill, heroe.weapon);
                Heroe.ListoOfHeroes.Clear();
                //!!!zamiast usówać wszystko można by dodać tylko 1 row i zaciągnąć id
                dataBase.ConectHeroe();
                DG.Items.Refresh();
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
                    dataBase.UpdateHeroe(Heroe.id, Heroe.name, Heroe.type, Heroe.hp, Heroe.mana, Heroe.skill, Heroe.weapon);
                    Heroe.ListoOfHeroes[index] = Heroe;
                    DG.Items.Refresh();
                }
                else if (window.IsOkPressed == "delete")
                {
                    int index = Heroe.ListoOfHeroes.IndexOf(DG.SelectedItem as Heroe);
                    dataBase.DeleteHeroe(Heroe.id);
                    //!!!tu powinno się przenosić do innej bazy zamiast usówać
                    Heroe.ListoOfHeroes.RemoveAt(index);
                    DG.Items.Refresh();
                }

            }

        }
        private void Button_Fight(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("fight");
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Seriazation.SerializeToXml<List<Heroe>>(Heroe.ListoOfHeroes, $"{Environment.CurrentDirectory}\\ListOfHeroes.xml");
        }

        private void DG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
    }
}
