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
    /// <summary>
    /// Interaction logic for HeroeReport.xaml
    /// </summary>
    public partial class HeroeReport : Window
    {
        public HeroeReport()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(HeroeReport_Load);

        }

        private void HeroeReport_Load(object sender, RoutedEventArgs e)
        {
            this.ReportViewer.ReportPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources/HeroeReport1.rdl");
            this.ReportViewer.RefreshReport();
        }
    }
}
