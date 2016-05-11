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
                    if (grid[rowCtr, colCtr] == 1)
                        Console.Write(grid[rowCtr, colCtr].ToString() + "-");
                    else
                        Console.Write("0-");
                }

                Console.WriteLine("");
            }
        }
    }
}
