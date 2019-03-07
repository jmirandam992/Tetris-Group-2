//-----------------------------------------------------------------------
// <copyright file="About.xaml.cs" company="Group 2">
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
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        /// <summary>
        /// Header of the rules.
        /// </summary>
        private string head;

        /// <summary>
        /// Rules for the game.
        /// </summary>
        private string desc;

        /// <summary>
        /// Initializes a new instance of the <see cref="About"/> class.
        /// </summary>
        public About()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Back button click method
        /// </summary>
        /// <param name="sender">Close this Form</param>
        /// <param name="e">Event ArgumentsS</param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// To move the window around.
        /// </summary>
        /// <param name="sender">Allow form to be moveable</param>
        /// <param name="e">Event Arguments</param>
        private void About_Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
