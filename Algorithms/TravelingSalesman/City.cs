using System.Collections;
using System.Collections.Generic;

namespace Algorithms.TravelingSalesman
{
    public class City
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool AddedToGrid { get; set; }
        public List<City> OtherCities { get; set; }

        public City(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            OtherCities = new List<City>();
        }

        public override string ToString()
        {
            string result = "X: " + X.ToString() + ", Y: " + Y.ToString();

            return result;
        }

        //Best Path with this being the first city
        public void CalculateBestPath()
        {
            foreach (City otherCity in OtherCities)
            {
                //City comparisonCity = otherCity.Key;
                //CityDistance comparisonCityDistance = otherCity.Value;

                //int test = 1;
            }

        }
    }
}
