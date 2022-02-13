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
        DataBase dataBase1 = new DataBase();
        public MainWindow()
        {

            InitializeComponent();
            dataBase.ConectHeroe();

            DG.ItemsSource = Heroe.ListoOfHeroes;
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            var widow = new HeroeCreator();
            var heroe = new Heroe();
            widow.DataContext = heroe;
            widow.ButtonD.Visibility = Visibility.Hidden;
            widow.ShowDialog();
            if (widow.IsOkPressed == "add")
            {
                dataBase.AddHeroe( heroe.name, heroe.type, heroe.hp, heroe.mana, heroe.skill, heroe.skill2, heroe.weapon);
                Heroe.ListoOfHeroes.Clear();
                //!!!zamiast usówać wszystko można by dodać tylko zaciągnąć id i pobrać 1 row
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
                    dataBase.UpdateHeroe(Heroe.id, Heroe.name, Heroe.type, Heroe.hp, Heroe.mana, Heroe.skill, Heroe.skill2, Heroe.weapon);
                    Heroe.ListoOfHeroes[index] = Heroe;
                    DG.Items.Refresh();
                }
                else if (window.IsOkPressed == "delete")
                {
                    int index = Heroe.ListoOfHeroes.IndexOf(DG.SelectedItem as Heroe);
                    Heroe.ListoOfRemovedHeroes.Add(Heroe.ListoOfHeroes[index]);
                    dataBase.AddDeletedHeroe(Heroe.name, Heroe.type, Heroe.hp, Heroe.mana, Heroe.skill, Heroe.skill2, Heroe.weapon);
                    dataBase.DeleteHeroe(Heroe.id);
                    Heroe.ListoOfHeroes.RemoveAt(index);
                    DG.Items.Refresh();
                }

            }

        }
        private void Button_Fight(object sender, RoutedEventArgs e)
        {
            if (DG.SelectedItem != null)
            {
                var window = new HeroeFight();
                var Heroe = new Heroe((Heroe)DG.SelectedItem);
                HeroeFight.qSpell = Heroe.skill;
                HeroeFight.eSpell = Heroe.skill2;
                HeroeFight.weapon = Heroe.weapon;
                window.ShowDialog();
            }
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Seriazation.SerializeToXml<List<Heroe>>(Heroe.ListoOfHeroes, $"{Environment.CurrentDirectory}\\ListOfHeroes.xml");
        }

        private void DG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Button_Removed(object sender, RoutedEventArgs e)
        {
            var window = new RemovedHeroe();
            window.ShowDialog();
            Heroe.ListoOfHeroes.Clear();
            dataBase.ConectHeroe();
            RefreshItemsDG();
            //!!!
        }
        public void RefreshItemsDG()
        {
            DG.Items.Refresh();
        }

        private void Button_Report(object sender, RoutedEventArgs e)
        {
            var window = new HeroeReport();
            window.ShowDialog();
        }
    }
}
