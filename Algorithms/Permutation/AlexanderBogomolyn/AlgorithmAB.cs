using System;
using Algorithms.Permutation;

namespace Algorithms.Permutation.UnivExeter
{
    /// <summary>
    /// C# implementation of Alexander Bogomolyn Permutation algorithm
    /// 
    /// http://www.bearcave.com/random_hacks/permute.html
    /// </summary>
    public class AlgorithmAB : Algorithm
    {
        public AlgorithmAB(string Input, bool ShowOutput)
        {
            this.Input = Input;
            this.ShowOutput = ShowOutput;
            Init();
        }

        public void Run()
        {
            DateTime start = DateTime.Now;

            Console.WriteLine("Starting Alexander Bogomolyn permutation for " + values.Length.ToString());
            Console.WriteLine("Input sequence: " + this.Input);

            Permutate(values, 0);

            Console.WriteLine("Sequences That would have been printed - " + this.printCounts.ToString());
            Console.WriteLine("Alexander Bogomolyn permutation is done! " + Utilities.GetElaspedTime(start, DateTime.Now));
        }

        private static int level = -1;
        private void Permutate(int[] intValues, int startIndex)
        {
            level = level + 1;
            intValues[startIndex] = level;

            if (level == intValues.Length)
            {
                Print(intValues);
                printCounts++;
            }
            else
            {
                for (int ctr = 0; ctr < intValues.Length; ctr++)
                {
                    if (intValues[ctr] == 0)
                    {
                        Permutate(intValues, ctr);
                    }
                }
            }

            level = level - 1;
            intValues[startIndex] = 0;
        }
    }
}
