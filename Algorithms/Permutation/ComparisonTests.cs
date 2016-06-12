using System;
using System.Collections.Generic;

namespace Algorithms.Permutation
{
    public class ComparisonTests
    {
        public void RunComparisonTests()
        {
            //RunAlexanderBogomolynTest("0,0,0,0,0,0,0,0,0,0,0");
            //Console.WriteLine("");

            //RunUnversiteOfExeterTest("1,2,3,4,5,6,7,8,9,10,11");
            //Console.WriteLine("");

            //RunHomeGrownTest("1,2,3,4,5,6,7,8,9,10,11");
            //Console.WriteLine("");

            RunAlexanderBogomolynTest("0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0");
            Console.WriteLine("");

            RunUnversiteOfExeterTest("1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50");
            Console.WriteLine("");

            RunHomeGrownTest("1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50");
            Console.WriteLine("");
        }


        private void RunHomeGrownTest(string characters)
        {
            DateTime start = DateTime.Now;
            Console.WriteLine("Home Grown Test Input: " + characters);

            Algorithms.Permutation.HomeGrown.AlgorithmHG a = new Algorithms.Permutation.HomeGrown.AlgorithmHG(characters, false);
            long count = a.RunPrintPermutationCount();

            Console.WriteLine("Permutation count - " + count.ToString());
            Console.WriteLine("Test Done! " + Utilities.GetElaspedTime(start, DateTime.Now));
        }
        private void RunUnversiteOfExeterTest(string characters)
        {
            Algorithms.Permutation.UnivExeter.AlgorithmUE a = new Algorithms.Permutation.UnivExeter.AlgorithmUE(characters, false);
            a.Run();
        }

        private void RunAlexanderBogomolynTest(string characters)
        {
            Permutation.UnivExeter.AlgorithmAB a = new Permutation.UnivExeter.AlgorithmAB(characters, false);
            a.Run();
        }
    }
}