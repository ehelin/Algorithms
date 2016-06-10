using System;

namespace Algorithms.Permutation
{
    public class ComparisonTests
    {
        public void RunComparisonTests()
        {
            //RunHomeGrownTest("1,2");
            //RunUnversiteOfExeterTest("1,2");


            //RunHomeGrownTest("1,2,3,4,5,6,7,8,9,10,11");
            RunUnversiteOfExeterTest("1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20");
            
            //RunHomeGrownTest("5,4,3,2,1");
            //RunUnversiteOfExeterTest("5,4,3,2,1");
        }


        private void RunHomeGrownTest(string characters)
        {
            Console.WriteLine("Home Grown Test Input: " + characters + " - " + DateTime.Now.ToString());
            Algorithms.Permutation.HomeGrown.Algorithm a = new Algorithms.Permutation.HomeGrown.Algorithm(characters, true);
            long count = a.RunPrintPermutationCount();

            Console.WriteLine("Permutation count - " + count.ToString());
            Console.WriteLine("Test Done! " + DateTime.Now.ToString());
        }

        private void RunUnversiteOfExeterTest(string characters)
        {
            //Console.WriteLine("University Of Exeter Test Input: " + characters + " - " + DateTime.Now.ToString());
            Algorithms.Permutation.UnivExeter.Algorithm a = new Algorithms.Permutation.UnivExeter.Algorithm(characters, false);
            a.Run();
        }
    }
}