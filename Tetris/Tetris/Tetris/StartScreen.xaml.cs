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

namespace Tron
{
    /// <summary>
    /// Interaction logic for StartScreen.xaml
    /// </summary>
    public partial class StartScreen : Window
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newGame = new MainWindow();
            this.Visibility = Visibility.Collapsed;
            newGame.ShowDialog();
            this.Visibility = Visibility.Visible;

        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            this.Visibility = Visibility.Collapsed;
            about.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void scoresButton_Click(object sender, RoutedEventArgs e)
        {
            HighScores highScores = new HighScores();
            this.Visibility = Visibility.Collapsed;
            highScores.ShowDialog();
            this.Visibility = Visibility.Visible;
        }
    }
}
