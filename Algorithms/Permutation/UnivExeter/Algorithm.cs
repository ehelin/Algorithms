using System;

namespace Algorithms.Permutation.UnivExeter
{
    /// <summary>
    /// C# implementation of University of Exeter Permutation algorithm
    /// 
    /// http://www.bearcave.com/random_hacks/permute.html
    /// </summary>
    public class Algorithm
    {
        private int[] values;
        private bool showOutput;

        public Algorithm(string input, bool showOutput)
        {
            string[] strValues = input.Split(',');
            values = new int[strValues.Length];

            for(int ctr = 0; ctr< strValues.Length; ctr++)
            {
                values[ctr] = Convert.ToInt32(strValues[ctr]);
            }

            this.showOutput = showOutput;
        }

        public void Run()
        {
            Console.WriteLine("Starting University Of Exeter permutation for " + values.Length.ToString() + " - " + DateTime.Now.ToString());

            int denominator = sizeof(int);
            int numerator = values.Length * denominator;
            Permutate(values, 0, numerator / denominator);

            Console.WriteLine("Sequences That would have been printed - " + this.printCounts.ToString());

            Console.WriteLine("University Of Exeter permutation is done! " + DateTime.Now.ToString());
        }
        private long printCounts = 0;
        private void Permutate(int[] intValues, int startIndex, int n)
        {
            if (startIndex == n - 1)
            {
                if (this.showOutput)
                {
                    Print(intValues);
                }

                printCounts++;
            }
            else
            {
                for (int i = startIndex; i < n; i++)
                {
                    int tmp = intValues[i];

                    intValues[i] = intValues[startIndex];
                    intValues[startIndex] = tmp;
                    Permutate(intValues, startIndex + 1, n);
                    intValues[startIndex] = intValues[i];
                    intValues[i] = tmp;
                }
            }
        }

        private void Print(int[] intValues)
        {
            string line = string.Empty;

            foreach (int value in intValues)
            {
                line += value.ToString() + ",";
            }

            line = line.Trim(',');

            Console.WriteLine(line);
        }
     }
}
