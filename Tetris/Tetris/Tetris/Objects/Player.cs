//-----------------------------------------------------------------------
// <copyright file="controlX.cs" company="Group 2">
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
        /// 3X
        /// </summary>
        public int fourthX;

        /// <summary>
        /// 3Y
        /// </summary>
        public int fourthY;

        /// <summary>
        /// Chekcs if there is a controlX on the map.
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


        public void square(int controlX, int controlY, int secondX, int secondY, int thirdX, int thirdY, int fourthX, int fourthY)
        {
            this.controlX = 4;
            this.controlY = 0;
        
            this.secondX = 5;
            this.secondY = 0;

            this.thirdX = 4;
            this.thirdY = 1;

            this.fourthX = 5;
            this.fourthY = 1;
        }
        public void iPiece(int controlX, int controlY, int secondX, int secondY, int thirdX, int thirdY, int fourthX, int fourthY)
        {
 // I piece
        this.controlX = 3;
       this.controlY = 0;

      this.secondX = 4;
       this.secondY = 0;

      this.thirdX = 5;
      this.thirdY = 0;
            
       this.fourthX = 6;
       this.fourthY = 0;
        }
        public void jPiece(int controlX, int controlY, int secondX, int secondY, int thirdX, int thirdY, int fourthX, int fourthY)
        {
            // I piece
            this.controlX = 3;
            this.controlY = 0;

            this.secondX = 4;
            this.secondY = 0;

            this.thirdX = 5;
            this.thirdY = 0;

            this.fourthX = 5;
            this.fourthY = 1;
        }
        public void lPiece(int controlX, int controlY, int secondX, int secondY, int thirdX, int thirdY, int fourthX, int fourthY)
        {
            // I piece
            this.controlX = 3;
            this.controlY = 0;

            this.secondX = 3;
            this.secondY = 1;

            this.thirdX = 4;
            this.thirdY = 0;

            this.fourthX = 5;
            this.fourthY = 0;
        }

        public void sPiece(int controlX, int controlY, int secondX, int secondY, int thirdX, int thirdY, int fourthX, int fourthY)
        {
            // I piece
            this.controlX = 3;
            this.controlY = 1;

            this.secondX = 4;
            this.secondY = 0;

            this.thirdX = 5;
            this.thirdY = 0;

            this.fourthX = 5;
            this.fourthY = 1;
        }
        public void tPiece(int controlX, int controlY, int secondX, int secondY, int thirdX, int thirdY, int fourthX, int fourthY)
        {
            // I piece
            this.controlX = 3;
            this.controlY = 0;

            this.secondX = 4;
            this.secondY = 0;

            this.thirdX = 5;
            this.thirdY = 0;

            this.fourthX = 4;
            this.fourthY = 1;
        }
        public void zPiece(int controlX, int controlY, int secondX, int secondY, int thirdX, int thirdY, int fourthX, int fourthY)
        {
            // I piece
            this.controlX = 3;
            this.controlY = 0;

            this.secondX = 4;
            this.secondY = 0;

            this.thirdX = 4;
            this.thirdY = 1;

            this.fourthX = 5;
            this.fourthY = 1;
        }
    }
}
