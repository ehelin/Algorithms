using System;
using Algorithms.Permutation;

namespace Algorithms.Permutation.UnivExeter
{
    /// <summary>
    /// C# implementation of University of Exeter Permutation algorithm
    /// 
    /// http://www.bearcave.com/random_hacks/permute.html
    /// </summary>
    public class AlgorithmUE : Algorithm
    {
        public AlgorithmUE(string Input, bool ShowOutput)
        {
            this.Input = Input;
            this.ShowOutput = ShowOutput;
            Init();
        }

        public void Run()
        {
            Console.WriteLine("Starting University Of Exeter permutation for " + values.Length.ToString() + " - " + DateTime.Now.ToString());
            Console.WriteLine("Input sequence: " + this.Input);

            Permutate(values, 0);

            Console.WriteLine("Sequences That would have been printed - " + this.printCounts.ToString());
            Console.WriteLine("University Of Exeter permutation is done! " + DateTime.Now.ToString());
        }
        private void Permutate(int[] intValues, int startIndex)
        {
            if (startIndex == values.Length - 1)
            {
                if (this.ShowOutput)
                {
                    Print(intValues);
                }

                Console.Read();

                printCounts++;
            }
            else
            {
                for (int i = startIndex; i < values.Length; i++)
                {
                    int tmp = intValues[i];
                    intValues[i] = intValues[startIndex];
                    intValues[startIndex] = tmp;

                    int incrementedIndex = startIndex + 1;
                    Permutate(intValues, incrementedIndex);

                    intValues[startIndex] = intValues[i];
                    intValues[i] = tmp;
                }
            }
        }
    }
}
