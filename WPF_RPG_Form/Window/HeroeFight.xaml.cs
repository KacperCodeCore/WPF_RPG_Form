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
using System.Windows.Threading;


namespace WPF_RPG_Form
{
    /// <summary>
    /// Interaction logic for HeroeFight.xaml
    /// </summary>
    public partial class HeroeFight : Window
    {
        int playerSpeed = 8;
        int speed = 12;

        DispatcherTimer gameTimer = new DispatcherTimer();
        public HeroeFight()
        {
            InitializeComponent();

            myCanvas.Focus();
        }

        public int x
        {
            get { return (int)GetValue(xProperty); }
            set { SetValue(xProperty, value); }
        }
        public int y
        {
            get { return (int)GetValue(yProperty); }
            set { SetValue(yProperty, value); }
        }

        public static readonly DependencyProperty xProperty = DependencyProperty.Register("x", typeof(int), typeof(HeroeFight), new PropertyMetadata(0));
        public static readonly DependencyProperty yProperty = DependencyProperty.Register("y", typeof(int), typeof(HeroeFight), new PropertyMetadata(0));

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                y -= playerSpeed;
            }
            if (e.Key == Key.S)
            {
                y += playerSpeed;
            }
            if (e.Key == Key.A)
            {
                x -= playerSpeed;
            }
            if (e.Key == Key.D)
            {
                x += playerSpeed;
            }
            
        }

        //private void KeyIsUp(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.W)
        //    {
        //        goUp = false;
        //    }
        //    if (e.Key == Key.S)
        //    {
        //        goDown = false;
        //    }
        //    if (e.Key == Key.A)
        //    {
        //        goLeft = false;
        //    }
        //    if (e.Key == Key.D)
        //    {
        //        goRight = false;
        //    }
            
        //}
    }
}
