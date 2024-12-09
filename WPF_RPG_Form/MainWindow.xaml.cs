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
            dataBase.LoadAllHeroes();

            DG.ItemsSource = Heroe.ListoOfHeroes;
        }
        public string GetGreetingForTest()
        {
            return "Welcome to WPF RPG!";
        }

        public bool AddHero(string name = "name", string type = "Hunter", int hp = 20, int mana = 20, string skill = "skil1", string skill2 = "skil2", string weapon = "skil1", int lvl = 1)
        {
            try
            {
                var widow = new HeroeCreator();
                var heroe = new Heroe();
                widow.DataContext = heroe;
                widow.ButtonD.Visibility = Visibility.Hidden;
                HeroeCreator.lvl = 1;
                widow.ShowDialog();
                if (widow.IsOkPressed == "add")
                {
                    dataBase.AddHeroe(heroe.name, heroe.type, heroe.hp, heroe.mana, heroe.skill, heroe.skill2, heroe.weapon, 1);
                    Heroe.ListoOfHeroes.Clear();
                    //!!!zamiast usówać wszystko można by dodać tylko zaciągnąć id i pobrać 1 row
                    dataBase.LoadAllHeroes();
                    DG.Items.Refresh();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            AddHero();
        }
        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            if (DG.SelectedItem != null)
            {
                var window = new HeroeCreator();
                var heroe = new Heroe((Heroe)DG.SelectedItem);
                window.DataContext = heroe;  
                HeroeCreator.lvl = heroe.lvl;
                window.ShowDialog();
                if (window.IsOkPressed == "add")
                {
                    int index = Heroe.ListoOfHeroes.IndexOf(DG.SelectedItem as Heroe);
                    dataBase.UpdateHeroe(heroe.id, heroe.name, heroe.type, heroe.hp, heroe.mana, heroe.skill, heroe.skill2, heroe.weapon, heroe.lvl);
                    Heroe.ListoOfHeroes[index] = heroe;
                    DG.Items.Refresh();
                }
                else if (window.IsOkPressed == "delete")
                {
                    int index = Heroe.ListoOfHeroes.IndexOf(DG.SelectedItem as Heroe);
                    Heroe.ListoOfRemovedHeroes.Add(Heroe.ListoOfHeroes[index]);
                    dataBase.AddDeletedHeroe(heroe.name, heroe.type, heroe.hp, heroe.mana, heroe.skill, heroe.skill2, heroe.weapon, heroe.lvl);
                    dataBase.DeleteHeroe(heroe.id);
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
                var heroe = new Heroe((Heroe)DG.SelectedItem);
                HeroeFight.maxMana = heroe.mana;
                HeroeFight.mana = heroe.mana;
                HeroeFight.hp = heroe.hp;
                HeroeFight.qSpell = heroe.skill;
                HeroeFight.eSpell = heroe.skill2;
                HeroeFight.weapon = heroe.weapon;
                HeroeFight.lvl = heroe.lvl;
                window.ShowDialog();

                //MessageBox.Show(HeroeFight.lvl.ToString());
                int curentLvl =  heroe.lvl + Convert.ToInt32(HeroeFight.lvl);
                int lvl = Convert.ToInt32(HeroeFight.lvl);


                int index = Heroe.ListoOfHeroes.IndexOf(DG.SelectedItem as Heroe);
                //Heroe.ListoOfHeroes[index].lvl = Convert.ToInt32(HeroeFight.lvl);
                Heroe.ListoOfHeroes[index].lvl = Convert.ToInt32(HeroeFight.lvl);
                dataBase.UpdateHeroe(heroe.id, heroe.name, heroe.type, heroe.hp + lvl, heroe.mana + lvl, heroe.skill, heroe.skill2, heroe.weapon, curentLvl);
                DG.Items.Refresh();
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
            dataBase.LoadAllHeroes();
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
