using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.TravelingSalesman
{
    public class Algorithm
    {
        private int[,] grid = null;
        private List<City> cities = null;

        public Algorithm(int row, int col, List<City> cities)
        {
            this.cities = cities;

            grid = Utilities.PopulateGrid(grid, row, col, cities);
        }

        public void RunExample()
        {
            InitMessage();

            Run();

            Utilities.DisplayGrid(grid);
            
            Console.WriteLine("Traveling Salesman Complete! " + DateTime.Now.ToString());
        }
        
        private void Run()
        {
            FindBestRouteForEach();
            DisplayLowestPathResults();
        }

        #region private methods

        private void DisplayLowestPathResults()
        {
            foreach (City city in cities)
            {
                Console.WriteLine(city.Name + " - Lowest cost path is " + city.GetLowestPathCost());
            }
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

            foreach (City city in cities)
            {
                Console.WriteLine(city.ToString());
            }
        }

        #endregion
    }
}
