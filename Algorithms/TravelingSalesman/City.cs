using System.Collections;
using System.Collections.Generic;

namespace Algorithms.TravelingSalesman
{
    public class City
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool AddedToGrid { get; set; }
        public Dictionary<City, CityDistance> cityDistances;
        public Dictionary<string, Dictionary<string, int>> startingCityTotalDistances;
        public Dictionary<string, int> cityTotalDistances;

        public City(string Name, int X, int Y)
        {
            this.Name = Name;
            this.X = X;
            this.Y = Y;
            cityDistances = new Dictionary<City, CityDistance>();
            startingCityTotalDistances = new Dictionary<string, Dictionary<string, int>>();
            cityTotalDistances = new Dictionary<string, int>();
        }

        public City Clone()
        {
            City newCity = new City(this.Name, this.X, this.Y);
            newCity.AddedToGrid = this.AddedToGrid;

            foreach (var cityDistance in cityDistances)
            {
                newCity.cityDistances.Add(cityDistance.Key, cityDistance.Value);
            }

            return newCity;
        }

        public override string ToString()
        {
            string result = "Name: " + this.Name + ", X: " + this.X.ToString() + ", this.Y: " + Y.ToString();

            return result;
        }

        public int GetDistance(City destinationCity)
        {
            int steps = 0;

            foreach (KeyValuePair<City, CityDistance> cityDistance in cityDistances)
            {
                if (cityDistance.Key.Equals(destinationCity))
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
            Dictionary<City, bool> cityBools = GetCityList();
            int maxIterations = this.cityDistances.Count;
            int iterationCtr = 0;

            while (iterationCtr < maxIterations)
            {
                Dictionary<string, int> individualCityDistances = new Dictionary<string, int>();
                List<string> curStartCityDistanceCities = new List<string>();
                City curStartCity = GetNextCityToStart(cityBools);
                City startCity = curStartCity.Clone();

                individualCityDistances.Add(this.Name, this.GetDistance(curStartCity));
                //individualCityDistances.Add(curStartCity.Name, this.GetDistance(curStartCity));
                //int totalDistanceForThisStartCity = this.GetDistance(curStartCity);

                if (curStartCity == null)
                    break;

                foreach (KeyValuePair<City, CityDistance> cityDistance in cityDistances)
                {
                    bool cityAlreadyProcessed = false;
                    City curCity = cityDistance.Key;
                    if (curCity.Name.Equals(curStartCity.Name))
                        continue;

                    if (curCity.Name.Equals(startCity.Name))
                        continue;

                    foreach (string city in curStartCityDistanceCities)
                    {
                        if (curCity.Name.Equals(city))
                        {
                            cityAlreadyProcessed = true;
                            break;
                        }
                    }

                    if (cityAlreadyProcessed)
                        continue;

                    //int distanceFromCityToCity = curStartCity.GetDistance(curCity);

                    individualCityDistances.Add(curStartCity.Name, this.GetDistance(curCity));
                    //individualCityDistances.Add(curCity.Name, this.GetDistance(curCity));
                    //totalDistanceForThisStartCity += distanceFromCityToCity;

                    curStartCityDistanceCities.Add(curCity.Name);
                    curStartCity = curCity;
                }

                //totalDistanceForThisStartCity += curStartCity.GetDistance(this);  //get the distance from last city back to original

                individualCityDistances.Add(curStartCity.Name, curStartCity.GetDistance(this));
                //individualCityDistances.Add(this.Name, curStartCity.GetDistance(this));
                //startingCityTotalDistances.Add(startCity.Name, totalDistanceForThisStartCity);
                startingCityTotalDistances.Add(startCity.Name, individualCityDistances);

                SetCityIterationRun(startCity, cityBools);
                iterationCtr++;
            }

            TotalIndividualCityDistances();
        }

        private void TotalIndividualCityDistances()
        {
            foreach (var startingCityTotalDistances in this.startingCityTotalDistances)
            {
                int totalDistance = 0;

                foreach (var city in startingCityTotalDistances.Value)
                {
                    totalDistance += city.Value; 
                }

                this.cityTotalDistances.Add(startingCityTotalDistances.Key, totalDistance);
            }
        }

        //TODO - seems bassackwards...I want to update a city as having been run first...must be a better way :(
        private void SetCityIterationRun(City city, Dictionary<City, bool> cityBools)
        {
            KeyValuePair<City, bool> curCityBool = new KeyValuePair<City, bool>();

            foreach (KeyValuePair<City, bool> cityBool in cityBools)
            {
                if (city.Name.Equals(cityBool.Key.Name))
                {
                    curCityBool = cityBool;
                    break;
                }
            }

            cityBools.Remove(curCityBool.Key);            
            cityBools.Add(curCityBool.Key, true);
        }

        private City GetNextCityToStart(Dictionary<City, bool> cityBools)
        {
            City cityToStart = null;

            foreach (KeyValuePair<City, bool> cityBool in cityBools)
            {
                if (cityBool.Value == false)
                {
                    cityToStart = (City)cityBool.Key;
                    break;
                }
            }

            return cityToStart;
        }

        private Dictionary<City, bool> GetCityList()
        {
            Dictionary<City, bool> cities = new Dictionary<City, bool>();

            foreach (KeyValuePair<City, CityDistance> cityDistance in cityDistances)
            {
                City curCity = (City)cityDistance.Key;
                cities.Add(curCity, false);
            }

            return cities;
        }

        #endregion

        #region Calculate All Paths

        //x/y different, but same number - diagonal move
        //x is 0, we are going up or down
        //y is 0, we are going left or right
        //x/y different and don't match, complicated move

        //Calculate all paths from this city to the others and record approach
        public void CalculateAllPaths(List<City> cities)
        {
            foreach (City otherCity in cities)
            {
                if (this.Name.Equals(otherCity.Name))
                    continue;

                CityDistance distance = DetermineDirection(otherCity);
                this.cityDistances.Add(otherCity, distance);
            }
        }

        private CityDistance DetermineDirection(City otherCity)
        {
            CityDistance distance = new CityDistance(this.X - otherCity.X, this.Y - otherCity.Y);

            distance = GetSteps(distance, otherCity);

            return distance;
        }
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

        #endregion
    }
}
