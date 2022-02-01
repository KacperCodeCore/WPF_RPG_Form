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


        private void GameTimeEvent(object sender, EventArgs e)
        {
            if (goLeft == true && Canvas.GetLeft(player) > 5)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) - playerSpeed);
            }
            if (goRight == true && Canvas.GetLeft(player) + (player.Width + 20) < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) + playerSpeed);
            }
            //if (goUp == true && Canvas.GetTop(player) > 5)
            //{
            //    Canvas.SetTop(player, Canvas.GetTop(player) - playerSpeed);
            //}
            //if (goDown == true && Canvas.GetTop(player) + (player.Height + 30) < Application.Current.MainWindow.Height)
            //{
            //    Canvas.SetBottom(player, Canvas.GetBottom(player) + playerSpeed);
            //}
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                goUp = true;
            }
            if (e.Key == Key.S)
            {
                goDown = true;
            }
            if (e.Key == Key.A)
            {
                goLeft = true;
            }
            if (e.Key == Key.D)
            {
                goRight = true;
            }
            
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                goUp = false;
            }
            if (e.Key == Key.S)
            {
                goDown = false;
            }
            if (e.Key == Key.A)
            {
                goLeft = false;
            }
            if (e.Key == Key.D)
            {
                goRight = false;
            }
            
        }
    }
}
