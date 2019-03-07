//-----------------------------------------------------------------------
// <copyright file="Tile.cs" company="Group 2">
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
    using System.Windows.Documents;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Controls;

    /// <summary>
    /// The tile class that loads into grid.
    /// </summary>
    public class Tile
    {
        /// <summary>
        /// Imgs used.
        /// </summary>
        public readonly string[] tiles = { "Sprites\\0.png", "Sprites\\1.png", "Sprites\\2.png", "Sprites\\3.png", "Sprites\\4.png", "Sprites\\5.png", "Sprites\\6.png", "Sprites\\7.png" };

        /// <summary>
        /// What img is used.
        /// </summary>
        public int type;

        /// <summary>
        /// Row.
        /// </summary>
        public int xPos;

        /// <summary>
        /// Col.
        /// </summary>
        public int yPos;

    }
}
