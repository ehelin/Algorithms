using System.Collections.Generic;
using Algorithms.TravelingSalesman;
using System;

namespace Algorithms
{
    public class Utilities
    {
        #region Travelin Salesman

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
        public static List<City> GetCities()
        {
            List<City> city = new List<City>();

            city.Add(new City("City1", 2, 2, 1));
            city.Add(new City("City2", 4, 4, 2));
            city.Add(new City("City3", 6, 6, 3));
            city.Add(new City("City4", 11, 15, 4));
            city.Add(new City("City5", 19, 10, 5));
            city.Add(new City("City6", 15, 4, 6));
            city.Add(new City("City7", 19, 18, 7));
            city.Add(new City("City8", 8, 4, 8));
            city.Add(new City("City9", 9, 2, 9));
            city.Add(new City("City10", 10, 10, 10));

            return city;
        }


        //TODO - replace this method with a Contains linq statement
        public static City PopulateCity(int X, int Y, List<City> cities)
        {
            City matchCity = null;

            foreach (City city in cities)
            {
                if (city.X == X && city.Y == Y && !city.AddedToGrid)
                {
                    matchCity = city;
                    matchCity.AddedToGrid = true;
                    break;
                }
            }

            return matchCity;
        }
        public static int[,] PopulateGrid(int[,] grid, int row, int col, List<City> cities)
        {
            grid = new int[row, col];

            for (int rowCtr = 0; rowCtr < row; rowCtr++)
            {
                for (int colCtr = 0; colCtr < col; colCtr++)
                {
                    City city = Utilities.PopulateCity(rowCtr, colCtr, cities);

                    if (city != null)
                    {
                        grid[rowCtr, colCtr] = 1;
                    }
                    else
                    {
                        grid[rowCtr, colCtr] = 0;
                    }
                }
            }

            return grid;
        }

        #endregion

        #region Permutation

        public static List<int> Sort(List<int> values)
        {
            //Starting with bubble sort for ease of use...replace with quick sort?
            for (int outer = 0; outer < values.Count - 1; outer++)
            {
                for (int inner = 0; inner < values.Count - 1; inner++)
                {
                    if (inner + 1 > values.Count)
                        break;

                    if (values[inner] > values[inner + 1])
                    {
                        int val = values[inner];
                        values[inner] = values[inner + 1];
                        values[inner + 1] = val;
                    }
                }
            }

            return values;
        }
        public static bool ProcessingDone(List<int> Values, int compareValue, out bool doneProcessing)
        {
            doneProcessing = false;

            if (Values.Count < compareValue)
            {
                doneProcessing = true;
            }

            return doneProcessing;
        }
        public static bool ExecuteCommand(List<int> ValuesOperationList, int indexToIncrement)
        {
            bool executeCommand = true;
            int ctr = indexToIncrement - 1;
            int curIndexValue = ValuesOperationList[ValuesOperationList.Count - indexToIncrement];

            while (ctr > 0)
            {
                if (ValuesOperationList[ValuesOperationList.Count - ctr] != ctr)
                {
                    executeCommand = false;
                    break;
                }

                ctr--;
            }

            if (executeCommand && curIndexValue >= indexToIncrement)
            {
                executeCommand = false;
            }

            return executeCommand;
        }
        public static List<int> ResetOperationArray(List<int> ValuesOperationList, int indexToIncrement)
        {
            int ctr = indexToIncrement-1;
            int curIndexValue = ValuesOperationList[ValuesOperationList.Count - indexToIncrement];
            curIndexValue = curIndexValue + 1;

            while (ctr > 0)
            {
                ValuesOperationList[ValuesOperationList.Count - ctr] = 0;
                ctr--;
            }

            ValuesOperationList[ValuesOperationList.Count - indexToIncrement] = curIndexValue;

            return ValuesOperationList;
        }
        public static int CalculateFactorial(int value)
        {
            int factorial = value;
            int ctr = 1;

            while (ctr < value)
            {
                factorial = factorial * (value - ctr);
                ctr++;
            }

            return factorial;
        }
        public static int GetNextBiggerNumber(List<int> values, int curValue)
        {
            int nxtValue = 0;

            foreach (int value in values)
            {
                if (value > curValue && value > nxtValue)
                {
                    nxtValue = value;
                    break;
                }
            }

            return nxtValue;
        }

        #endregion
    }
}
