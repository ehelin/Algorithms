using System;
using System.Collections.Generic;

namespace Algorithms.TravelingSalesman
{
    public class Algorithm
    {
        /// <summary>
        /// Two dimensional grid for the cities with row/column counts
        /// </summary>
        private int[,] grid = null;
        private int row = 0;
        private int col = 0;

        /// <summary>
        /// List of cities on the grid
        /// </summary>
        private List<City> cities = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public Algorithm(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public void RunExample()
        {
            Console.WriteLine("Starting Traveling Salesman - " + DateTime.Now.ToString());

            Run();

            Console.WriteLine("Traveling Salesman Complete! " + DateTime.Now.ToString());
        }

        #region private methods

        private void Run()
        {
            int index = 1;

            while (true)
            {
                Init();

                Console.WriteLine("There are " + cities.Count + " cities in a " + grid.GetLength(0).ToString() + " by " + grid.GetLength(1).ToString() + " grid");

                FindBestRouteForEach();
                DisplayLowestPathResults();

                Utilities.DisplayGrid(grid, this.cities[index], index);

                //City startCity = this.cities[index];
                //int maxPathCount = startCity.GetUniquePathCount();
                //while (index < maxPathCount)
                //{
                //    Utilities.DisplayGrid(grid, this.cities[index], index);
                //    index++;
                //    Console.Read();
                //}

                Console.WriteLine("Press 1 through " + this.cities.Count + " to see that starting city or '-1' to end");
                index = Convert.ToInt32(Console.ReadLine());

                if (index < 0)
                    break;
                else
                    index--;
            }
        }

        //TODO - comment rest of methods
        private void Init()
        {
            this.cities = Utilities.GetCities();
            grid = Utilities.PopulateGrid(grid, row, col, cities);
        }      
        private void PopulateGrid(int row, int col)
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
        }
        private void FindBestRouteForEach()
        {
            Console.WriteLine("Creating each city with list of cities, permutations and distances...");
            foreach (City city in cities)
            {
                city.AddOtherCitiesPermutations(cities);
            }
            Console.WriteLine("Done with city preliminary calculations!");

            Console.WriteLine("Calculating the lowest cost path for each city...");
            foreach (City city in cities)
            {
                city.CalculateBestPath();
            }
            Console.WriteLine("Done with city lowest cost path calculations!");
        }
        private void DisplayLowestPathResults()
        {
            foreach (City city in cities)
            {
                Console.WriteLine(city.Name + "(" + city.X.ToString() + "/" + city.Y.ToString() + ") - Lowest cost path is " + city.GetLowestPathCost());
            }
        }

        #endregion
    }
}
