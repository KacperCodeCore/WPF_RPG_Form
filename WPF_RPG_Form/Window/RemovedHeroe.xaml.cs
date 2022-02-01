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

            dataBase1.ConectRemovedHeroe();

            DG1.ItemsSource = Heroe.ListoOfRemovedHeroes;
        }

        private void Button_Restore(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {

        }

        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
