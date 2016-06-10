using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class Main
    {
        public void Run()
        {
            RunComparisonTests();
            //RunUniversityExeterPermutation();
            //RunPermutation("4,2,3,1");
            //RunTravelingSalesman();
            //RunGeneticAlgorithm();

            Console.Read();
        }

        public void RunComparisonTests()
        {
            Permutation.ComparisonTests ct = new Permutation.ComparisonTests();
            ct.RunComparisonTests();

            Console.Read();
        }

        private void RunUniversityExeterPermutation()
        {
            Permutation.UnivExeter.Algorithm a = new Permutation.UnivExeter.Algorithm("1,2,3,4,5,6,7,8,9,10", true);
            a.Run();

            Console.Read();
        }

        private void RunPermutation(string characters)
        {
            Console.WriteLine("Starting permutation for " + characters + " - " + DateTime.Now.ToString());

            Permutation.HomeGrown.Algorithm a = new Permutation.HomeGrown.Algorithm(characters, true);
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
