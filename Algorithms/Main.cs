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
            //TravelingSalesman.Algorithm travelingSalesMan = new TravelingSalesman.Algorithm(20, 20, GetCities());
            //travelingSalesMan.RunExample();
            TravelingSalesman.Algorithmv2 travelingSalesMan = new TravelingSalesman.Algorithmv2(20, 20, GetCities());
            travelingSalesMan.RunExample();
        }


        private void RunGeneticAlgorithm()
        {

        }
    }
}
