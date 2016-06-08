using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class Main
    {
        public void Run()
        {
            //RunPermutation("6,7,1,10,4");
            RunTravelingSalesman();
            //RunGeneticAlgorithm();

            Console.Read();
        }

        private void RunPermutation(string characters)
        {
            Console.WriteLine("Starting permutation for " + characters + " - " + DateTime.Now.ToString());

            Permutation.Algorithm a = new Permutation.Algorithm(characters, true);
            List<string> permutations = a.RunReturnAllPermutations();

            Console.WriteLine("Done with permutation for " + characters + " - " + DateTime.Now.ToString());
            Console.WriteLine("Total permutations: " + permutations.Count.ToString());
        }
        
        private void RunTravelingSalesman()
        {
            TravelingSalesman.Algorithm travelingSalesMan = new TravelingSalesman.Algorithm(20, 20, Utilities.GetCities());
            travelingSalesMan.RunExample();
        }

        private void RunGeneticAlgorithm()
        {

        }
    }
}
