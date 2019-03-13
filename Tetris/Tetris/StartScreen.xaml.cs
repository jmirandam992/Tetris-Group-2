//-----------------------------------------------------------------------
// <copyright file="StartScreen.xaml.cs" company="CompanyName">
//     Company copyright tag.
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
    using System.Windows.Shapes;
    using Tetris;

    /// <summary>
    /// Interaction logic for StartScreen.xaml
    /// </summary>
    public partial class StartScreen : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StartScreen"/> class.
        /// </summary>
        public StartScreen()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initialization of the New Game Button
        /// </summary>
        /// <param name="sender">Click</param>
        /// <param name="e">Event</param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Difficulty select = new Difficulty();
            this.Visibility = Visibility.Collapsed;
            select.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// button to close the program
        /// </summary>
        /// <param name="sender">Click this.</param>
        /// <param name="e">Event this.</param>
        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            System.Windows.Application.Current.Shutdown();
        }

        /// <summary>
        /// about button action call
        /// </summary>
        /// <param name="sender">Click this.</param>
        /// <param name="e">Event this.</param>
        private void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            this.Visibility = Visibility.Collapsed;
            about.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Opens the Scores Window
        /// </summary>
        /// <param name="sender">Click this.</param>
        /// <param name="e">Event this.</param>
        private void scoresButton_Click(object sender, RoutedEventArgs e)
        {
            HighScores highScores = new HighScores();
            this.Visibility = Visibility.Collapsed;
            highScores.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Left mouse button click for window movement
        /// </summary>
        /// <param name="sender">Click this.</param>
        /// <param name="e">Event this.</param>
        private void Start_Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
