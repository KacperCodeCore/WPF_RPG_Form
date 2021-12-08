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
    }
}
