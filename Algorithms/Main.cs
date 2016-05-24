using System;
using System.Collections.Generic;
using Algorithms.TravelingSalesman;
using Algorithms.Permutation;

namespace Algorithms
{
    public class Main
    {
        public void Run()
        {
            RunPermutationAlgorithm();
            //RunTravelingSalesman();
            //RunGeneticAlgorithm();

            Console.Read();
        }

        private void RunPermutationAlgorithm()
        {
            string characters = "143652";
            Permutation.Algorithm permutation = new Permutation.Algorithm(characters);
            permutation.RunExample();
        }

        private void RunTravelingSalesman()
        {
            //TravelingSalesman.Algorithm travelingSalesMan = new TravelingSalesman.Algorithm(20, 20, GetCities());
            //travelingSalesMan.RunExample();
            //TravelingSalesman.Algorithmv2 travelingSalesMan = new TravelingSalesman.Algorithmv2(20, 20, GetCities());
            //travelingSalesMan.RunExample();
        }

        private void RunGeneticAlgorithm()
        {

        }
    }
}
