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
        bool goLeft, goRight, goUp, goDown;
        int playerSpeed = 8;
        int speed = 12;

        DispatcherTimer gameTimer = new DispatcherTimer();
        public HeroeFight()
        {
            InitializeComponent();

            myCanvas.Focus();
            gameTimer.Tick += GameTimeEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Start();
        }

        private void myCanvas_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void GameTimeEvent(object sender, EventArgs e)
        {
            
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {

        }
    }
}
