//-----------------------------------------------------------------------
// <copyright file="Difficulty.xaml.cs" company="Group 2">
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
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for Difficulty.xaml
    /// </summary>
    public partial class Difficulty : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Difficulty"/> class.
        /// </summary>
        public Difficulty()
        {
           this.InitializeComponent();
        }

        /// <summary>
        /// EASY button Clicked
        /// </summary>
        /// <param name="sender">Easy Button</param>
        /// <param name="e">button click event</param>
        private void EasyButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newGame = new MainWindow(700);
            this.Visibility = Visibility.Collapsed;
            newGame.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Medium Button Clicked
        /// </summary>
        /// <param name="sender">Medium Button</param>
        /// <param name="e">Button Click Event</param>
        private void MediumButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newGame = new MainWindow(500);
            this.Visibility = Visibility.Collapsed;
            newGame.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Hard Button Clicked
        /// </summary>
        /// <param name="sender">Hard Button</param>
        /// <param name="e">Hard Button Click</param>
        private void HardButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newGame = new MainWindow(200);
            this.Visibility = Visibility.Collapsed;
            newGame.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Left mouse button click for window movement
        /// </summary>
        /// <param name="sender">button click for window movement</param>
        /// <param name="e">mouse click event</param>
        private void Start_Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        /// <summary>
        /// Back button Click 
        /// </summary>
        /// <param name="sender">going back</param>
        /// <param name="e">mouse click event</param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            StartScreen start = new StartScreen();
            start.ShowDialog();
            this.Close();
        }
    }
}
