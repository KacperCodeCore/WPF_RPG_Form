using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO.Packaging;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Threading;

namespace WPF_RPG_Form
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HeroeFight : Window
    {

        public static string qSpell;
        public static string eSpell;
        public static string weapon;
        public static double maxMana;
        public static double mana = maxMana;
        public static double hp;
        public static double lvl;

        DispatcherTimer gameTimer = new DispatcherTimer();
        bool moveLeft, moveRight, moveUp, moveDown;
        List<Rectangle> itemRemover = new List<Rectangle>();

        Random rand = new Random();

        int enemySpriteCounter = 0;
        int enemyCounter = 100;
        int playerSpeed = 10;
        int limit = 50;
        int score = 0;
        int enemySpeed = 10;
        

        Rect playerHitBox;

        public HeroeFight()
        {
            InitializeComponent();

            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

            MyCanvas.Focus();

            ImageBrush bg = new ImageBrush();

            bg.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/grass.jpg"));
            bg.TileMode = TileMode.Tile;
            bg.Viewport = new Rect(0, 0, 0.15, 0.15);
            bg.ViewportUnits = BrushMappingMode.RelativeToBoundingBox;
            MyCanvas.Background = bg;

            ImageBrush playerImage = new ImageBrush();
            playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/player.png"));
            player.Fill = playerImage;


        }

        private void GameLoop(object sender, EventArgs e)
        {
            playerHitBox = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width, player.Height);

            enemyCounter -= 1;

            scoreText.Content = "Score: " + score;
            

            if (mana < maxMana)
            {
                mana += 0.1;
            }

            hpRec.Width = hp * 2;
            manaRec.Width = mana * 2;

            if (enemyCounter < 0)
            {
                MakeEnemies();
                enemyCounter = limit;
            }

            if (moveLeft == true && Canvas.GetLeft(player) > 0)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) - playerSpeed);
            }
            if (moveRight == true && Canvas.GetLeft(player) + 90 < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) + playerSpeed);
            }
            if (moveUp == true && Canvas.GetTop(player) > 0)
            {
                Canvas.SetTop(player, Canvas.GetTop(player) - playerSpeed);
            }
            if (moveDown == true && Canvas.GetTop(player) + 90 < Application.Current.MainWindow.Width)
            {
                Canvas.SetTop(player, Canvas.GetTop(player) + playerSpeed);
            }


            foreach (var x in MyCanvas.Children.OfType<Rectangle>())
            {
                if (x is Rectangle && (string)x.Tag == "bullet")
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) + 20);

                    Rect bulletHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (Canvas.GetLeft(x) > 800)
                    {
                        itemRemover.Add(x);
                    }

                    foreach (var y in MyCanvas.Children.OfType<Rectangle>())
                    {
                        if (y is Rectangle && (string)y.Tag == "enemy")
                        {
                            Rect enemyHit = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);

                            if (bulletHitBox.IntersectsWith(enemyHit))
                            {
                                itemRemover.Add(x);
                                itemRemover.Add(y);
                                score++;
                            }
                        }
                    }

                }

                if (x is Rectangle && (string)x.Tag == "enemy")
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - enemySpeed);

                    if (Canvas.GetLeft(x) < 10)
                    {
                        itemRemover.Add(x);
                        hp -= 10;
                    }

                    Rect enemyHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (playerHitBox.IntersectsWith(enemyHitBox))
                    {
                        itemRemover.Add(x);
                        hp -= 5;
                    }

                }
            }

            foreach (Rectangle i in itemRemover)
            {
                MyCanvas.Children.Remove(i);
            }


            if (score > 5)
            {
                limit = 40;
                enemySpeed = 12;
            }
            if (score > 10)
            {
                limit = 30;
                enemySpeed = 13;
            }
            if (score > 15)
            {
                limit = 30;
                enemySpeed = 14;
            }
            if (score > 20)
            {
                limit = 20;
                enemySpeed = 15;
            }

            if (hp < 1)
            {
                gameTimer.Stop();

                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();

            }
            if (score > 10)
            {
                gameTimer.Stop();
                lvl++;

                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }

            playerSpeed = 10;


        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                moveLeft = true;
            }
            if (e.Key == Key.D)
            {
                moveRight = true;
            }
            if (e.Key == Key.W)
            {
                moveUp = true;
            }
            if (e.Key == Key.S)
            {
                moveDown = true;
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                moveLeft = false;
            }
            if (e.Key == Key.D)
            {
                moveRight = false;
            }
            if (e.Key == Key.W)
            {
                moveUp = false;
            }
            if (e.Key == Key.S)
            {
                moveDown = false;
            }

            if (e.Key == Key.Space)
            {
                if (weapon == "LaserStaff")
                {
                    Rectangle newBullet = new Rectangle
                    {
                        Tag = "bullet",
                        Height = 2,
                        Width = 100,

                    };
                    ImageBrush bulletImage = new ImageBrush();
                    bulletImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/laserStaff.png"));
                    newBullet.Fill = bulletImage;
                    Canvas.SetLeft(newBullet, Canvas.GetLeft(player) + player.Width / 2);
                    Canvas.SetTop(newBullet, Canvas.GetTop(player) + 20);

                    MyCanvas.Children.Add(newBullet);
                }
                else if (weapon == "FireStaff")
                {
                    Rectangle newBullet = new Rectangle
                    {
                        Tag = "bullet",
                        Height = 5,
                        Width = 25,

                    };
                    ImageBrush bulletImage = new ImageBrush();
                    bulletImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/smallFireBall.png"));
                    newBullet.Fill = bulletImage;
                    Canvas.SetLeft(newBullet, Canvas.GetLeft(player) + player.Width / 2);
                    Canvas.SetTop(newBullet, Canvas.GetTop(player) + 20);

                    MyCanvas.Children.Add(newBullet);
                }

            }

            if (e.Key == Key.Q && mana > 10)
            {
                if (qSpell == "FireBall")
                {
                    Rectangle newBullet = new Rectangle
                    {
                        Tag = "bullet",
                        Height = 298,
                        Width = 378,
                        FlowDirection = FlowDirection.LeftToRight

                    };

                    ImageBrush bulletImage = new ImageBrush();
                    bulletImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/fireball.png"));
                    newBullet.Fill = bulletImage;
                    Canvas.SetLeft(newBullet, Canvas.GetLeft(player) - 100);
                    Canvas.SetTop(newBullet, Canvas.GetTop(player) - 140);

                    mana -= 10;
                    MyCanvas.Children.Add(newBullet);
                }
                else if (qSpell == "Electric")
                {
                    Rectangle newBullet = new Rectangle
                    {
                        Tag = "bullet",
                        Height = 550,
                        Width = 40,
                        FlowDirection = FlowDirection.LeftToRight

                    };

                    ImageBrush bulletImage = new ImageBrush();
                    bulletImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/electric.png"));
                    newBullet.Fill = bulletImage;
                    Canvas.SetLeft(newBullet, Canvas.GetLeft(player));
                    Canvas.SetTop(newBullet, Canvas.GetTop(player) - 270);

                    mana -= 15;
                    MyCanvas.Children.Add(newBullet);
                }

            }else if (e.Key == Key.LeftShift && mana > 10)
            {
                if (eSpell == "Teleport")
                {
                    playerSpeed = 200;
                }
            }
        }

        private void MakeEnemies()
        {
            ImageBrush enemySprite = new ImageBrush();

            enemySpriteCounter = rand.Next(1, 3);

            switch (enemySpriteCounter)
            {
                case 1:
                    enemySprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/1.png"));
                    break;
                case 2:
                    enemySprite.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/2.png"));
                    break;
            }

            Rectangle newEnemy = new Rectangle
            {
                Tag = "enemy",
                Height = 50,
                Width = 56,
                Fill = enemySprite
            };

            Canvas.SetTop(newEnemy, rand.Next(30, 570));
            Canvas.SetLeft(newEnemy, 930);
            MyCanvas.Children.Add(newEnemy);

        }
    }
}
