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
            DateTime start = DateTime.Now;

            //Console.WriteLine("Starting University Of Exeter permutation for " + values.Length.ToString());
            //Console.WriteLine("Input sequence: " + this.Input);

            //Print(this.values);
            Permutate(values, 0);

            //Console.WriteLine("Sequences That would have been printed - " + this.printCounts.ToString());
            //Console.WriteLine("University Of Exeter permutation is done! " + Utilities.GetElaspedTime(start, DateTime.Now));
        }

        private void Permutate(int[] intValues, int startIndex)
        {
            if (startIndex == values.Length - 1)
            {
                //Print(intValues);
                printCounts++;
            }
            else
            {
                for (int i = startIndex; i < values.Length; i++)
                {
                    int tmp = intValues[i];
                    intValues[i] = intValues[startIndex];
                    intValues[startIndex] = tmp;

                    if (intValues[i] != intValues[startIndex] || intValues[startIndex] != tmp)
                    {
                        ShowSwapPositions();
                        Print(intValues);
                    }

                    int incrementedIndex = startIndex + 1;
                    Permutate(intValues, incrementedIndex);
                    
                    intValues[startIndex] = intValues[i];
                    intValues[i] = tmp;

                    if (intValues[startIndex] != intValues[i] || intValues[i] != tmp)
                    {
                        ShowSwapPositions();
                        Print(intValues);
                    }
                }
            }
        }
    }
}
