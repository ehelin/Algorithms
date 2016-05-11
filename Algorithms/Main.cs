using System;
using System.Collections.Generic;
using Algorithms.TravelingSalesman;

namespace Algorithms
{
    public class Main
    {
        public void Run()
        {
            RunTravelingSalesman();
            //RunGeneticAlgorithm();

            Console.Read();
        }

        private void RunTravelingSalesman()
        {            
            TravelingSalesman.Algorithm travelingSalesMan = new TravelingSalesman.Algorithm(20, 20, GetCities());
            travelingSalesMan.RunExample();
        }

        private List<City> GetCities()
        {
            List<City> city = new List<City>();

            city.Add(new City(2, 2));
            city.Add(new City(4, 4));
            city.Add(new City(5, 9));
            city.Add(new City(11, 15));
            city.Add(new City(19, 10));
            city.Add(new City(15, 4));

            return city;
        }

        private void RunGeneticAlgorithm()
        {

        }
    }
}
