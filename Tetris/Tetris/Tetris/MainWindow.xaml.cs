//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Group 2">
//     All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

namespace Tetris
{
    using Objects;
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
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Windows.Threading;
    using Tetris;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Variables used.
        /// </summary>
        public Tile[,] grid = new Tile[10, 20];
        Player player = new Player();
        Input playerControl = new Input();
        Random rdm = new Random();
        private int newPartCnt = 0;
        private string[] next = { "Sprites\\next1.png", "Sprites\\next2.png", "Sprites\\next3.png", "Sprites\\next4.png", "Sprites\\next5.png", "Sprites\\next6.png", "Sprites\\next7.png" };

        // Stats:
        public int nextPart;
        public int lineCnt = 0;
        public int speed = 0;
        public int score = 0;

        /// <summary>
        /// Refresher to simulate gravity.
        /// </summary>
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (!(grid[3, 0].type != 0 || grid[4, 0].type != 0 || grid[5, 0].type != 0 || grid[3, 1].type != 0 ||
                  grid[4, 1].type != 0 || grid[5, 1].type != 0))
            {
                if (player.isActive == true)
                {
                    playerControl.Bounds(2, player, grid, map);
                }
                else
                {
                    if (newPartCnt == 0)
                    {
                        List<int> lines = playerControl.LineCheck(grid, map);
                        lineCnt += lines.Count;
                        if (lines.Count < 3)
                        {
                            score += (lines.Count * 100);
                        }

                        if (lines.Count == 3)
                        {
                            score += 400;
                        }

                        if (lines.Count == 4)
                        {
                            score += 800;
                        }

                        lblLinesOutput.Content = lineCnt.ToString();
                        lblScoreOutput.Content = score.ToString();
                    }

                    if (newPartCnt == 1)
                    {
                        player.randomPlayer(nextPart);
                        playerControl.generate(player, grid, map);
                        nextPart = rdm.Next(7);
                        imgNextPiece.Source = new BitmapImage(new Uri(next[nextPart], UriKind.Relative));
                    }

                    newPartCnt++;
                    if (newPartCnt == 2)
                    {
                        newPartCnt = 0;
                    }
                }
            }
            else
            {
                if (player.isActive == true)
                {
                    playerControl.Bounds(2, player, grid, map);
                }
            }
        }

        /// <summary>
        /// Change the img of a tile.
        /// </summary>
        public void imgChange(int x, int y)
        {
            Image im = new Image();
            im.Source = new BitmapImage(new Uri(grid[x, y].tiles[grid[x, y].type], UriKind.Relative));
            im.SetValue(Grid.ColumnProperty, x);
            im.SetValue(Grid.RowProperty, y);

            map.Children.Add(im);
        }

        /// <summary>
        /// Loads the main window and the gameboard
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

            // Load the refresher
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            int nRows = grid.GetLength(1);
            int nCols = grid.GetLength(0);

            // Creates cells on grid
            for (int i = 0; i < nCols; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                map.ColumnDefinitions.Add(col);
            }

            for (int i = 0; i < nRows; i++)
            {
                RowDefinition row = new RowDefinition();
                map.RowDefinitions.Add(row);
            }

            // Fills the array objects with values
            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    grid[r, c] = new Tile();
                    grid[r, c].type = 0;
                    grid[r, c].xPos = r;
                    grid[r, c].yPos = c;
                    imgChange(r, c);
                }
            }
            nextPart = rdm.Next(7);
            player.randomPlayer(nextPart);
            playerControl.generate(player, grid, map);
            nextPart = rdm.Next(7);
            imgNextPiece.Source = new BitmapImage(new Uri(next[nextPart], UriKind.Relative));
        }

        /// <summary>
        /// quit button click method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            // don't forget to prompt to save before closing 
        }

        /// <summary>
        /// Down key press code.
        /// </summary>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            

            /// <summary>
            /// Up key press code.
            /// </summary>
            if (e.Key == Key.Up)
            {
                playerControl.Bounds(0, player, grid, map);
            }

            /// <summary>
            /// Right key press code.
            /// </summary>
            if (e.Key == Key.Right)
            {
                playerControl.Bounds(1, player, grid, map);
            }

            /// <summary>
            /// Down key press code.
            /// </summary>
            if (e.Key == Key.Down)
            {
                playerControl.Bounds(2, player, grid, map);
            }

            /// <summary>
            /// Left key press code.
            /// </summary>
            if (e.Key == Key.Left)
            {
                playerControl.Bounds(3, player, grid, map);
            }
        }

        /// <summary>
        /// Pause the game.
        /// </summary>
        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            Pause pMenu = new Pause();
            this.Visibility = Visibility.Hidden;
            pMenu.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Move the window.
        /// </summary>
        private void rctSidePanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        /// <summary>
        /// Move the window.
        /// </summary>
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
