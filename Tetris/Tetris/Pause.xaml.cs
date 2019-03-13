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
        public Window mainForm;

        public Pause(Window Mainform)
        {
            this.InitializeComponent();
            this.mainForm = Mainform;
        }

        /// <summary>
        /// Close button.
        /// </summary>
        /// <param name="sender">Click management</param>
        /// <param name="e">Event management</param>
        private void BtnResume1Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.mainForm.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Resets the game button.
        /// </summary>
        /// <param name="sender">Click management</param>
        /// <param name="e">Event management</param>
        private void BtnResetClick(object sender, RoutedEventArgs e)
        {
            this.mainForm.Close();
            Difficulty NewGame = new Difficulty();
            this.Close();
            NewGame.ShowDialog();
        }

        /// <summary>
        /// Quits the game button.
        /// </summary>
        /// <param name="sender">Click management</param>
        /// <param name="e">Event management</param>
        private void BtnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            System.Windows.Application.Current.Shutdown();
        }

        /// <summary>
        /// To move the window around.
        /// </summary>
        /// <param name="sender">Click management</param>
        /// <param name="e">Event management</param>
        private void GrdPauseLayoutMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
