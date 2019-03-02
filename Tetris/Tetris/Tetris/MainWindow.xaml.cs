//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Group 2">
//     All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

namespace Tetris
{
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
    using Tron;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Refresher to simulate gravity.
        /// </summary>
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // Refresher
        }

        /// <summary>
        /// Change the img of a tile.
        /// </summary>
        void imgChange(int x, int y)
        {
            Image im = new Image();
            im.Source = new BitmapImage(new Uri(grid[x, y].tiles[grid[x, y].type], UriKind.Relative));
            im.SetValue(Grid.ColumnProperty, x);
            im.SetValue(Grid.RowProperty, y);

            map.Children.Add(im);
        }

        /// <summary>
        /// Variables used.
        /// </summary>
        Tile[,] grid = new Tile[10, 20];
        Tile player = new Tile();
        Tile player2 = new Tile();
        Tile player3 = new Tile();
        Tile player4 = new Tile();
        Tile player5 = new Tile();
        Tile player6 = new Tile();
        Tile player7 = new Tile();

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

            //All the player positions
            player.xPos = 3;
            player.yPos = 3;

            player2.xPos = 5;
            player2.yPos = 3;

            player3.xPos = 2;
            player3.yPos = 5;

            player4.xPos = 3;
            player4.yPos = 6;

            player5.xPos = 4;
            player5.yPos = 6;

            player6.xPos = 5;
            player6.yPos = 6;

            player7.xPos = 6;
            player7.yPos = 5;

            // Var
            int x = player.xPos;
            int y = player.yPos;
            // Change img
            grid[x, y].type = 1;
            imgChange(x, y);

            x = player2.xPos;
            y = player2.yPos;
            // Change img
            grid[x, y].type = 1;
            imgChange(x, y);

            x = player3.xPos;
            y = player3.yPos;
            // Change img
            grid[x, y].type = 1;
            imgChange(x, y);

            x = player4.xPos;
            y = player4.yPos;
            // Change img
            grid[x, y].type = 1;
            imgChange(x, y);

            x = player5.xPos;
            y = player5.yPos;
            // Change img
            grid[x, y].type = 1;
            imgChange(x, y);

            x = player6.xPos;
            y = player6.yPos;
            // Change img
            grid[x, y].type = 1;
            imgChange(x, y);

            x = player7.xPos;
            y = player7.yPos;
            // Change img
            grid[x, y].type = 1;
            imgChange(x, y);
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
            if (e.Key == Key.Down)
            {
                if (player.yPos < 16)
                {
                    // Player1
                    int beforeY = player.yPos;
                    player.yPos = beforeY + 1;
                    int x = player.xPos;
                    int y = player.yPos;

                    grid[x, beforeY].type = 0;
                    imgChange(x, beforeY);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player2
                    beforeY = player2.yPos;
                    player2.yPos = beforeY + 1;
                    x = player2.xPos;
                    y = player2.yPos;

                    grid[x, beforeY].type = 0;
                    imgChange(x, beforeY);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player3
                    beforeY = player3.yPos;
                    player3.yPos = beforeY + 1;
                    x = player3.xPos;
                    y = player3.yPos;

                    grid[x, beforeY].type = 0;
                    imgChange(x, beforeY);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player4
                    beforeY = player4.yPos;
                    player4.yPos = beforeY + 1;
                    x = player4.xPos;
                    y = player4.yPos;

                    grid[x, beforeY].type = 0;
                    imgChange(x, beforeY);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player5
                    beforeY = player5.yPos;
                    player5.yPos = beforeY + 1;
                    x = player5.xPos;
                    y = player5.yPos;

                    grid[x, beforeY].type = 0;
                    imgChange(x, beforeY);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player3
                    beforeY = player6.yPos;
                    player6.yPos = beforeY + 1;
                    x = player6.xPos;
                    y = player6.yPos;

                    grid[x, beforeY].type = 0;
                    imgChange(x, beforeY);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player3
                    beforeY = player7.yPos;
                    player7.yPos = beforeY + 1;
                    x = player7.xPos;
                    y = player7.yPos;

                    grid[x, beforeY].type = 0;
                    imgChange(x, beforeY);
                    grid[x, y].type = 1;
                    imgChange(x, y);
                }
            }

            /// <summary>
            /// Up key press code.
            /// </summary>
            if (e.Key == Key.Up)
            {
                if (player.yPos > 0)
                {
                    // Player1
                    int beforeY = player.yPos;
                    player.yPos = beforeY - 1;
                    int x = player.xPos;
                    int y = player.yPos;

                    grid[x, beforeY].type = 0;
                    imgChange(x, beforeY);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player2
                    beforeY = player2.yPos;
                    player2.yPos = beforeY - 1;
                    x = player2.xPos;
                    y = player2.yPos;

                    grid[x, beforeY].type = 0;
                    imgChange(x, beforeY);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player3
                    beforeY = player3.yPos;
                    player3.yPos = beforeY - 1;
                    x = player3.xPos;
                    y = player3.yPos;

                    grid[x, beforeY].type = 0;
                    imgChange(x, beforeY);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player4
                    beforeY = player4.yPos;
                    player4.yPos = beforeY - 1;
                    x = player4.xPos;
                    y = player4.yPos;

                    grid[x, beforeY].type = 0;
                    imgChange(x, beforeY);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player5
                    beforeY = player5.yPos;
                    player5.yPos = beforeY - 1;
                    x = player5.xPos;
                    y = player5.yPos;

                    grid[x, beforeY].type = 0;
                    imgChange(x, beforeY);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player3
                    beforeY = player6.yPos;
                    player6.yPos = beforeY - 1;
                    x = player6.xPos;
                    y = player6.yPos;

                    grid[x, beforeY].type = 0;
                    imgChange(x, beforeY);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player3
                    beforeY = player7.yPos;
                    player7.yPos = beforeY - 1;
                    x = player7.xPos;
                    y = player7.yPos;

                    grid[x, beforeY].type = 0;
                    imgChange(x, beforeY);
                    grid[x, y].type = 1;
                    imgChange(x, y);
                }
            }

            /// <summary>
            /// Left key press code.
            /// </summary>
            if (e.Key == Key.Left)
            {
                if (player.xPos > 1)
                {
                    // Player1
                    int beforeX = player.xPos;
                    player.xPos = beforeX - 1;
                    int x = player.xPos;
                    int y = player.yPos;

                    grid[beforeX, y].type = 0;
                    imgChange(beforeX, y);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player2
                    beforeX = player2.xPos;
                    player2.xPos = beforeX - 1;
                    x = player2.xPos;
                    y = player2.yPos;

                    grid[beforeX, y].type = 0;
                    imgChange(beforeX, y);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player3
                    beforeX = player3.xPos;
                    player3.xPos = beforeX - 1;
                    x = player3.xPos;
                    y = player3.yPos;

                    grid[beforeX, y].type = 0;
                    imgChange(beforeX, y);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player4
                    beforeX = player4.xPos;
                    player4.xPos = beforeX - 1;
                    x = player4.xPos;
                    y = player4.yPos;

                    grid[beforeX, y].type = 0;
                    imgChange(beforeX, y);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player5
                    beforeX = player5.xPos;
                    player5.xPos = beforeX - 1;
                    x = player5.xPos;
                    y = player5.yPos;

                    grid[beforeX, y].type = 0;
                    imgChange(beforeX, y);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player3
                    beforeX = player6.xPos;
                    player6.xPos = beforeX - 1;
                    x = player6.xPos;
                    y = player6.yPos;

                    grid[beforeX, y].type = 0;
                    imgChange(beforeX, y);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player3
                    beforeX = player7.xPos;
                    player7.xPos = beforeX - 1;
                    x = player7.xPos;
                    y = player7.yPos;

                    grid[beforeX, y].type = 0;
                    imgChange(beforeX, y);
                    grid[x, y].type = 1;
                    imgChange(x, y);
                }
            }

            /// <summary>
            /// Right key press code.
            /// </summary>
            if (e.Key == Key.Right)
            {
                if (player.xPos < 6)
                {
                    // Player1
                    int beforeX = player.xPos;
                    player.xPos = beforeX + 1;
                    int x = player.xPos;
                    int y = player.yPos;

                    grid[beforeX, y].type = 0;
                    imgChange(beforeX, y);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player2
                    beforeX = player2.xPos;
                    player2.xPos = beforeX + 1;
                    x = player2.xPos;
                    y = player2.yPos;

                    grid[beforeX, y].type = 0;
                    imgChange(beforeX, y);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player3
                    beforeX = player3.xPos;
                    player3.xPos = beforeX + 1;
                    x = player3.xPos;
                    y = player3.yPos;

                    grid[beforeX, y].type = 0;
                    imgChange(beforeX, y);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player4
                    beforeX = player4.xPos;
                    player4.xPos = beforeX + 1;
                    x = player4.xPos;
                    y = player4.yPos;

                    grid[beforeX, y].type = 0;
                    imgChange(beforeX, y);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player5
                    beforeX = player5.xPos;
                    player5.xPos = beforeX + 1;
                    x = player5.xPos;
                    y = player5.yPos;

                    grid[beforeX, y].type = 0;
                    imgChange(beforeX, y);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player6
                    beforeX = player6.xPos;
                    player6.xPos = beforeX + 1;
                    x = player6.xPos;
                    y = player6.yPos;

                    grid[beforeX, y].type = 0;
                    imgChange(beforeX, y);
                    grid[x, y].type = 1;
                    imgChange(x, y);

                    // Player7
                    beforeX = player7.xPos;
                    player7.xPos = beforeX + 1;
                    x = player7.xPos;
                    y = player7.yPos;

                    grid[beforeX, y].type = 0;
                    imgChange(beforeX, y);
                    grid[x, y].type = 1;
                    imgChange(x, y);
                }
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
