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
    using System.Media;
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
        /// initiate base score
        /// </summary>
        private int score = 9900;

        /// <summary>
        /// initiate level count
        /// </summary>
        private int levelCnt = 1;

        /// <summary>
        /// score changed variable true if score has changed false if it hasn't
        /// </summary>
        private bool scoreChanged = false;

        /// <summary>
        /// generic incrementer for the level updater 
        /// </summary>
        private int i = 1;

        /// <summary>
        /// milliseconds time variable
        /// </summary>
        private int milliseconds = 0;

        /// <summary>
        /// Change the image of a tile.
        /// </summary>
        /// <param name="x">x coordinates</param>
        /// <param name="y">y coordinates</param>
        public void ImgChange(int x, int y)
        {
            Image im = new Image();
            im.Source = new BitmapImage(new Uri(this.grid[x, y].Tiles[this.grid[x, y].type], UriKind.Relative));
            im.SetValue(System.Windows.Controls.Grid.ColumnProperty, x);
            im.SetValue(System.Windows.Controls.Grid.RowProperty, y);

            map.Children.Add(im);
        }

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
                            this.score += lines.Count * 100 * this.i;
                         
                           this.LevelUp();
                            this.scoreChanged = true;
                        }

                        if (lines.Count == 3)
                        {
                            this.score += 400 * this.i;
                           
                            this.LevelUp();
                            this.scoreChanged = true;
                        }

                        if (lines.Count == 4)
                        {
                            this.score += 800 * this.i;
                            this.LevelUp();
                            this.scoreChanged = true;
                        }

                        lblLinesOutput.Content = this.lineCnt.ToString();
                        lblScoreOutput.Content = this.score.ToString();
                        }

                if (this.newPartCnt == 1)
                    {
                        this.player.randomPlayer(this.nextPart);
                        this.playerControl.generate(this.player, this.grid, this.map);
                        this.nextPart = this.rdm.Next(7);
                        imgNextPiece.Source = new BitmapImage(new Uri(this.next[this.nextPart], UriKind.Relative));
                    }

                    this.newPartCnt++;
                    if (this.newPartCnt == 2)
                    {
                        this.newPartCnt = 0;
                    }
                }
            }
            else
            {
                // Put end game code here
                if (this.player.isActive == true)
                {
                    this.playerControl.Bounds(2, this.player, this.grid, this.map);
                }
            }
        }

        /// <summary>
        /// use this to set the difficulty for the game 
        /// </summary>
        /// <param name="milliseconds">milliseconds for timer</param>
        public MainWindow(int milliseconds)
        {
            this.InitializeComponent();
            this.InitiateGame(milliseconds);
            this.InitializeSound();
        }

        /// <summary>
        /// initalized the music for the game
        /// </summary>
        private void InitializeSound()
        {
            System.IO.Stream str = Properties.Resources.Tetris1;
            System.Media.SoundPlayer music = new SoundPlayer(str);
            music.Play();
            bool soundFinished = true;

            if (soundFinished)
            {
                soundFinished = false;
                Task.Factory.StartNew(()=>{music.PlaySync(); soundFinished = true;});
            }
        }

        /// <summary>
        /// set time
        /// </summary>
        /// <param name="milliseconds">setting milliseconds for interval timer</param>
        private void SetTime(int milliseconds)
        {
            this.dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, milliseconds);
        }

        /// <summary>
        /// Initiate the main game
        /// </summary>
        /// <param name="milliseconds">number of seconds for dispatcher</param>
        private void InitiateGame(int milliseconds)
        {
            lblLevelOutput.Content = this.levelCnt;
            this.dispatcherTimer.Tick += this.DispatcherTimer_Tick;
            this.SetTime(milliseconds);
            this.dispatcherTimer.Start();

            int nRows = this.grid.GetLength(1);
            int nCols = this.grid.GetLength(0);

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
            for (int r = 0; r < this.grid.GetLength(0); r++)
            {
                for (int c = 0; c < this.grid.GetLength(1); c++)
                {
                    this.grid[r, c] = new Tile();
                    this.grid[r, c].type = 0;
                    this.grid[r, c].xPos = r;
                    this.grid[r, c].yPos = c;
                    this.ImgChange(r, c);
                }
            }

            this.nextPart = this.rdm.Next(7);
            this.player.randomPlayer(this.nextPart);
            this.playerControl.generate(this.player, this.grid, this.map);
            this.nextPart = this.rdm.Next(7);
            this.imgNextPiece.Source = new BitmapImage(new Uri(this.next[this.nextPart], UriKind.Relative));
           }

        /// <summary>
        /// Pauses the Game
        /// </summary>
        private void PauseGame()
        {
            this.dispatcherTimer.Stop();
        }

        /// <summary>
        /// Levels up and increases speed
        /// </summary>
        private void LevelUp()
        {
           if (this.scoreChanged == true && this.score == this.i * 10000)
                {
                    this.levelCnt = this.levelCnt + 1;
                    lblLevelOutput.Content = this.levelCnt.ToString();
                this.i++;
                    double update = this.milliseconds * 1.5;
                    this.milliseconds = Convert.ToInt32(update);
                this.SetTime(this.milliseconds);
                }

            this.scoreChanged = false;
  }

        private void resumeGame()
        {
            this.InitializeComponent();
            Keyboard.Focus(this);
            this.dispatcherTimer.Start();
            this.playerControl.generate(this.player, this.grid, this.map);
            this.nextPart = this.rdm.Next(7);
            this.imgNextPiece.Source = new BitmapImage(new Uri(this.next[this.nextPart], UriKind.Relative));
        }

        /// <summary>
        /// Down key press code.
        /// </summary>
        /// <param name="e">Event Argument</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
           
            // Up key press code.
            if (this.player.isActive == true)
            {
                if (e.Key == Key.Up)
                {
                    this.playerControl.Bounds(0, this.player, this.grid, this.map);
                }
            }

                        // Right key press code.
            if (this.player.isActive == true)
            {
                if (e.Key == Key.Right)
                {
                    this.playerControl.Bounds(1, this.player, this.grid, this.map);
                }
            }

       
            // Down key press code.
            if (this.player.isActive == true)
            {
                if (e.Key == Key.Down)
                {
                    this.playerControl.Bounds(2, this.player, this.grid, this.map);
                }
            }

            // Left key press code.
            if (this.player.isActive == true)
            {
                if (e.Key == Key.Left)
                {
                   this.playerControl.Bounds(3, this.player, this.grid, this.map);
                }
            }
        }

        // Pause the game.
        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            PauseGame();
            Pause pMenu = new Pause(this);
            this.Visibility = Visibility.Hidden;
            pMenu.ShowDialog();
            resumeGame();
        }

        // Move the window.
        private void rctSidePanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
        
        // Move the window.
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
