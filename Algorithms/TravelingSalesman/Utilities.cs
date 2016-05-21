using System;
using System.Collections.Generic;

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

        public static List<Cityv2> GetCitiesv2()
        {
            List<Cityv2> city = new List<Cityv2>();

            city.Add(new Cityv2("City1", 2, 2));
            city.Add(new Cityv2("City2", 4, 4));
            city.Add(new Cityv2("City3", 6, 6));
            city.Add(new Cityv2("City4", 11, 15));
            city.Add(new Cityv2("City5", 19, 10));
            city.Add(new Cityv2("City6", 15, 4));

            return city;
        }
        public static List<City> GetCities()
        {
            List<City> city = new List<City>();

            city.Add(new City("City1", 2, 2));
            city.Add(new City("City2", 4, 4));
            city.Add(new City("City3", 6, 6));
            city.Add(new City("City4", 11, 15));
            city.Add(new City("City5", 19, 10));
            city.Add(new City("City6", 15, 4));

            return city;
        }
    }
}
