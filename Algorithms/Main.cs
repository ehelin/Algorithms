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
            //RunTmp("1,2");
            //RunTmp("11,222");

            //RunTmp("1,3,2");
            //RunTmp("122,35,12");

            //RunTmp("1,4,3,2");
            //RunTmp("231,44,253,2");

            //RunTmp("1,4,5,3,2");
            //RunTmp("21,4,524,3,12");

            //RunTmp("6,1,4,5,3,2");
            //RunTmp("21,4,524,3,12,235");

            //RunTmp("6,7,1,4,5,3,2");
            //RunTmp("6,74,11,4,5,1451,2");

            //RunTmp("6,7,1,4,5,3,2,8");
            //RunTmp("6,7,12,4,53,3124,2,86");

            //RunTmp("6,7,1,4,5,9,3,2,8");
            //RunTmp("6,1247,13,4,5,1249,3,212,81");

            RunTmp("6,7,1,10,4,5,9,3,2,8");
            //RunTmp("62532,7,1,1230,42,5,9,325,2,81231");

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
