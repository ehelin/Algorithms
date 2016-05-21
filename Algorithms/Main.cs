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

            city.Add(new City("City1", 2, 2));
            city.Add(new City("City2", 4, 4));
            city.Add(new City("City3", 6, 6));
            city.Add(new City("City4", 11, 15));
            city.Add(new City("City5", 19, 10));
            city.Add(new City("City6", 15, 4));

            return city;
        }

        private void RunGeneticAlgorithm()
        {

        }
    }
}
