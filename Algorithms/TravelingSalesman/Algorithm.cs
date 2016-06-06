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
            Console.WriteLine("Starting Traveling Salesman");

            Utilities.DisplayGrid(grid);

            Run();

            //DisplayGrid();

            Console.WriteLine("Traveling Salesman Complete!");
        }
        
        private void Run()
        {
            FindBestRouteForEach();
        }

        #region private methods

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
            foreach (City city in cities)
            {
                city.AddOtherCitysAndPermutationsDistances(cities);
                city.CalculateBestPath();
            }

            City tmpCity = cities[0];
        }

        #endregion
    }
}
