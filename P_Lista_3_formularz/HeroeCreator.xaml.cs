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

namespace P_Lista_3_formularz
{
    /// <summary>
    /// Interaction logic for PersonCreator.xaml
    /// </summary>
    public partial class HeroeCreator : Window
    {
        public bool IsOkPressed { get; set; }
        public HeroeCreator()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var button = sender as Button;
            //if (button.Content.ToString() == "Add Person")
            //{

            //    Heroe.ListoOfHeroes.Add(new Heroe("oldfryd", HeroeType.Warrior.ToString(), 70, 200));
            //}
            IsOkPressed = true;
            this.Close();
        }
    }
}
