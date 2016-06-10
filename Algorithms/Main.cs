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
            //RunAlexanderBogomolynPermutation();
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
            Permutation.UnivExeter.AlgorithmUE a = new Permutation.UnivExeter.AlgorithmUE("1,2,3,5", true);
            a.Run();

            Console.Read();
        }

        private void RunAlexanderBogomolynPermutation()
        {
            Permutation.UnivExeter.AlgorithmAB a = new Permutation.UnivExeter.AlgorithmAB("0,0,0,0", true);
            a.Run();

            Console.Read();
        }

        private void RunPermutation(string characters)
        {
            Console.WriteLine("Starting permutation for " + characters + " - " + DateTime.Now.ToString());

            Permutation.HomeGrown.AlgorithmHG a = new Permutation.HomeGrown.AlgorithmHG(characters, true);
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
