using Algorithms.TravelingSalesman.Dto;
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
        public Dictionary<City, CityDistance> StepsToOtherCities;

        /// <summary>
        /// points to display on grid
        /// </summary>
        public List<Point> TravelPoints { get; set; }

        /// <summary>
        /// List of ids for permutation algorithm (i.e. other cities)
        /// </summary>
        private string cityIds;

        /// <summary>
        /// List of other cities one can visit from this city
        /// </summary>
        private List<City> otherCities;

        /// <summary>
        /// List of all possible city permutations
        /// </summary>
        private List<string> cityPermutations;

        /// <summary>
        /// Lowest permutation, distance and detailed steps
        /// </summary>
        private string lowestCostPermutation = string.Empty;
        private int lowestDistance = 0;
        Dictionary<string, CityDistance> lowestPathCity = null;

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
            StepsToOtherCities = new Dictionary<City, CityDistance>();
            otherCities = new List<City>();
            cityPermutations = new List<string>();
            TravelPoints = new List<Point>();
        }

        //TODO - comment these public methods
        public City Clone()
        {
            City newCity = new City(this.Name, this.X, this.Y, this.NumberId);
            newCity.AddedToGrid = this.AddedToGrid;

            //foreach (var steps in StepsToOtherCities)
            //{
            //    newCity.StepsToOtherCities.Add(steps.Key, steps.Value);
            //}

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
        public void CalculateBestPath()
        {
            Dictionary<string, Dictionary<string, CityDistance>>  startingCityTotalDistances = new Dictionary<string, Dictionary<string, CityDistance>>();

            //for each city list, get the travel cost list and store lowest cost path details
            foreach (string cityPermutation in this.cityPermutations)
            {
                Dictionary<City, bool> cityBools = GetCityList(cityPermutation);
                City lastCity = null;

                //put this city as start city to the first one in the permutation
                Dictionary<string, CityDistance> individualCityDistances = new Dictionary<string, CityDistance>();
                List<string> curStartCityDistanceCities = new List<string>();
                City startCity = Clone();

                //link each city together in the permutation
                foreach (KeyValuePair<City, bool> cityBool in cityBools)
                {
                    City curStartCity = (City) cityBool.Key;
                    lastCity = curStartCity.Clone();
                    
                    CityDistance cityDistance = startCity.CalculateDistance(startCity.Y - curStartCity.Y, startCity.X - curStartCity.X, startCity, curStartCity, this);
                    individualCityDistances.Add(startCity.Name, cityDistance);

                    startCity = curStartCity.Clone();
                }

                //link last city in permutation to this city
                City endCity = this.Clone();
                individualCityDistances.Add(startCity.Name, startCity.CalculateDistance(startCity.Y - this.Y, startCity.X - this.X, startCity, this, this));

                //store
                startingCityTotalDistances.Add(cityPermutation, individualCityDistances);
            }

            //find lowest route
            TotalIndividualCityDistancesSetBest(startingCityTotalDistances);
        }
        public int GetUniquePathCount()
        {
            string curName = string.Empty;
            int uniquePathCount = 0;

            foreach (Point point in TravelPoints)
            {
                if (point.Name != curName)
                {
                    curName = point.Name;
                    uniquePathCount++;
                }
            }

            return uniquePathCount;
        }

        //TODO - comment these private methods when done refactoring
        private void TotalIndividualCityDistancesSetBest(Dictionary<string, Dictionary<string, CityDistance>> startingCityTotalDistances)
        {
            foreach (var startingCityTotalDistance in startingCityTotalDistances)
            {
                int totalDistance = 0;

                foreach (var city in startingCityTotalDistance.Value)
                {
                    totalDistance += city.Value.Distance; 
                }

                if (totalDistance < lowestDistance || lowestDistance == 0)
                {
                    lowestDistance = totalDistance;
                    lowestCostPermutation = startingCityTotalDistance.Key;
                }
            }

            //store and capture this paths travel points
            lowestPathCity = startingCityTotalDistances[lowestCostPermutation];
            foreach (KeyValuePair<string, CityDistance> lowestPath in lowestPathCity)
            {
                foreach (Point point in lowestPath.Value.TravelPoints)
                {
                    this.TravelPoints.Add(point);
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
        private string GetKey(int index, Dictionary<string, CityDistance> values)
        {
            string key = string.Empty;
            int ctr = 0;

            foreach (KeyValuePair<string, CityDistance> value in values)
            {
                if (ctr == index)
                {
                    key = value.Key;
                    break;
                }

                ctr++;
            }

            return key;
        }
        private City GetCity(string cityName)
        {
            City city = null;

            foreach (City otherCity in otherCities)
            {
                if (otherCity.Name == cityName)
                {
                    city = otherCity;
                    break;
                }
            }

            return city;
        }
        public void AddOtherCitiesPermutations(List<City> cities)
        {
            AddOtherCities(cities);
            Permutation.HomeGrown.AlgorithmHG a = new Permutation.HomeGrown.AlgorithmHG(this.cityIds, false);
            this.cityPermutations = a.RunReturnAllPermutations();
        }
        private bool IsCityPoint(int x, int y)
        {
            bool cityPoint = false;

            if (this.X == x && this.Y == y)
                cityPoint = true;
            else
            {
                foreach (City city in otherCities)
                {
                    if (city.X == x && city.Y == y && !cityPoint)
                    {
                        cityPoint = true;
                        break;
                    }
                }
            }

            return cityPoint;
        }
        private CityDistance CalculateDistance(int yDiff, int xDiff, City startCity, City destinationCity, City beginningCity)
        {
            CityDistance cityDistance = new CityDistance();
            cityDistance.CityName = destinationCity.Name;

            //x,y comparison values to this city and the other city running count
            int xDiffCompare = 0;
            int yDiffCompare = 0;

            //list each 2 d movement point for grid display
            int xRunning = this.X;
            int yRunning = this.Y;

            throw new System.Exception("Find way to not let a movement point go through a city");
            
            while (true)
            {
                if (yDiffCompare == yDiff && xDiffCompare == xDiff)
                    break;

                //W
                if (xDiff > 0 && (yDiff == yDiffCompare))
                {
                    xDiffCompare++;
                    xRunning--;
                }
                //E
                else if (xDiff < 0 && (yDiff == yDiffCompare))
                {
                    xDiffCompare--;
                    xRunning++;
                }
                //N
                else if (yDiff > 0 && (xDiff == xDiffCompare))
                {
                    yDiffCompare++;
                    yRunning--;
                }
                //S
                else if (yDiff < 0 && (xDiff == xDiffCompare))
                {
                    yDiffCompare--;
                    yRunning++;
                }
                //NE
                else if (xDiff > 0 && yDiff > 0)
                {
                    xDiffCompare++;
                    yDiffCompare++;
                    xRunning--;
                    yRunning--;
                }
                //NW
                else if (xDiff < 0 && yDiff > 0)
                {
                    xDiffCompare--;
                    yDiffCompare++;
                    xRunning++;
                    yRunning--;
                }
                //SE
                else if (xDiff > 0 && yDiff < 0)
                {
                    xDiffCompare++;
                    yDiffCompare--;
                    xRunning--;
                    yRunning++;
                }
                //SW
                else if (xDiff < 0 && yDiff < 0)
                {
                    xDiffCompare--;
                    yDiffCompare--;
                    xRunning++;
                    yRunning++;
                }
                else
                {
                    throw new System.Exception("Unknown direction");
                }

                cityDistance.Distance++;
                cityDistance.TravelPoints.Add(new Point(xRunning, yRunning, startCity.Name + "-" + destinationCity.Name));
            }

            return cityDistance;
        }
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
    }
}
