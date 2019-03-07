//-----------------------------------------------------------------------
// <copyright file="Input.cs" company="Group 2">
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
    using System.Windows.Input;
    using Tetris.Objects;
    using Tetris;

    /// <summary>
    /// All the key inputs.
    /// </summary>
    public class Input
    {
        /// <summary>
        /// Change the img of a tile.
        /// </summary>
        public void ImgChange(int x, int y, Tile[,] grid, Grid map)
        {
            Image im = new Image();
            im.Source = new BitmapImage(new Uri(grid[x, y].tiles[grid[x, y].type], UriKind.Relative));
            im.SetValue(Grid.ColumnProperty, x);
            im.SetValue(Grid.RowProperty, y);

            map.Children.Remove(im);
            map.Children.Add(im);
        }

        public void generate(Player player, Tile[,] grid, Grid map)
        {
            int inputX1 = player.controlX;
            int inputY1 = player.controlY;
            int inputX2 = player.firstX;
            int inputY2 = player.firstY;
            int inputX3 = player.secondX;
            int inputY3 = player.secondY;
            int inputX4 = player.thirdX;
            int inputY4 = player.thirdY;

            grid[inputX1, inputY1].type = player.type;
            ImgChange(inputX1, inputY1, grid, map);
            grid[inputX2, inputY2].type = player.type;
            ImgChange(inputX2, inputY2, grid, map);
            grid[inputX3, inputY3].type = player.type;
            ImgChange(inputX3, inputY3, grid, map);
            grid[inputX4, inputY4].type = player.type;
            ImgChange(inputX4, inputY4, grid, map);

            player.isActive = true;
        }

        public void Bounds(int key, Player player, Tile[,] grid, Grid map)
        {
            int rotation = player.compass;
            int type = player.type;
            int x = player.controlX;
            int y = player.controlY;
            int xx = player.firstX;
            int yy = player.firstY;
            int xxx = player.secondX;
            int yyy = player.secondY;
            int xxxx = player.thirdX;
            int yyyy = player.thirdY;

            if (key == 0)
            {
                if (y != 0 && yyyy != 0)
                {
                    if (rotation == 0)
                    {
                        if (player.type == 1)
                        {
                            if (y < 18 && grid[(x + 1), (y - 1)].type == 0 && grid[(x + 1), (y + 1)].type == 0 &&
                                grid[(x + 1), (y + 2)].type == 0)
                            {
                                grid[x, y].type = 0;
                                grid[xxx, yyy].type = 0;
                                grid[xxxx, yyyy].type = 0;
                                ImgChange(x, y, grid, map);
                                ImgChange(xxx, yyy, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                                x = x + 1;
                                y = y + 2;
                                yy = yy + 1;
                                xxx = xxx - 1;
                                xxxx = xxxx - 2;
                                yyyy = yyyy - 1;
                                player.Update(x, y, xx, yy, xxx, yyy, xxxx, yyyy);
                                player.compass = 1;
                                grid[x, y].type = player.type;
                                grid[xx, yy].type = player.type;
                                grid[xxxx, yyyy].type = player.type;
                                ImgChange(x, y, grid, map);
                                ImgChange(xx, yy, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                            }
                            else
                            {
                                // Do nothing
                            }
                        }
                        if (player.type == 3)
                        {
                            if (grid[(x + 1), (y - 1)].type == 0)
                            {
                                grid[xxxx, yyyy].type = 0;
                                ImgChange(xxxx, yyyy, grid, map);
                                xxxx = xxxx - 1;
                                yyyy = yyyy - 1;
                                player.Update(x, y, xx, yy, xxx, yyy, xxxx, yyyy);
                                player.compass = 1;
                                grid[xxxx, yyyy].type = player.type;
                                ImgChange(xxxx, yyyy, grid, map);
                            }
                            else
                            {
                                // Do nothing
                            }
                        }

                        if (player.type == 4)
                        {
                            if (x < 9 && grid[(x + 1), (y - 2)].type == 0 && grid[(xx + 1), yy].type == 0)
                            {
                                grid[x, y].type = 0;
                                grid[xx, yy].type = 0;
                                ImgChange(x, y, grid, map);
                                ImgChange(xx, yy, grid, map);
                                x = x + 1;
                                y = y - 2;
                                yy = yy - 1;
                                xxx = xxx + 1;
                                yyyy = yyyy + 1;
                                player.Update(x, y, xx, yy, xxx, yyy, xxxx, yyyy);
                                player.compass = 1;
                                grid[x, y].type = player.type;
                                grid[xxxx, yyyy].type = player.type;
                                ImgChange(x, y, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                            }
                            else
                            {
                                // Do nothing
                            }
                        }

                        if (player.type == 5)
                        {
                            if (x < 9 && grid[(x + 2), (y - 1)].type == 0 && grid[xxxx, (yyyy - 2)].type == 0)
                            {
                                grid[x, y].type = 0;
                                grid[xxxx, yyyy].type = 0;
                                ImgChange(x, y, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                                x = x + 1;
                                y = y + 1;
                                yy = yy - 1;
                                xxx = xxx + 1;
                                yyyy = yyyy - 2;
                                player.Update(x, y, xx, yy, xxx, yyy, xxxx, yyyy);
                                player.compass = 1;
                                grid[xxx, yyy].type = player.type;
                                grid[xxxx, yyyy].type = player.type;
                                ImgChange(xxx, yyy, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                            }
                            else
                            {
                                // Do nothing
                            }
                        }
                        if (player.type == 6)
                        {
                            if (yy > 0 && y < 19 && grid[(x + 1), y].type == 0 && grid[x, (y - 2)].type == 0 && grid[(x + 1), (y - 2)].type == 0)
                            {
                                grid[x, y].type = 0;
                                grid[xx, yy].type = 0;
                                grid[xxxx, yyyy].type = 0;
                                ImgChange(x, y, grid, map);
                                ImgChange(xx, yy, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                                y = y - 2;
                                xx = xx + 1;
                                yy = yy + 1;
                                xxxx = xxxx - 1;
                                yyyy = yyyy - 1;
                                player.Update(x, y, xx, yy, xxx, yyy, xxxx, yyyy);
                                player.compass = 1;
                                grid[x, y].type = player.type;
                                grid[xx, yy].type = player.type;
                                grid[xxxx, yyyy].type = player.type;
                                ImgChange(x, y, grid, map);
                                ImgChange(xx, yy, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                            }
                            else
                            {
                                // Do nothing
                            }
                        }

                        if (player.type == 7)
                        {
                            if (y < 19 && grid[x, (y + 1)].type == 0 && grid[(x + 1), (y + 1)].type == 0 && grid[(x - 1), (y - 1)].type == 0)
                            {
                                grid[x, y].type = 0;
                                grid[xxx, yyy].type = 0;
                                grid[xxxx, yyyy].type = 0;
                                ImgChange(x, y, grid, map);
                                ImgChange(xxx, yyy, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                                y = y + 1;
                                yy = yy + 1;
                                xxx = xxx - 1;
                                yyy -= 1;
                                xxxx = xxxx - 1;
                                yyyy = yyyy - 1;
                                player.Update(x, y, xx, yy, xxx, yyy, xxxx, yyyy);
                                player.compass = 1;
                                grid[x, y].type = player.type;
                                grid[xx, yy].type = player.type;
                                grid[xxxx, yyyy].type = player.type;
                                ImgChange(x, y, grid, map);
                                ImgChange(xx, yy, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                            }
                            else
                            {
                                // Do nothing
                            }
                        }
                    }

                    if (rotation == 1)
                    {
                        if (player.type == 1)
                        {
                            if (x < 8 && x > 0 && grid[(x - 1), (y - 2)].type == 0 &&
                                grid[(x + 1), (y - 2)].type == 0 && grid[(x + 2), (y - 2)].type == 0)
                            {
                                grid[x, y].type = 0;
                                grid[xx, yy].type = 0;
                                grid[xxxx, yyyy].type = 0;
                                ImgChange(x, y, grid, map);
                                ImgChange(xx, yy, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                                x = x - 1;
                                y = y - 2;
                                yy = yy - 1;
                                xxx = xxx + 1;
                                xxxx = xxxx + 2;
                                yyyy = yyyy + 1;
                                player.Update(x, y, xx, yy, xxx, yyy, xxxx, yyyy);
                                player.compass = 0;
                                grid[x, y].type = player.type;
                                grid[xxx, yyy].type = player.type;
                                grid[xxxx, yyyy].type = player.type;
                                ImgChange(x, y, grid, map);
                                ImgChange(xxx, yyy, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                            }
                            else
                            {
                                // Do nothing
                            }
                        }

                        if (player.type == 3)
                        {
                            if (xx < 9 && grid[(x + 2), y].type == 0)
                            {
                                grid[xx, yy].type = 0;
                                ImgChange(xx, yy, grid, map);
                                yy = yy - 1;
                                yyy = yyy - 1;
                                xxxx = xxxx + 1;
                                yyyy = yyyy + 1;
                                player.Update(x, y, xx, yy, xxx, yyy, xxxx, yyyy);
                                player.compass = 2;
                                grid[xxxx, yyyy].type = player.type;
                                ImgChange(xxxx, yyyy, grid, map);
                            }
                            else
                            {
                                // Do nothing
                            }
                        }
                        if (player.type == 4)
                        {
                            if (x > 0 && grid[(x - 1), (y + 2)].type == 0 && grid[xx, (yy + 1)].type == 0)
                            {
                                grid[x, y].type = 0;
                                grid[xxxx, yyyy].type = 0;
                                ImgChange(x, y, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                                x = x - 1;
                                y = y + 2;
                                yy = yy + 1;
                                xxx = xxx - 1;
                                yyyy = yyyy - 1;
                                player.Update(x, y, xx, yy, xxx, yyy, xxxx, yyyy);
                                player.compass = 0;
                                grid[x, y].type = player.type;
                                grid[xx, yy].type = player.type;
                                ImgChange(x, y, grid, map);
                                ImgChange(xx, yy, grid, map);
                            }
                            else
                            {
                                // Do nothing
                            }
                        }

                        if (player.type == 5)
                        {
                            if (x > 0 && grid[(x - 1), (y - 1)].type == 0 && grid[(x + 1), y].type == 0)
                            {
                                grid[xxx, yyy].type = 0;
                                grid[xxxx, yyyy].type = 0;
                                ImgChange(xxx, yyy, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                                x = x - 1;
                                y = y - 1;
                                yy = yy + 1;
                                xxx = xxx - 1;
                                yyyy = yyyy + 2;
                                player.Update(x, y, xx, yy, xxx, yyy, xxxx, yyyy);
                                player.compass = 0;
                                grid[x, y].type = player.type;
                                grid[xxxx, yyyy].type = player.type;
                                ImgChange(x, y, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                            }
                            else
                            {
                                // Do nothing
                            }
                        }
                        if (player.type == 6)
                        {
                            if (x > 0 && xxxx < 9 && grid[(x - 2), y].type == 0 && grid[(x - 2), (y + 1)].type == 0 && grid[x, (y + 1)].type == 0)
                            {
                                grid[x, y].type = 0;
                                grid[xx, yy].type = 0;
                                grid[xxxx, yyyy].type = 0;
                                ImgChange(x, y, grid, map);
                                ImgChange(xx, yy, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                                y = y + 1;
                                yy = yy - 1;
                                xxx = xxx + 1;
                                xxxx = xxxx + 1;
                                player.Update(x, y, xx, yy, xxx, yyy, xxxx, yyyy);
                                player.compass = 2;
                                grid[x, y].type = player.type;
                                grid[xxx, yyy].type = player.type;
                                grid[xxxx, yyyy].type = player.type;
                                ImgChange(x, y, grid, map);
                                ImgChange(xxx, yyy, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                            }
                            else
                            {
                                // Do nothing
                            }
                        }

                        if (player.type == 7)
                        {
                            if (x > 0 && xxxx < 9 && grid[x, (y - 2)].type == 0 && grid[x, (y - 1)].type == 0 && grid[(x + 2), (y - 1)].type == 0)
                            {
                                grid[x, y].type = 0;
                                grid[xx, yy].type = 0;
                                grid[xxxx, yyyy].type = 0;
                                ImgChange(x, y, grid, map);
                                ImgChange(xx, yy, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                                y = y - 1;
                                xx = xx - 1;
                                yy = yy - 2;
                                xxxx = xxxx + 1;
                                yyyy = yyyy + 1;
                                player.Update(x, y, xx, yy, xxx, yyy, xxxx, yyyy);
                                player.compass = 2;
                                grid[x, y].type = player.type;
                                grid[xx, yy].type = player.type;
                                grid[xxxx, yyyy].type = player.type;
                                ImgChange(x, y, grid, map);
                                ImgChange(xx, yy, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                            }
                            else
                            {
                                // Do nothing
                            }
                        }
                    }

                    if (rotation == 2)
                    {
                        if (player.type == 3)
                        {
                            if (y < 19 && grid[(x + 1), (y + 1)].type == 0)
                            {
                                grid[x, y].type = 0;
                                ImgChange(x, y, grid, map);
                                x = x + 1;
                                y = y + 1;
                                player.Update(x, y, xx, yy, xxx, yyy, xxxx, yyyy);
                                player.compass = 3;
                                grid[x, y].type = player.type;
                                ImgChange(x, y, grid, map);
                            }
                            else
                            {
                                // Do nothing
                            }
                        }
                        if (player.type == 6)
                        {
                            if (y < 19 && grid[(x + 2), (y + 1)].type == 0 && grid[(x + 1), (y + 1)].type == 0 && grid[(x + 1), (y - 1)].type == 0)
                            {
                                grid[x, y].type = 0;
                                grid[xxx, yyy].type = 0;
                                grid[xxxx, yyyy].type = 0;
                                ImgChange(x, y, grid, map);
                                ImgChange(xxx, yyy, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                                x = x + 1;
                                y = y + 1;
                                xxx = xxx - 1;
                                yyy = yyy - 1;
                                yyyy = yyyy + 2;
                                player.Update(x, y, xx, yy, xxx, yyy, xxxx, yyyy);
                                player.compass = 3;
                                grid[x, y].type = player.type;
                                grid[xxx, yyy].type = player.type;
                                grid[xxxx, yyyy].type = player.type;
                                ImgChange(x, y, grid, map);
                                ImgChange(xxx, yyy, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                            }
                            else
                            {
                                // Do nothing
                            }
                        }

                        if (player.type == 7)
                        {
                            if (y < 19 && grid[(x + 2), (y - 1)].type == 0 && grid[(x + 1), (y - 1)].type == 0 && grid[(x + 1), (y + 1)].type == 0)
                            {
                                grid[x, y].type = 0;
                                grid[xx, yy].type = 0;
                                grid[xxxx, yyyy].type = 0;
                                ImgChange(x, y, grid, map);
                                ImgChange(xx, yy, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                                x += 1;
                                y = y + 1;
                                xx = xx + 1;
                                yy = yy + 1;
                                yyy -= 1;
                                yyyy = yyyy - 1;
                                player.Update(x, y, xx, yy, xxx, yyy, xxxx, yyyy);
                                player.compass = 3;
                                grid[x, y].type = player.type;
                                grid[xxx, yyy].type = player.type;
                                grid[xxxx, yyyy].type = player.type;
                                ImgChange(x, y, grid, map);
                                ImgChange(xxx, yyy, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                            }
                            else
                            {
                                // Do nothing
                            }
                        }
                    }

                    if (rotation == 3)
                    {
                        if (player.type == 3)
                        {
                            if (y < 19 && grid[(x - 1), (y - 1)].type == 0)
                            {
                                grid[xxx, yyy].type = 0;
                                ImgChange(xxx, yyy, grid, map);
                                x = x - 1;
                                y = y - 1;
                                yy = yy + 1;
                                yyy = yyy + 1;
                                player.Update(x, y, xx, yy, xxx, yyy, xxxx, yyyy);
                                player.compass = 0;
                                grid[x, y].type = player.type;
                                ImgChange(x, y, grid, map);
                            }
                            else
                            {
                                // Do nothing
                            }
                        }
                        if (player.type == 6)
                        {
                            if (x > 0 && xxxx < 9 && grid[(x - 1), y].type == 0 && grid[(x - 1), (y - 1)].type == 0 && grid[(x + 1), (y - 1)].type == 0)
                            {
                                grid[x, y].type = 0;
                                grid[xxx, yyy].type = 0;
                                grid[xxxx, yyyy].type = 0;
                                ImgChange(x, y, grid, map);
                                ImgChange(xxx, yyy, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                                x -= 1;
                                xx -= 1;
                                yyy += 1;
                                yyyy -= 1;
                                player.Update(x, y, xx, yy, xxx, yyy, xxxx, yyyy);
                                player.compass = 0;
                                grid[x, y].type = player.type;
                                grid[xx, yy].type = player.type;
                                grid[xxxx, yyyy].type = player.type;
                                ImgChange(x, y, grid, map);
                                ImgChange(xx, yy, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                            }
                            else
                            {
                                // Do nothing
                            }
                        }

                        if (player.type == 7)
                        {
                            if (x > 0 && xxxx < 9 && grid[(x + 1), y].type == 0 && grid[(x + 1), (y - 1)].type == 0 && grid[(x - 1), (y - 1)].type == 0)
                            {
                                grid[x, y].type = 0;
                                grid[xxx, yyy].type = 0;
                                grid[xxxx, yyyy].type = 0;
                                ImgChange(x, y, grid, map);
                                ImgChange(xxx, yyy, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                                x -= 1;
                                y -= 1;
                                xxx += 1;
                                yyy += 2;
                                yyyy = yyyy + 1;
                                player.Update(x, y, xx, yy, xxx, yyy, xxxx, yyyy);
                                player.compass = 0;
                                grid[x, y].type = player.type;
                                grid[xxx, yyy].type = player.type;
                                grid[xxxx, yyyy].type = player.type;
                                ImgChange(x, y, grid, map);
                                ImgChange(xxx, yyy, grid, map);
                                ImgChange(xxxx, yyyy, grid, map);
                            }
                            else
                            {
                                // Do nothing
                            }
                        }
                    }
                }
            }
            else if (key == 1)
            {
                if (xxxx < 9)
                {
                    if (rotation == 0)
                    {
                        if (player.type == 1)
                        {
                            if (grid[(xxxx + 1), yyyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                RightKey(player, grid, map);
                            }
                        }
                        if (player.type == 2 || player.type == 5 || player.type == 7)
                        {
                            if (grid[(xxx + 1), yyy].type != 0 || grid[(xxxx + 1), yyyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                RightKey(player, grid, map);
                            }
                        }
                        if (player.type == 3 || player.type == 4)
                        {
                            if (grid[(xx + 1), yy].type != 0 || grid[(xxxx + 1), yyyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                RightKey(player, grid, map);
                            }
                        }
                        if (player.type == 6)
                        {
                            if (grid[(x + 1), y].type != 0 || grid[(xxxx + 1), yyyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                RightKey(player, grid, map);
                            }
                        }
                    }

                    if (rotation == 1)
                    {
                        if (player.type == 1)
                        {
                            if (grid[(x + 1), y].type != 0 || grid[(xx + 1), yy].type != 0 || grid[(xxx + 1), yyy].type != 0 || grid[(xxxx + 1), yyyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                RightKey(player, grid, map);
                            }
                        }
                        if (player.type == 3)
                        {
                            if (grid[(xx + 1), yy].type != 0 || grid[(xxx + 1), yyy].type != 0 || grid[(xxxx + 1), yyyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                RightKey(player, grid, map);
                            }
                        }
                        if (player.type == 4 || player.type == 5)
                        {
                            if (grid[(x + 1), y].type != 0 || grid[(xxx + 1), yyy].type != 0 || grid[(xxxx + 1), yyyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                RightKey(player, grid, map);
                            }
                        }
                        if (player.type == 6 || player.type == 7)
                        {
                            if (grid[(xx + 1), y].type != 0 || grid[(xxx + 1), yyy].type != 0 || grid[(xxxx + 1), yyyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                RightKey(player, grid, map);
                            }
                        }
                    }

                    if (rotation == 2)
                    {
                        if (player.type == 3)
                        {
                            if (grid[(xxx + 1), yyy].type != 0 || grid[(xxxx + 1), yyyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                RightKey(player, grid, map);
                            }
                        }
                        if (player.type == 6)
                        {
                            if (grid[(xxx + 1), yyy].type != 0 || grid[(xxxx + 1), yyyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                RightKey(player, grid, map);
                            }
                        }
                        if (player.type == 7)
                        {
                            if (grid[(xx + 1), yy].type != 0 || grid[(xxxx + 1), yyyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                RightKey(player, grid, map);
                            }
                        }
                    }

                    if (rotation == 3)
                    {
                        if (player.type == 3)
                        {
                            if (grid[(x + 1), y].type != 0 || grid[(xxx + 1), yyy].type != 0 || grid[(xxxx + 1), yyyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                RightKey(player, grid, map);
                            }
                        }
                        if (player.type == 6)
                        {
                            if (grid[(xx + 1), yy].type != 0 || grid[(xxx + 1), yyy].type != 0 || grid[(xxxx + 1), yyyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                RightKey(player, grid, map);
                            }
                        }
                        if (player.type == 7)
                        {
                            if (grid[(x + 1), y].type != 0 || grid[(xx + 1), yy].type != 0 || grid[(xxxx + 1), yyyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                RightKey(player, grid, map);
                            }
                        }
                    }
                }
            }
            else if (key == 2)
            {
                if (rotation == 0)
                {
                    if (player.type == 1)
                    {
                        if (y == 19 || grid[x, (y + 1)].type != 0 || grid[xx, (yy + 1)].type != 0 || grid[xxx, (yyy + 1)].type != 0 || grid[xxxx, (yyyy + 1)].type != 0)
                        {
                            player.isActive = false;
                        }
                        else
                        {
                            DownKey(player, grid, map);
                        }
                    }
                    if (player.type == 2)
                    {
                        if (yyy == 19 || grid[xxx, (yyy + 1)].type != 0 || grid[x, (y + 1)].type != 0)
                        {
                            player.isActive = false;
                        }
                        else
                        {
                            DownKey(player, grid, map);
                        }
                    }
                    if (player.type == 3)
                    {
                        if (yy == 19 || grid[x, (y + 1)].type != 0 || grid[xx, (yy + 1)].type != 0 || grid[xxxx, (yyyy + 1)].type != 0)
                        {
                            player.isActive = false;
                        }
                        else
                        {
                            DownKey(player, grid, map);
                        }
                    }
                    if (player.type == 4)
                    {
                        if (y == 19 || grid[x, (y + 1)].type != 0 || grid[xx, (yy + 1)].type != 0 || grid[xxxx, (yyyy + 1)].type != 0)
                        {
                            player.isActive = false;
                        }
                        else
                        {
                            DownKey(player, grid, map);
                        }
                    }
                    if (player.type == 5)
                    {
                        if (yyyy == 19 || grid[x, (y + 1)].type != 0 || grid[xx, (yy + 1)].type != 0 || grid[xxxx, (yyyy + 1)].type != 0)
                        {
                            player.isActive = false;
                        }
                        else
                        {
                            DownKey(player, grid, map);
                        }
                    }
                    if (player.type == 6)
                    {
                        if (y == 19 || grid[x, (y + 1)].type != 0 || grid[xxx, (yyy + 1)].type != 0 || grid[xxxx, (yyyy + 1)].type != 0)
                        {
                            player.isActive = false;
                        }
                        else
                        {
                            DownKey(player, grid, map);
                        }
                    }
                    if (player.type == 7)
                    {
                        if (yyy == 19 || grid[x, (y + 1)].type != 0 || grid[xx, (yy + 1)].type != 0 || grid[xxx, (yyy + 1)].type != 0)
                        {
                            player.isActive = false;
                        }
                        else
                        {
                            DownKey(player, grid, map);
                        }
                    }
                }
                if (rotation == 1)
                {
                    if (player.type == 1)
                    {
                        if (y == 19 || grid[x, (y + 1)].type != 0)
                        {
                            player.isActive = false;
                        }
                        else
                        {
                            DownKey(player, grid, map);
                        }
                    }
                    if (player.type == 2)
                    {
                        if (yyy == 19 || grid[xxx, (yyy + 1)].type != 0 || grid[x, (y + 1)].type != 0)
                        {
                            player.isActive = false;
                        }
                        else
                        {
                            DownKey(player, grid, map);
                        }
                    }
                    if (player.type == 3)
                    {
                        if (yy == 19 || grid[x, (y + 1)].type != 0 || grid[xx, (yy + 1)].type != 0)
                        {
                            player.isActive = false;
                        }
                        else
                        {
                            DownKey(player, grid, map);
                        }
                    }
                    if (player.type == 4)
                    {
                        if (yyyy == 19 || grid[xx, (yy + 1)].type != 0 || grid[xxxx, (yyyy + 1)].type != 0)
                        {
                            player.isActive = false;
                        }
                        else
                        {
                            DownKey(player, grid, map);
                        }
                    }
                    if (player.type == 5)
                    {
                        if (y == 19 || grid[x, (y + 1)].type != 0 || grid[xxx, (yyy + 1)].type != 0)
                        {
                            player.isActive = false;
                        }
                        else
                        {
                            DownKey(player, grid, map);
                        }
                    }
                    if (player.type == 6 || player.type == 7)
                    {
                        if (yy == 19 || grid[x, (y + 1)].type != 0 || grid[xx, (yy + 1)].type != 0)
                        {
                            player.isActive = false;
                        }
                        else
                        {
                            DownKey(player, grid, map);
                        }
                    }
                }

                if (rotation == 2)
                {
                    if (player.type == 3)
                    {
                        if (yy == 19 || grid[x, (y + 1)].type != 0 || grid[xx, (yy + 1)].type != 0 || grid[xxxx, (yyyy + 1)].type != 0)
                        {
                            player.isActive = false;
                        }
                        else
                        {
                            DownKey(player, grid, map);
                        }
                    }
                    if (player.type == 6)
                    {
                        if (yy == 19 || grid[x, (y + 1)].type != 0 || grid[xx, (yy + 1)].type != 0 || grid[xxx, (yyy + 1)].type != 0)
                        {
                            player.isActive = false;
                        }
                        else
                        {
                            DownKey(player, grid, map);
                        }
                    }
                    if (player.type == 7)
                    {
                        if (y == 19 || grid[x, (y + 1)].type != 0 || grid[xxx, (yyy + 1)].type != 0 || grid[xxxx, (yyyy + 1)].type != 0)
                        {
                            player.isActive = false;
                        }
                        else
                        {
                            DownKey(player, grid, map);
                        }
                    }
                }

                if (rotation == 3)
                {
                    if (player.type == 3)
                    {
                        if (y == 19 || grid[x, (y + 1)].type != 0 || grid[xxxx, (yyyy + 1)].type != 0)
                        {
                            player.isActive = false;
                        }
                        else
                        {
                            DownKey(player, grid, map);
                        }
                    }
                    if (player.type == 6 || player.type == 7)
                    {
                        if (y == 19 || grid[x, (y + 1)].type != 0 || grid[xxxx, (yyyy + 1)].type != 0)
                        {
                            player.isActive = false;
                        }
                        else
                        {
                            DownKey(player, grid, map);
                        }
                    }
                }
            }
            else if (key == 3)
            {
                if (x != 0)
                {
                    if (rotation == 0)
                    {
                        if (player.type == 1)
                        {
                            if (grid[(x - 1), y].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                LeftKey(player, grid, map);
                            }
                        }

                        if (player.type == 2 || player.type == 3 || player.type == 5 || player.type == 6)
                        {
                            if (grid[(x - 1), y].type != 0 || grid[(xx - 1), yy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                LeftKey(player, grid, map);
                            }
                        }

                        if (player.type == 4 || player.type == 7)
                        {
                            if (grid[(x - 1), y].type != 0 || grid[(xxx - 1), yyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                LeftKey(player, grid, map);
                            }
                        }
                    }

                    if (rotation == 1)
                    {
                        if (player.type == 1)
                        {
                            if (grid[(x - 1), y].type != 0 || grid[(xx - 1), yy].type != 0 || grid[(xxx - 1), yyy].type != 0 || grid[(xxxx - 1), yyyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                LeftKey(player, grid, map);
                            }
                        }

                        if (player.type == 3)
                        {
                            if (grid[(x - 1), y].type != 0 || grid[(xx - 1), yy].type != 0 || grid[(xxxx - 1), yyyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                LeftKey(player, grid, map);
                            }
                        }

                        if (player.type == 4 || player.type == 5)
                        {
                            if (grid[(x - 1), y].type != 0 || grid[(xx - 1), yy].type != 0 || grid[(xxxx - 1), yyyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                LeftKey(player, grid, map);
                            }
                        }
                        if (player.type == 6)
                        {
                            if (grid[(x - 1), y].type != 0 || grid[(xx - 1), yy].type != 0 || grid[(xxx - 1), yyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                LeftKey(player, grid, map);
                            }
                        }
                        if (player.type == 7)
                        {
                            if (grid[(x - 1), y].type != 0 || grid[(xxx - 1), yyy].type != 0 || grid[(xxxx - 1), yyyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                LeftKey(player, grid, map);
                            }
                        }
                    }

                    if (rotation == 2)
                    {
                        if (player.type == 3)
                        {
                            if (grid[(x - 1), y].type != 0 || grid[(xxx - 1), yyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                LeftKey(player, grid, map);
                            }
                        }
                        if (player.type == 6)
                        {
                            if (grid[(x - 1), y].type != 0 || grid[(xxxx - 1), yyyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                LeftKey(player, grid, map);
                            }
                        }
                        if (player.type == 7)
                        {
                            if (grid[(x - 1), y].type != 0 || grid[(xx - 1), yy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                LeftKey(player, grid, map);
                            }
                        }
                    }

                    if (rotation == 3)
                    {
                        if (player.type == 3)
                        {
                            if (grid[(x - 1), y].type != 0 || grid[(xx - 1), yy].type != 0 || grid[(xxx - 1), yyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                LeftKey(player, grid, map);
                            }
                        }
                        if (player.type == 6 || player.type == 7)
                        {
                            if (grid[(x - 1), y].type != 0 || grid[(xx - 1), yy].type != 0 || grid[(xxx - 1), yyy].type != 0)
                            {
                                // Do nothing
                            }
                            else
                            {
                                LeftKey(player, grid, map);
                            }
                        }
                    }
                }
            }
        }
        public void RightKey(Player player, Tile[,] grid, Grid map)
        {
            int limit1X;
            int limit1Y;
            int limit2X;
            int limit2Y;
            int limit3X;
            int limit3Y;

            // Control
            int beforeX = player.controlX;
            player.controlX = beforeX + 1;
            int x = player.controlX;
            int y = player.controlY;
            limit1X = x;
            limit1Y = y;

            grid[beforeX, y].type = 0;
            this.ImgChange(beforeX, y, grid, map);
            grid[x, y].type = player.type;
            ImgChange(x, y, grid, map);

            // First
            beforeX = player.firstX;
            player.firstX = beforeX + 1;
            x = player.firstX;
            y = player.firstY;
            limit2X = x;
            limit2Y = y;

            if (beforeX == limit1X)
            {
                if (y == limit1Y)
                {
                    //do nothing
                }
                else
                {
                    grid[beforeX, y].type = 0;
                    ImgChange(beforeX, y, grid, map);
                }
            }
            else
            {
                grid[beforeX, y].type = 0;
                ImgChange(beforeX, y, grid, map);
            }
            grid[x, y].type = player.type;
            ImgChange(x, y, grid, map);

            // Second
            beforeX = player.secondX;
            player.secondX = beforeX + 1;
            x = player.secondX;
            y = player.secondY;
            limit3X = x;
            limit3Y = y;

            if (beforeX == limit1X || beforeX == limit2X)
            {
                if (y == limit1Y || y == limit2Y)
                {
                    //do nothing
                }
                else
                {
                    grid[beforeX, y].type = 0;
                    ImgChange(beforeX, y, grid, map);
                }
            }
            else
            {
                grid[beforeX, y].type = 0;
                ImgChange(beforeX, y, grid, map);
            }
            grid[x, y].type = player.type;
            ImgChange(x, y, grid, map);

            // Third
            beforeX = player.thirdX;
            player.thirdX = beforeX + 1;
            x = player.thirdX;
            y = player.thirdY;

            if (beforeX == limit1X || beforeX == limit2X || beforeX == limit3X)
            {
                if (y == limit1Y || y == limit2Y || y == limit3Y)
                {
                    //do nothing
                }
                else
                {
                    grid[beforeX, y].type = 0;
                    ImgChange(beforeX, y, grid, map);
                }
            }
            else
            {
                grid[beforeX, y].type = 0;
                ImgChange(beforeX, y, grid, map);
            }
            grid[x, y].type = player.type;
            ImgChange(x, y, grid, map);
        }
        public void LeftKey(Player player, Tile[,] grid, Grid map)
        {
            int limit1;
            int limit2;
            int limit3;

            // Control
            int beforeX = player.controlX;
            player.controlX = beforeX - 1;
            int x = player.controlX;
            int y = player.controlY;
            limit1 = x;

            grid[beforeX, y].type = 0;
            this.ImgChange(beforeX, y, grid, map);
            grid[x, y].type = player.type;
            ImgChange(x, y, grid, map);

            // First
            beforeX = player.firstX;
            player.firstX = beforeX - 1;
            x = player.firstX;
            y = player.firstY;
            limit2 = x;

            grid[beforeX, y].type = 0;
            ImgChange(beforeX, y, grid, map);
            grid[x, y].type = player.type;
            ImgChange(x, y, grid, map);

            // Second
            beforeX = player.secondX;
            player.secondX = beforeX - 1;
            x = player.secondX;
            y = player.secondY;
            limit3 = x;

            grid[beforeX, y].type = 0;
            ImgChange(beforeX, y, grid, map);
            grid[x, y].type = player.type;
            ImgChange(x, y, grid, map);

            // Third
            beforeX = player.thirdX;
            player.thirdX = beforeX - 1;
            x = player.thirdX;
            y = player.thirdY;

            grid[beforeX, y].type = 0;
            ImgChange(beforeX, y, grid, map);
            grid[x, y].type = player.type;
            ImgChange(x, y, grid, map);
        }

        public void DownKey(Player player, Tile[,] grid, Grid map)
        {
            int limit1X;
            int limit1Y;
            int limit2X;
            int limit2Y;
            int limit3X;
            int limit3Y;

            // Control
            int beforeY = player.controlY;
            player.controlY = beforeY + 1;
            int x = player.controlX;
            int y = player.controlY;
            limit1X = x;
            limit1Y = y;

            grid[x, beforeY].type = 0;
            ImgChange(x, beforeY, grid, map);
            grid[x, y].type = player.type;
            ImgChange(x, y, grid, map);

            // First
            beforeY = player.firstY;
            player.firstY = beforeY + 1;
            x = player.firstX;
            y = player.firstY;
            limit2X = x;
            limit2Y = y;

            if (x == limit1X)
            {
                if (beforeY == limit1Y)
                {
                    // do nothing
                }
                else
                {
                    grid[x, beforeY].type = 0;
                    ImgChange(x, beforeY, grid, map);
                }
            }
            else
            {
                grid[x, beforeY].type = 0;
                ImgChange(x, beforeY, grid, map);
            }
            grid[x, y].type = player.type;
            ImgChange(x, y, grid, map);

            // Second
            beforeY = player.secondY;
            player.secondY = beforeY + 1;
            x = player.secondX;
            y = player.secondY;
            limit3X = x;
            limit3Y = y;

            if (x == limit1X || x == limit2X)
            {
                if (beforeY == limit1Y || beforeY == limit2Y)
                {
                    // do nothing
                }
                else
                {
                    grid[x, beforeY].type = 0;
                    ImgChange(x, beforeY, grid, map);
                }
            }
            else
            {
                grid[x, beforeY].type = 0;
                ImgChange(x, beforeY, grid, map);
            }
            grid[x, y].type = player.type;
            ImgChange(x, y, grid, map);

            // Third
            beforeY = player.thirdY;
            player.thirdY = beforeY + 1;
            x = player.thirdX;
            y = player.thirdY;

            if (x == limit1X || x == limit2X || x == limit3X)
            {
                if (beforeY == limit1Y || beforeY == limit2Y || beforeY == limit3Y)
                {
                    // do nothing
                }
                else
                {
                    grid[x, beforeY].type = 0;
                    ImgChange(x, beforeY, grid, map);
                }
            }
            else
            {
                grid[x, beforeY].type = 0;
                ImgChange(x, beforeY, grid, map);
            }
            grid[x, y].type = player.type;
            ImgChange(x, y, grid, map);
        }

        public List<int> LineCheck(Tile[,] grid, Grid map)
        {
            List<int> filled = new List<int>();
            for (int y = 0; y < 20; y++)
            {
                int currentY = 0;
                int typeCnt = 0;
                for (int x = 0; x < 10; x++)
                {
                    if (grid[x, y].type != 0)
                    {
                        typeCnt++;
                        currentY = y;
                    }
                }
                if (typeCnt == 10)
                {
                    filled.Add(currentY);
                }
            }
  
            if (filled.Count > 0)
            {
                this.ClearLines(filled, grid, map);
            }

            return filled;
        }

        private void ClearLines(List<int> lines, Tile[,] grid, Grid map)
        {
            int runTime = 0;
            for (int i = 0; i < lines.Count; i++)
            {
                //for (int y = 0; y < (20 - (lines.Count - runTime)); y++)
                for (int y = 0; y < ((19 /*- (if lines[i] == 18 then subtract 1) (if lines[i] == 17 then subract 2) etc*/) - lines.Count); y++)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        grid[x, (lines[i] - y)].type = grid[x, ((lines[i] - y) - 1)].type;
                        ImgChange(x, (lines[i] - y), grid, map);
                    }
                }
            }
        }
    }
}
