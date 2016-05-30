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
            RunTmp("1,2");
            //RunTmp("11,222");
            RunTmp("1,3,2");
            //RunTmp("122,35,12");
            RunTmp("1,4,3,2");
            //RunTmp("231,44,253,2");
            RunTmp("1,4,5,3,2");
            //RunPermutationAlgorithm("1,4,3,2");
            //RunPermutationAlgorithm("1,4,3,5,2");
            //RunPermutationAlgorithm("1,4,3,6,5,2");
            //RunPermutationAlgorithm("1,4,3,6,5,2,7");
            //RunPermutationAlgorithm("1,4,3,6,8,5,2,7");
            //RunPermutationAlgorithm("1,4,9,3,6,8,5,2,7");
            //RunPermutationAlgorithm("1,4,9,3,6,10,8,5,2,7");
            //RunPermutationAlgorithm("1,4,11,9,3,6,10,8,5,2,7");
            //RunTravelingSalesman();
            //RunGeneticAlgorithm();

            Console.Read();
        }

        private void RunTmp(string characters)
        {
            Permutation.Tmp tmp = new Permutation.Tmp(characters);
            tmp.Run();
        }

        private void RunPermutationAlgorithm(string characters)
        {
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
