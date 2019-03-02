//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="Group 2">
//     All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

namespace Tetris.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Player
    {
        /// <summary>
        /// Control X position.
        /// </summary>
        public int controlX;

        /// <summary>
        /// Control Y position.
        /// </summary>
        public int controlY;

        /// <summary>
        /// 1X
        /// </summary>
        public int firstX;

        /// <summary>
        /// 1Y
        /// </summary>
        public int FirstY;

        /// <summary>
        /// 2X
        /// </summary>
        public int secondX;

        /// <summary>
        /// 2Y
        /// </summary>
        public int secondY;

        /// <summary>
        /// 3X
        /// </summary>
        public int thirdX;

        /// <summary>
        /// 3Y
        /// </summary>
        public int thirdY;

        /// <summary>
        /// Chekcs if there is a player on the map.
        /// </summary>
        public bool isActive;

        /// <summary>
        /// Checks if there is an empty space below.
        /// </summary>
        public int typeBelow;

        /// <summary>
        /// Checks if there is an empty space to the left.
        /// </summary>
        public int typeLeft;

        /// <summary>
        /// Checks if there is an empty space to the right.
        /// </summary>
        public int typeRight;
    }
}
