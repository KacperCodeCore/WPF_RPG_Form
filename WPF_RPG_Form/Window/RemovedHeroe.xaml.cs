using System;
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

namespace WPF_RPG_Form
{
    public partial class RemovedHeroe : Window
    {
        DataBase dataBase1 = new DataBase();
        public RemovedHeroe()
        {
            InitializeComponent();

            Heroe.ListoOfRemovedHeroes.Clear();
            dataBase1.ConectRemovedHeroe();

            DG1.ItemsSource = Heroe.ListoOfRemovedHeroes;
        }

        private void Button_Restore(object sender, RoutedEventArgs e)
        {
            if (DG1.SelectedItem != null)
            {
                int index = Heroe.ListoOfRemovedHeroes.IndexOf(DG1.SelectedItem as Heroe);
                dataBase1.MoveFromRemovedToHeroe(Heroe.ListoOfRemovedHeroes[index].id);
                Heroe.ListoOfRemovedHeroes.RemoveAt(index);
                DG1.Items.Refresh();
            }

        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            if (DG1.SelectedItem != null)
            {
                int index = Heroe.ListoOfRemovedHeroes.IndexOf(DG1.SelectedItem as Heroe);
                dataBase1.DeleteRemovedHeroe(Heroe.ListoOfRemovedHeroes[index].id);
                Heroe.ListoOfRemovedHeroes.RemoveAt(index);
                DG1.Items.Refresh();
            }
        }

        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
