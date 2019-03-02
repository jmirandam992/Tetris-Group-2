//-----------------------------------------------------------------------
// <copyright file="Pause.xaml.cs" company="Group 2">
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
    /// Interaction logic for Pause.xaml
    /// </summary>
    public partial class Pause : Window
    {
        /// <summary>
        /// Users score
        /// </summary>
        public int Score;

        /// <summary>
        /// Difficulty.
        /// </summary>
        public int Level;

        /// <summary>
        /// Time the game has been active.
        /// </summary>
        public double Time;

        /// <summary>
        /// How many lines removed.
        /// </summary>
        public int Lines;

        /// <summary>
        /// To move the window around.
        /// </summary>
        public Pause()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Close button.
        /// </summary>
        private void btnResume1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        /// <summary>
        /// Resets the game button.
        /// </summary>
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Quits the game button.
        /// </summary>
        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            System.Windows.Application.Current.Shutdown();
        }

        /// <summary>
        /// To move the window around.
        /// </summary>
        private void grdPauseLayout_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
