//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Group 2">
//     All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using System.Media;

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
    using Objects;
    using Tetris;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Variables used.
        /// </summary>
        private Tile[,] grid = new Tile[10, 20];

        /// <summary>
        /// Create a New Player
        /// </summary>
        private Player player = new Player();

        /// <summary>
        /// New Input for Player Control
        /// </summary>
        private Input playerControl = new Input();

        /// <summary>
        /// New random piece
        /// </summary>
        private Random rdm = new Random();

        /// <summary>
        /// Create new Part Count
        /// </summary>
        private int newPartCnt = 0;

        /// <summary>
        /// Create Sprite Array
        /// </summary>
        private string[] next =
        {
            "Sprites\\next1.png", "Sprites\\next2.png", "Sprites\\next3.png", "Sprites\\next4.png",
            "Sprites\\next5.png", "Sprites\\next6.png", "Sprites\\next7.png"
        };

        /// <summary>
        /// Dispatcher timer for game tick
        /// </summary>
        private DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        /// <summary>
        /// Initiate next piece
        /// </summary>
        private int nextPart;

        /// <summary>
        /// Initiate line count
        /// </summary>
        private int lineCnt = 0;

        /// <summary>
        /// Initiate Speed
        /// </summary>
        private int speed = 0;

        /// <summary>
        /// initiate base score
        /// </summary>
        private int score = 0;

        /// <summary>
        /// initage level count
        /// </summary>
        private int levelCnt = 1;
        

        /// <summary>
        /// Refresher to simulate gravity.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">Event Argument</param>
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            // top collision detection
            if (!(this.grid[3, 0].type != 0 || this.grid[4, 0].type != 0 || this.grid[5, 0].type != 0 ||
                  this.grid[3, 1].type != 0 ||
                  this.grid[4, 1].type != 0 || this.grid[5, 1].type != 0))
            {
                if (this.player.isActive == true)
                {
                    this.playerControl.Bounds(2, this.player, this.grid, this.map);
                }
                else
                {
                    if (this.newPartCnt == 0)
                    {
                        List<int> lines = this.playerControl.LineCheck(this.grid, this.map);
                        this.lineCnt += lines.Count;
                        if (lines.Count < 3)
                        {
                            this.score += (lines.Count * 100);
                        }

                        if (lines.Count == 3)
                        {
                            this.score += 400;
                        }

                        if (lines.Count == 4)
                        {
                            this.score += 800;
                        }

                        lblLinesOutput.Content = this.lineCnt.ToString();
                        lblScoreOutput.Content = this.score.ToString();
                    }

                    if (this.newPartCnt == 1)
                    {
                        player.randomPlayer(nextPart);
                        playerControl.generate(player, grid, this.map);
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
                //put end game code here
                if (player.isActive == true)
                {
                    playerControl.Bounds(2, player, grid, this.map);
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
            im.SetValue(System.Windows.Controls.Grid.ColumnProperty, x);
            im.SetValue(System.Windows.Controls.Grid.RowProperty, y);

            map.Children.Add(im);
        }

        /// <summary>
        /// use this to set the difficulty for the game 
        /// </summary>
        /// <param name="milliseconds"></param>
        public MainWindow(int milliseconds)
        {

            
            InitializeComponent();
            InitiateGame(milliseconds);
            initializeSound();


        }

        /// <summary>
        /// initalized the music for the game
        /// </summary>
        private void initializeSound()
        {
            
        
            System.IO.Stream str = Properties.Resources.Tetris1;
            System.Media.SoundPlayer music = new SoundPlayer(str);
            music.Play();
            bool soundFinished = true;

            if (soundFinished)
            {
                soundFinished = false;
                Task.Factory.StartNew(() =>{ music.PlaySync(); soundFinished = true;});
            }
        }

    private void InitiateGame(int milliseconds)
        {
            lblLevelOutput.Content = this.levelCnt;
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, milliseconds);
            dispatcherTimer.Start();

            int nRows = grid.GetLength(1);
            int nCols = grid.GetLength(0);

            // Creates cells on grid
            for (int i = 0; i < nCols; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                this.map.ColumnDefinitions.Add(col);
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
            playerControl.generate(player, grid, this.map);
            nextPart = rdm.Next(7);
            imgNextPiece.Source = new BitmapImage(new Uri(next[nextPart], UriKind.Relative));
            levelUp();
        }

        private void pauseGame()
        {
            dispatcherTimer.Stop();
        }

        private void levelUp()
        {
            if (this.score == 10000)
            {
                this.levelCnt = levelCnt + 1;
                lblLevelOutput.Content = this.levelCnt.ToString();
            }
           
        }

        private void resumeGame()
        {
            InitializeComponent();
            Keyboard.Focus(this);
            dispatcherTimer.Start();
            playerControl.generate(player, grid, this.map);
            nextPart = rdm.Next(7);
            imgNextPiece.Source = new BitmapImage(new Uri(next[nextPart], UriKind.Relative));
        }

        /// <summary>
        /// Down key press code.
        /// </summary>
        protected override void OnKeyDown(KeyEventArgs e)
        {


            /// <summary>
            /// Up key press code.
            /// </summary>

            if (player.isActive == true)
            {
                if (e.Key == Key.Up)
                {
                    playerControl.Bounds(0, player, grid, this.map);
                }
            }

            /// <summary>
            /// Right key press code.
            /// </summary>

            if (player.isActive == true)
            {
                if (e.Key == Key.Right)
                {
                    playerControl.Bounds(1, player, grid, this.map);
                }
            }

            /// <summary>
            /// Down key press code.
            /// </summary>
            if (player.isActive == true)
            {
                if (e.Key == Key.Down)
                {
                    playerControl.Bounds(2, player, grid, this.map);
                }
            }

            /// <summary>
            /// Left key press code.
            /// </summary>
            if (player.isActive == true)
            {
                if (e.Key == Key.Left)
                {
                    playerControl.Bounds(3, player, grid, this.map);
                }
            }
        }

        /// <summary>
        /// Pause the game.
        /// </summary>
        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            pauseGame();
            Pause pMenu = new Pause(this);
            this.Visibility = Visibility.Hidden;
            pMenu.ShowDialog();
            resumeGame();
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
