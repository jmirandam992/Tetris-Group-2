using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace Tetris
{
    public class Tile
    {
        public readonly string[] tiles = { "Sprites\\0.png", "Sprites\\1.png" };
        public int type;
        public int xPos;
        public int yPos;
        public readonly int width = 5;
        public readonly int height = 5;
    }
}
