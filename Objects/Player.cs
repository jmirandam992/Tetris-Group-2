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

    public class Player
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
        public int firstY;

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

        /// <summary>
        /// Checks which way it's fliped
        /// </summary>
        public int compass;
        /// <summary>
        /// Checks which way it's fliped
        /// </summary>
        public int type;
        public void Long()
        {
            this.type = 1;
            this.compass = 0;
            this.isActive = false;
            
            this.controlX = 3;
            this.controlY = 0;

            this.firstX = 4;
            this.firstY = 0;

            this.secondX = 5;
            this.secondY = 0;

            this.thirdX = 6;
            this.thirdY = 0;
        }
        public void square()
        {
            this.type = 2;
            this.compass = 0;
            this.isActive = false;

            this.controlX = 3;
            this.controlY = 1;

            this.firstX = 3;
            this.firstY = 0;

            this.secondX = 4;
            this.secondY = 1;

            this.thirdX = 4;
            this.thirdY = 0;
        }
        public void Pyramid()
        {
            this.type = 3;
            this.compass = 0;
            this.isActive = false;

            this.controlX = 3;
            this.controlY = 0;

            this.firstX = 4;
            this.firstY = 1;

            this.secondX = 4;
            this.secondY = 0;

            this.thirdX = 5;
            this.thirdY = 0;
        }
        public void smLeft()
        {
            this.type = 4;
            this.compass = 0;
            this.isActive = false;

            this.controlX = 3;
            this.controlY = 1;

            this.firstX = 4;
            this.firstY = 1;

            this.secondX = 4;
            this.secondY = 0;

            this.thirdX = 5;
            this.thirdY = 0;
        }
        public void smRight()
        {
            this.type = 5;
            this.compass = 0;
            this.isActive = false;

            this.controlX = 3;
            this.controlY = 0;

            this.firstX = 4;
            this.firstY = 1;

            this.secondX = 4;
            this.secondY = 0;

            this.thirdX = 5;
            this.thirdY = 1;
        }
        public void Left()
        {
            this.type = 6;
            this.compass = 0;
            this.isActive = false;

            this.controlX = 3;
            this.controlY = 1;

            this.firstX = 3;
            this.firstY = 0;

            this.secondX = 4;
            this.secondY = 0;

            this.thirdX = 5;
            this.thirdY = 0;
        }
        public void Right()
        {
            this.type = 7;
            this.compass = 0;
            this.isActive = false;

            this.controlX = 3;
            this.controlY = 0;

            this.firstX = 4;
            this.firstY = 0;

            this.secondX = 5;
            this.secondY = 1;

            this.thirdX = 5;
            this.thirdY = 0;
        }

        public void randomPlayer(int part)
        {
            if (part == 0)
            {
                this.Long();
            }
            if (part == 1)
            {
                this.square();
            }
            if (part == 2)
            {
                this.Pyramid();
            }
            if (part == 3)
            {
                this.smLeft();
            }
            if (part == 4)
            {
                this.smRight();
            }
            if (part == 5)
            {
                this.Left();
            }
            if (part == 6)
            {
                this.Right();
            }
        }

        public void Update(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            this.controlX = x1;
            this.controlY = y1;
            this.firstX = x2;
            this.firstY = y2;
            this.secondX = x3;
            this.secondY = y3;
            this.thirdX = x4;
            this.thirdY = y4;
        }

    
    }
}
