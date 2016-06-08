using System;
using System.Collections.Generic;

namespace Algorithms.TravelingSalesman
{
    public class City
    {
        /// <summary>
        /// This city's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 2 dimensional X/Y position
        /// </summary>
        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// Number id for a city (used in permutation algorithm)
        /// </summary>
        public int NumberId { get; set; }

        /// <summary>
        /// Added to the console grid (or not)
        /// </summary>
        public bool AddedToGrid { get; set; }

        /// <summary>
        /// List of cities and their distance from this distance
        /// </summary>
        public Dictionary<City, CityDistance> cityDistances;

        /// <summary>
        /// List of ids for permutation algorithm (i.e. other cities)
        /// </summary>
        private string cityIds;

        /// <summary>
        /// List of other cities one can visit from this city
        /// </summary>
        private List<City> otherCities;
        private List<string> cityPermutations;

        /// <summary>
        /// Lowest permutation and distance
        /// </summary>
        private string lowestCostPermutation = string.Empty;
        private int lowestDistance = 0;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="numberId"></param>
        public City(string Name, int X, int Y, int numberId)
        {
            this.Name = Name;
            this.X = X;
            this.Y = Y;
            this.NumberId = numberId;
            cityDistances = new Dictionary<City, CityDistance>();
            otherCities = new List<City>();
            cityPermutations = new List<string>();
        }   
        
        public City Clone()
        {
            City newCity = new City(this.Name, this.X, this.Y, this.NumberId);
            newCity.AddedToGrid = this.AddedToGrid;

            foreach (var cityDistance in cityDistances)
            {
                newCity.cityDistances.Add(cityDistance.Key, cityDistance.Value);
            }

            return newCity;
        }
        public override string ToString()
        {
            string result = "Name: " + this.Name + ", X: " + this.X.ToString() + ", Y: " + Y.ToString();

            return result;
        }
        public string GetLowestPathCost()
        {
            string lowestCostPath = this.lowestCostPermutation + ", distance: " + this.lowestDistance.ToString();

            return lowestCostPath;
        }
        public int GetDistance(City destinationCity)
        {
            int steps = 0;

            foreach (KeyValuePair<City, CityDistance> cityDistance in cityDistances)
            {
                if (cityDistance.Key.Name.Equals(destinationCity.Name))
                {
                    steps = cityDistance.Value.TravelDirections.Count;
                    break;
                }
            }

            return steps;
        }

        #region Calculate Best Path

        //Calculate the least cost path to visit all other cities fromt this city
        public void CalculateBestPath()
        {
            Dictionary<string, Dictionary<string, int>>  startingCityTotalDistances = new Dictionary<string, Dictionary<string, int>>();
            
            //for each city list, get the travel cost list and store
            foreach (string cityPermutation in this.cityPermutations)
            {
                Dictionary<City, bool> cityBools = GetCityList(cityPermutation);
                City lastCity = null;

                //put this city as start city to the first one in the permutation
                Dictionary<string, int> individualCityDistances = new Dictionary<string, int>();
                List<string> curStartCityDistanceCities = new List<string>();
                City startCity = this.Clone();

                //link each city together in the permutation
                foreach (KeyValuePair<City, bool> cityBool in cityBools)
                {
                    City curStartCity = (City) cityBool.Key;
                    lastCity = curStartCity.Clone();

                    individualCityDistances.Add(startCity.Name, startCity.GetDistance(curStartCity));

                    startCity = curStartCity.Clone();
                }

                //link last city in permutation to this city
                City endCity = this.Clone();
                individualCityDistances.Add(startCity.Name, startCity.GetDistance(this));

                //store
                startingCityTotalDistances.Add(cityPermutation, individualCityDistances);
            }

            //find lowest route
            TotalIndividualCityDistancesSetBest(startingCityTotalDistances);
        }

        /// <summary>
        /// Adds all of the cities in a specific visit list together and stores the lowsest cost route
        /// </summary>
        /// <param name="startingCityTotalDistances"></param>
        private void TotalIndividualCityDistancesSetBest(Dictionary<string, Dictionary<string, int>> startingCityTotalDistances)
        {
            foreach (var startingCityTotalDistance in startingCityTotalDistances)
            {
                int totalDistance = 0;

                foreach (var city in startingCityTotalDistance.Value)
                {
                    totalDistance += city.Value; 
                }

                if (totalDistance < lowestDistance || lowestDistance == 0)
                {
                    lowestDistance = totalDistance;
                    lowestCostPermutation = startingCityTotalDistance.Key;
                }
            }
        }
     
        private Dictionary<City, bool> GetCityList(string cityPermutation)
        {
            Dictionary<City, bool> cities = new Dictionary<City, bool>();
            string[] curCityPermutation = cityPermutation.Split('-');

            foreach (string cityPerm in curCityPermutation)
            {
                foreach (City city in otherCities)
                {
                    if (city.NumberId.ToString() == cityPerm)
                    {
                        cities.Add(city, false);
                        break;
                    }
                }
            }

            return cities;
        }

        #endregion

        #region Add other cities/get permutations

        /// <summary>
        /// Adds all of the 'other' cities a person could travel to from here, the distance and other bits of information
        /// </summary>
        /// <param name="cities"></param>
        public void AddOtherCitysAndPermutationsDistances(List<City> cities)
        {
            AddOtherCities(cities);
            Permutation.Algorithm a = new Permutation.Algorithm(this.cityIds, false);
            this.cityPermutations = a.RunReturnAllPermutations();
            
            foreach (City otherCity in otherCities)
            {
                CityDistance distance = DetermineDirection(otherCity);
                this.cityDistances.Add(otherCity, distance);
            }
        }

        /// <summary>
        /// Gets distance from 'this' city to the specified city
        /// </summary>
        /// <param name="otherCity"></param>
        /// <returns></returns>
        private CityDistance DetermineDirection(City otherCity)
        {
            CityDistance distance = new CityDistance(this.X - otherCity.X, this.Y - otherCity.Y);

            distance = GetSteps(distance, otherCity);

            return distance;
        }

        /// <summary>
        /// Return the 'steps' (i.e. NW, SW, etc.) in a 2 dimensional space from one city to another
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="otherCity"></param>
        /// <returns></returns>
        private CityDistance GetSteps(CityDistance distance, City otherCity)
        {
            int xDiffCompare = 0;
            int yDiffCompare = 0;

            while (true)
            {
                if (yDiffCompare == distance.YDiff && xDiffCompare == distance.XDiff)
                    break;

                //W
                if (distance.XDiff > 0 && (distance.YDiff == yDiffCompare))
                {
                    distance.TravelDirections.Add(Enumerations.Direction.W.ToString());
                    xDiffCompare++;
                }
                //E
                else if (distance.XDiff < 0 && (distance.YDiff == yDiffCompare))
                {
                    distance.TravelDirections.Add(Enumerations.Direction.E.ToString());
                    xDiffCompare--;
                }
                //N
                else if (distance.YDiff > 0 && (distance.XDiff == xDiffCompare))
                {
                    distance.TravelDirections.Add(Enumerations.Direction.N.ToString());
                    yDiffCompare++;
                }
                //S
                else if (distance.YDiff < 0 && (distance.XDiff == xDiffCompare))
                {
                    distance.TravelDirections.Add(Enumerations.Direction.S.ToString());
                    yDiffCompare--;
                }
                //NE
                else if (distance.XDiff > 0 && distance.YDiff > 0)
                {
                    distance.TravelDirections.Add(Enumerations.Direction.NE.ToString());
                    xDiffCompare++;
                    yDiffCompare++;
                }
                //NW
                else if (distance.XDiff < 0 && distance.YDiff > 0)
                {
                    distance.TravelDirections.Add(Enumerations.Direction.NW.ToString());
                    xDiffCompare--;
                    yDiffCompare++;
                }
                //SE
                else if (distance.XDiff > 0 && distance.YDiff < 0)
                {
                    distance.TravelDirections.Add(Enumerations.Direction.SE.ToString());
                    xDiffCompare++;
                    yDiffCompare--;
                }
                //SW
                else if (distance.XDiff < 0 && distance.YDiff < 0)
                {
                    distance.TravelDirections.Add(Enumerations.Direction.SW.ToString());
                    xDiffCompare--;
                    yDiffCompare--;
                }
                else
                {
                    throw new System.Exception("Unknown direction");
                }
            }

            return distance;
        }

        /// <summary>
        /// Adds all other cities a person could travel to from here
        /// </summary>
        /// <param name="cities"></param>
        private void AddOtherCities(List<City> cities)
        {
            foreach (City city in cities)
            {
                if (!this.Name.Equals(city.Name))
                {
                    this.otherCities.Add(city);
                    this.cityIds += city.NumberId.ToString() + ",";
                }
            }

            this.cityIds = this.cityIds.Trim(',');
        }

        #endregion
    }
}
