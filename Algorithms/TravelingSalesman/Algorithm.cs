using System;
using System.Collections.Generic;

namespace Algorithms.TravelingSalesman
{
    public class Algorithm
    {
        /// <summary>
        /// Two dimensional grid for the cities
        /// </summary>
        private int[,] grid = null;
        private int row = 0;
        private int col = 0;

        /// <summary>
        /// List of cities on the grid
        /// </summary>
        private List<City> cities = null;

        public Algorithm(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public void RunExample()
        {
            int index = 0;

            while (true)
            {
                Init();
                InitMessage();
                Run();
                Utilities.DisplayGrid(grid, this.cities[index]);

                Console.WriteLine("Press 1 through " + this.cities.Count + " to see that starting city or '-1' to end");
                index = Convert.ToInt32(Console.ReadLine());

                if (index < 0)
                    break;
                else
                    index--;
            }

            Console.WriteLine("Traveling Salesman Complete! " + DateTime.Now.ToString());
        }        

        #region private methods

        private void DisplayLowestPathResults()
        {
            foreach (City city in cities)
            {
                Console.WriteLine(city.Name + "(" + city.X.ToString() + "/" + city.Y.ToString() + ") - Lowest cost path is " + city.GetLowestPathCost());
            }
        }
        private void Run()
        {
            FindBestRouteForEach();
            DisplayLowestPathResults();
        }
        private void Init()
        {
            this.cities = Utilities.GetCities();

            grid = Utilities.PopulateGrid(grid, row, col, cities);
        }
        //TODO - replace this method with a Contains linq statement
        private City PopulateCity(int X, int Y)
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
        private void PopulateGrid(int row, int col)
        {
            grid = new int[row, col];

            for (int rowCtr = 0; rowCtr < row; rowCtr++)
            {
                for (int colCtr = 0; colCtr < col; colCtr++)
                {
                    City city = PopulateCity(rowCtr, colCtr);

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
                city.AddOtherCitysAndPermutationsDistances(cities);
            }
            Console.WriteLine("Done with city preliminary calculations!");

            Console.WriteLine("Calculating the lowest cost path for each city...");
            foreach (City city in cities)
            {
                city.CalculateBestPath();
            }
            Console.WriteLine("Done with city lowest cost path calculations!");
        }
        private void InitMessage()
        {
            Console.WriteLine("Starting Traveling Salesman - " + DateTime.Now.ToString());
            Console.WriteLine("There are " + cities.Count + " cities in a " + grid.GetLength(0).ToString() + " by " + grid.GetLength(1).ToString() + " grid");
        }

        #endregion
    }
}
