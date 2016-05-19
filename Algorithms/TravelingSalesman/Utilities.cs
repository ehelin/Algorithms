using System;

namespace Algorithms.TravelingSalesman
{
    public class Utilities
    {
        public static void DisplayGrid(int[,] grid)
        {
            //TODO - use showPath to show best route
            for (int rowCtr = 0; rowCtr < grid.GetLength(0); rowCtr++)
            {
                for (int colCtr = 0; colCtr < grid.GetLength(1); colCtr++)
                {
                    if (grid[colCtr, rowCtr] == 1)
                        Console.Write(grid[colCtr, rowCtr].ToString() + "-");
                    else
                        Console.Write("0-");
                }

                Console.WriteLine("");
            }
        }
    }
}
