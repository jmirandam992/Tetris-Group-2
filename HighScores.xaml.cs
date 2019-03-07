//-----------------------------------------------------------------------
// <copyright file="HighScores.xaml.cs" company="Group 2">
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
    using Tetris;

    /// <summary>
    /// Interaction logic for HighScores.xaml
    /// </summary>
    public partial class HighScores : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HighScores"/> class.
        /// </summary>
        public HighScores()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// backButton_Click method
        /// </summary>
        /// <param name="sender">Back button click</param>
        /// <param name="e">Event Arguments</param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // StartScreen.GetWindow();
            this.Hide();
        }

        /// <summary>
        /// To move the window around.
        /// </summary>
        /// <param name="sender">Move the window</param>
        /// <param name="e">Event Arguments</param>
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
    }
    }
}
