using HeroTowerDefense.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace HeroTowerDefense
{
    public partial class MainWindow : Window
    {

        bool archerSelected = false;
        bool darkWizardSelected = false;
        bool cannonTowerSelected = false;
        private Image selected;
        private Ellipse rangeIndicator;
        List<Enemy> livingEnemies = new List<Enemy>();
        List<Tower> towerList = new List<Tower>();

        public MainWindow() //Initializes everything, gets the path for the game logic and sets the initial states for the GUI information.
        {
            InitializeComponent();
            UpdateGameInfo();

            archerCostLabel.Content = "Cost: " + GameInfo.archerCost.ToString();
            darkWizardCostLabel.Content = "Cost: " + GameInfo.darkWizardCost.ToString();
            cannonCostLabel.Content = "Cost: " + GameInfo.cannonCost.ToString();
        }

        public void ArcherTowerButton(object source, RoutedEventArgs args) //Creates a new archer tower and a new range indicator ellipse
        {
            if (!CheckSelected() && GameInfo.Money >= GameInfo.archerCost)
            {
                rangeIndicator = new Ellipse();
                rangeIndicator.Height = GameInfo.archerRange;
                rangeIndicator.Width = GameInfo.archerRange;
                SolidColorBrush col = new SolidColorBrush();
                col.Color = Color.FromArgb(140, 100, 100, 100);
                rangeIndicator.Fill = col;
                mapCanvas.Children.Add(rangeIndicator);

                archerSelected = true;
                selected = new Image();
                selected.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + @"Assets\archertower.png"));
                selected.Height = 60;
                mapCanvas.Children.Add(selected);
                GameInfo.Money -= GameInfo.archerCost;
                UpdateGameInfo();
            
            }
            else if (GameInfo.Money <= GameInfo.archerCost)
                MessageBox.Show( "You don't have enough money!" );
        }

        public void DarkWizardTowerButton(object source, RoutedEventArgs args) //Creates a new dark wizard tower and a new range indicator ellipse
        {
            if (!CheckSelected() && GameInfo.Money >= GameInfo.darkWizardCost)
            {
                rangeIndicator = new Ellipse();
                rangeIndicator.Height = GameInfo.darkWizardRange;
                rangeIndicator.Width = GameInfo.darkWizardRange;
                SolidColorBrush col = new SolidColorBrush();
                col.Color = Color.FromArgb(140, 100, 100, 100);
                rangeIndicator.Fill = col;
                mapCanvas.Children.Add(rangeIndicator);

                darkWizardSelected = true;
                selected = new Image();
                selected.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "Assets/darkwizardtower.png"));
                selected.Height = 60;
                mapCanvas.Children.Add(selected);
                GameInfo.Money -= GameInfo.darkWizardCost;
                UpdateGameInfo();
            }
            else if (GameInfo.Money <= GameInfo.darkWizardCost)
                MessageBox.Show("You don't have enough money!");
        }

        public void CannonTowerButton(object source, RoutedEventArgs args) //Creates a new cannon tower and a new range indicator ellipse
        {
            if (!CheckSelected() && GameInfo.Money >= GameInfo.cannonCost)
            {
                rangeIndicator = new Ellipse();
                rangeIndicator.Height = GameInfo.cannonRange;
                rangeIndicator.Width = GameInfo.cannonRange;
                SolidColorBrush col = new SolidColorBrush();
                col.Color = Color.FromArgb(140, 100, 100, 100);
                rangeIndicator.Fill = col;
                mapCanvas.Children.Add(rangeIndicator);

                cannonTowerSelected = true;
                selected = new Image();
                selected.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "Assets/cannontower.png"));
                selected.Height = 60;
                mapCanvas.Children.Add(selected);
                GameInfo.Money -= GameInfo.cannonCost;
                UpdateGameInfo();
            }
            else if (GameInfo.Money <= GameInfo.cannonCost)
                MessageBox.Show("You don't have enough money!");
        }

        private void MouseMoved(object sender, MouseEventArgs e) //If the mouse moves, move an image of the tower with it, and the tower's range indicator
        {
            if (archerSelected == true || darkWizardSelected == true || cannonTowerSelected == true)
            {
                Canvas.SetLeft(selected, Mouse.GetPosition(this).X - selected.Height / 2);
                Canvas.SetTop(selected, Mouse.GetPosition(this).Y - selected.Height / 2);

                Canvas.SetLeft(rangeIndicator, Mouse.GetPosition(this).X - rangeIndicator.Height / 2);
                Canvas.SetTop(rangeIndicator, Mouse.GetPosition(this).Y - rangeIndicator.Height / 2);
            }
        }

        private void MouseLeftClick(object sender, MouseButtonEventArgs e) //If a tower is selected, place a tower if it is in the map and not on the path. If not, do nothing
        {
            if ( CheckSelected() && ValidPosition((float)(Mouse.GetPosition(this).X - selected.Height / 2), (float)(Mouse.GetPosition(this).Y - selected.Height / 2)))
            {
                if (archerSelected)
                {
                    ArcherTower newTower = new ArcherTower(new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "Assets/archertower.png")), (float)(Mouse.GetPosition(this).X - selected.Height / 2), (float)(Mouse.GetPosition(this).Y - selected.Height / 2));
                    Canvas.SetLeft(newTower.Img, newTower.X);
                    Canvas.SetTop(newTower.Img, newTower.Y);
                    newTower.Img.Height = 60;
                    mapCanvas.Children.Add(newTower.Img);
                    towerList.Add(newTower);
                    newTower.thr = new Thread(() => TowerFiring( newTower ));
                    newTower.thr.Start();
                    SetAllFalse();
                }
                else if (darkWizardSelected)
                {
                    DarkWizardTower newTower = new DarkWizardTower(new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "Assets/darkwizardtower.png")), (float)(Mouse.GetPosition(this).X - selected.Height / 2), (float)(Mouse.GetPosition(this).Y - selected.Height / 2));
                    Canvas.SetLeft(newTower.Img, newTower.X);
                    Canvas.SetTop(newTower.Img, newTower.Y);
                    newTower.Img.Height = 60;
                    mapCanvas.Children.Add(newTower.Img);
                    towerList.Add(newTower);
                    newTower.thr = new Thread(() => TowerFiring(newTower));
                    newTower.thr.Start();
                    SetAllFalse();
                }
                else if (cannonTowerSelected)
                {
                    CannonTower newTower = new CannonTower(new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory + "Assets/cannontower.png")), (float)(Mouse.GetPosition(this).X - selected.Height / 2), (float)(Mouse.GetPosition(this).Y - selected.Height / 2));
                    Canvas.SetLeft(newTower.Img, newTower.X);
                    Canvas.SetTop(newTower.Img, newTower.Y);
                    newTower.Img.Height = 60;
                    mapCanvas.Children.Add(newTower.Img);
                    towerList.Add(newTower);
                    newTower.thr = new Thread(() => TowerFiring(newTower));
                    newTower.thr.Start();
                    SetAllFalse();
                }
            }
            else if( CheckSelected() )
            {
                MessageBox.Show( "Invalid placement!" );
            }

            UpdateGameInfo();
        }

        private void MouseRightClick( object sender, MouseButtonEventArgs e) //Cancels out buying a new tower
        {
            if (archerSelected)
                GameInfo.Money += GameInfo.archerCost;
            else if (darkWizardSelected)
                GameInfo.Money += GameInfo.darkWizardCost;
            else if (cannonTowerSelected)
                GameInfo.Money += GameInfo.cannonCost;

            UpdateGameInfo();
            SetAllFalse();
        }

        private bool CheckSelected() //Checks to see if a tower is currently being placed
        {
            if (archerSelected)
                return true;
            if (darkWizardSelected)
                return true;
            if (cannonTowerSelected)
                return true;

            return false;
        }

        private void SetAllFalse() //Clears everything out
        {
            archerSelected = false;
            darkWizardSelected = false;
            cannonTowerSelected = false;

            if( selected != null )
                selected.Source = null;

            mapCanvas.Children.Remove(rangeIndicator);
            selected = null;
        }

        private bool ValidPosition( float x, float y ) //If the tower isnt on the path, or off the screen
        {
            const int towerSize = 60;
            bool[,] path = GetPath();

            if (x >= (background.ActualWidth - selected.Height)) //If the tower is off the map
                return false;
            if (x <= 0)
                return false;
            if (y >= (background.ActualHeight - (selected.Height + 5)))
                return false;
            if (y <= 0)
                return false;

            foreach( Tower tow in towerList) //To make sure towers cant be stacked on top of each other
            {
                for(int i = ((int)x - ((towerSize / 3) * 2)); i < ((int)x + ((towerSize / 3) * 2)); i++)
                {
                    if (i > 0 && i < 600) //To prevent out of range exceptions on the array
                    {
                        for (int j = ((int)y - ((towerSize / 3) * 2)); j < ((int)y + ((towerSize / 3) * 2)); j++)
                        {
                            if (j > 0 && j < 600) //To prevent out of range exceptions on the array
                            {
                                if (tow.Y == j && tow.X == i)
                                    return false;
                            }
                        }
                    }

                }
            }

            for( int i = ((int)x - (towerSize / 3)); i < ((int)x + (towerSize / 3)); i++) //X axis distance to path
            {
                if(i > 0 && i < 600) //To prevent out of range exceptions on the array
                    if (path[i, (int)y] == true)
                        return false;
            }

            for (int i = ((int)y - (towerSize / 3)); i < ((int)y + (towerSize / 3)); i++) //Y axis distance to path
            {
                if (i > 0 && i < 600) //To prevent out of range exceptions on the array
                    if (path[(int)x, i] == true)
                        return false;
            }

            return true;
        }

        private void UpdateGameInfo()
        {
            health.Content = GameInfo.Health.ToString();
            moneyBox.Text = "$" + GameInfo.Money.ToString();
        }

        private bool[,] GetPath() //Gets a 2d array of bools based on the size of the map. If true, the path is present there, if false, the path is not there.
        {
            bool[,] path = new bool[600,600];
            int x = 0, y = 48;

            for (int i = 0; i < 600; i++)
                for (int j = 0; j < 600; j++)
                    path[i, j] = false;

            for (; x < 36; x++) //First part of path
                path[x, y] = true;

            for (; y < 560; y++) //Second part of path
                path[x, y] = true;

            for (; x < 531; x++) //Third part of path
                path[x, y] = true;

            for (; y >= 50; y--) //Fourth part of path
                path[x, y] = true;

            return path;
        }

        private void WaveButton(object sender, RoutedEventArgs e)
        {
            waveButton.Visibility = Visibility.Hidden;

            Waves.WaveNumber = GameInfo.StartWave();

            waveNumber.Content = GameInfo.WaveNumber;

            RunGame( Waves.WaveNumber );
        }

        private void RunGame( int waveNumber)
        {
            /* Here will go the wave logic. Each wave is listed in Waves.cs. Have the system loop through every member of the wave with a foreach.
             * Spawn the enemy in the enemySpawn, then make them move down along the path until they reach the castle gate. If they reach the gate
             * lower health by 1. If they die, increase money by 1. Might need to make a new thread for each enemy to make them move. Also have towers
             * do damage to the enemies if they move within range.
             */
            int i = 0;

            foreach (Enemy e in Waves.GetWave(0, 48)) //Creates all the enemies, assigns each an id, creates a thread for each enemy. Stores enemies in a list.
            {
                livingEnemies.Add(e);
                e.Id = i++;
                e.thr = new Thread(() => FollowPath(e));
                e.thr.Start();
            }
        }

        private void FollowPath( Enemy foe )
        {
            bool[,] path = GetPath();

            Thread.Sleep(1000 * foe.Id); //Staggers the creation between each enemy

            this.Dispatcher.Invoke(() =>
            {
                Canvas.SetLeft(foe.Img, (foe.X - foe.Img.ActualWidth / 2));
                Canvas.SetTop(foe.Img, (foe.Y - foe.Img.ActualHeight / 2));
                mapCanvas.Children.Add(foe.Img);
            });

            while (foe.Health > 0)//If alive follow the path at movement speed
            {
                foreach( Tower tow in towerList )
                {
                    if (tow.InRange((int)Math.Sqrt(Math.Pow(tow.X - foe.X, 2) + Math.Pow(tow.Y - foe.Y, 2))) && !tow.Fired) //If fired, dont shoot again
                    {
                        foe.Health -= tow.Damage;
                        tow.Fired = true;
                    }
                }

                if (path[(int)foe.X + (int)foe.Speed, (int)foe.Y]) //If the next space to the right is on the path at foe speed distance away
                    {
                        foe.X += foe.Speed;
                    }
                    else if (path[(int)foe.X, (int)foe.Y + (int)foe.Speed] && foe.X < 300) //If the next space down is on the path and it is not past the first vertical path at foe speed distance away
                    {
                        foe.Y += foe.Speed;
                    }
                    else if (path[(int)foe.X, (int)foe.Y - (int)foe.Speed] && foe.X > 300) //If the next space up is on the path and it is past the first vertical path at foe speed distance away
                    {
                        foe.Y -= foe.Speed;
                    }
                    else if (path[(int)foe.X + 1, (int)foe.Y]) //If the next space to the right is on the path at one distance away
                    {
                        foe.X += 1;
                    }
                    else if (path[(int)foe.X, (int)foe.Y + 1] && foe.X < 300) //If the next space down is on the path and it is not past the first vertical path at one distance away
                    {
                        foe.Y += 1;
                    }
                    else if (path[(int)foe.X, (int)foe.Y - 1] && foe.X > 300) //If the next space up is on the path and it is past the first vertical path at one distance away
                    {
                        foe.Y -= 1;
                    }
                    else
                    {
                        foe.Health = 0;
                        GameInfo.Health -= foe.Damage;
                        this.Dispatcher.Invoke(() =>
                        {
                            health.Content = GameInfo.Health;
                            if (foe.Img.Source != null)
                                foe.Img.Source = null;

                            mapCanvas.Children.Remove(foe.Img);
                            livingEnemies.Remove(foe);

                            if (livingEnemies.Count() == 0)
                            {
                                if (Waves.WaveNumber >= GameInfo.maxWave)
                                {
                                    foreach (Enemy en in livingEnemies)
                                    {
                                        en.thr.Abort();
                                    }

                                    foreach (Tower tow in towerList)
                                    {
                                        tow.thr.Abort();
                                    }

                                    MessageBox.Show("Game over! You win!");

                                    this.Close();
                                }
                                else
                                    waveButton.Visibility = Visibility.Visible;
                            }

                            foe.thr.Abort();
                            foe = null;

                            if (GameInfo.Health <= 0)
                            {
                                foreach (Enemy en in livingEnemies)
                                {
                                    en.thr.Abort();
                                }

                                MessageBox.Show("Game over! You lost!");

                                this.Close();
                            }

                        });
                    }

                if( foe.Health <= 0)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        if (foe.Img.Source != null)
                        foe.Img.Source = null;

                    mapCanvas.Children.Remove(foe.Img);
                    livingEnemies.Remove(foe);

                        if (!livingEnemies.Any())
                        {
                            if (Waves.WaveNumber >= GameInfo.maxWave)
                            {
                                foreach (Enemy en in livingEnemies)
                                {
                                    en.thr.Abort();
                                }

                                foreach (Tower tow in towerList)
                                {
                                    tow.thr.Abort();
                                }

                                MessageBox.Show("Game over! You win!");

                                this.Close();
                            }
                            else
                                waveButton.Visibility = Visibility.Visible;
                        }

                    GameInfo.Money += 1;
                    UpdateGameInfo();
                    foe.thr.Abort();
                    foe = null;
                    });
                }

                Action act = () => { Canvas.SetLeft(foe.Img, foe.X); Canvas.SetTop(foe.Img, foe.Y); };
                Dispatcher.BeginInvoke(act);

                Thread.Sleep(100);                
            }
        }

        private void TowerFiring( Tower tow ) //Prevents towers from shooting every enemy at once
        {
            while (true)
            {
                Thread.Sleep(tow.FireSpeed);
                tow.Fired = false;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (Enemy en in livingEnemies)
            {
                en.thr.Abort();
            }

            foreach (Tower tow in towerList)
            {
                tow.thr.Abort();
            }
        }
    }
}
