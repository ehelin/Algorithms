using System;
using System.Collections.Generic;

namespace Algorithms.Permutation
{
    public class ComparisonTests
    {
        public void RunComparisonTests()
        {
            RunAlexanderBogomolynTest("0,0,0,0,0,0,0,0,0,0");
            Console.WriteLine("");
            RunUnversiteOfExeterTest("1,2,3,4,5,6,7,8,9,10");
            Console.WriteLine("");
            RunHomeGrownTest("1,2,3,4,5,6,7,8,9,10");
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