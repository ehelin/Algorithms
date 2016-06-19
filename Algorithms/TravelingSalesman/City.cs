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
        Dictionary<string, TravelStep> lowestPathCity = null;

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
            TravelPoints = new List<Point>();
        }
        
        public void CalculateTravelPoints()
        {
            int runningX = this.X;
            int runningY = this.Y;
            int ctr = 0;
            City startCity = null;

            foreach (var distances in this.lowestPathCity)
            {
                if (ctr == 0)
                    startCity = this;
                else
                    startCity = GetCity(GetKey(ctr, this.lowestPathCity));

                City nextCity = GetCity(GetKey(ctr + 1, this.lowestPathCity));

                //hack!
                if (nextCity == null)
                    break;

                TravelStep dirNextCity = distances.Value;

                AddTravelingPoint(startCity, nextCity, dirNextCity);
                startCity = nextCity;

                ctr++;
            }

            //add travel points back to the original city
            TravelStep stepsToThis = startCity.GetDistance(this);
            AddTravelingPoint(startCity, this, stepsToThis);
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
        public TravelStep GetDistance(City destinationCity)
        {
            TravelStep steps = null;

            foreach (KeyValuePair<City, CityDistance> cityDistance in cityDistances)
            {
                if (cityDistance.Key.Name.Equals(destinationCity.Name))
                {
                    steps = new TravelStep(cityDistance.Value.TravelDirections.Count, 
                                           destinationCity.Name, 
                                           cityDistance.Value.XDiff, 
                                           cityDistance.Value.YDiff);
                    steps.Steps = cityDistance.Value.TravelDirections;
                    break;
                }
            }

            return steps;
        }

        #region Calculate Best Path

        //Calculate the least cost path to visit all other cities fromt this city
        public void CalculateBestPath()
        {
            Dictionary<string, Dictionary<string, TravelStep>>  startingCityTotalDistances = new Dictionary<string, Dictionary<string, TravelStep>>();
            
            //for each city list, get the travel cost list and store
            foreach (string cityPermutation in this.cityPermutations)
            {
                Dictionary<City, bool> cityBools = GetCityList(cityPermutation);
                City lastCity = null;

                //put this city as start city to the first one in the permutation
                Dictionary<string, TravelStep> individualCityDistances = new Dictionary<string, TravelStep>();
                List<string> curStartCityDistanceCities = new List<string>();
                City startCity = this.Clone();

                //link each city together in the permutation
                foreach (KeyValuePair<City, bool> cityBool in cityBools)
                {
                    City curStartCity = (City) cityBool.Key;
                    lastCity = curStartCity.Clone();

                    TravelStep steps = startCity.GetDistance(curStartCity);

                    individualCityDistances.Add(startCity.Name, steps);

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
        
        private void TotalIndividualCityDistancesSetBest(Dictionary<string, Dictionary<string, TravelStep>> startingCityTotalDistances)
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

            lowestPathCity = startingCityTotalDistances[lowestCostPermutation];
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
        private string GetKey(int index, Dictionary<string, TravelStep> values)
        {
            string key = string.Empty;
            int ctr = 0;

            foreach (KeyValuePair<string, TravelStep> value in values)
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
        private void AddTravelingPoint(City cityOne, City cityTwo, TravelStep travelSteps)
        {
            int xRunning = cityOne.X;
            int yRunning = cityOne.Y;

            foreach (string travelStep in travelSteps.Steps)
            {
                //W
                if (travelStep == Enumerations.Direction.W.ToString())
                {
                    xRunning--;
                }
                //E
                else if (travelStep == Enumerations.Direction.E.ToString())
                {
                    xRunning++;
                }
                //N
                else if (travelStep == Enumerations.Direction.N.ToString())
                {
                    yRunning--;
                }
                //S
                else if (travelStep == Enumerations.Direction.S.ToString())
                {
                    yRunning++;
                }
                //NE
                else if (travelStep == Enumerations.Direction.NE.ToString())
                {
                    xRunning--;
                    yRunning--;
                }
                //NW
                else if (travelStep == Enumerations.Direction.NW.ToString())
                {
                    xRunning++;
                    yRunning--;
                }
                //SE
                else if (travelStep == Enumerations.Direction.SE.ToString())
                {
                    xRunning--;
                    yRunning++;
                }
                //SW
                else if (travelStep == Enumerations.Direction.SW.ToString())
                {
                    xRunning++;
                    yRunning++;
                }
                else
                {
                    throw new System.Exception("Unknown direction");
                }

                this.TravelPoints.Add(new Point(xRunning, yRunning));
            }
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

        #endregion

        #region Add other cities/get permutations

        /// <summary>
        /// Adds all of the 'other' cities a person could travel to from here, the distance and other bits of information
        /// </summary>
        /// <param name="cities"></param>
        public void AddOtherCitysAndPermutationsDistances(List<City> cities)
        {
            AddOtherCities(cities);
            Permutation.HomeGrown.AlgorithmHG a = new Permutation.HomeGrown.AlgorithmHG(this.cityIds, false);
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
