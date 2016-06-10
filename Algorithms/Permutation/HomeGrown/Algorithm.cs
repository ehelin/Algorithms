using System;
using System.Collections.Generic;

namespace Algorithms.Permutation.HomeGrown
{
    /// <summary>
    /// Algorithm that returns all possible permutations (without repeating values) for a supplied number of 
    /// characters.  It may be someone else's, but I purposely did not research this prior to starting when I thought
    /// I recognized a pattern on how this could be done.  Plus, when I do something from scratch, I remember it longer :)
    /// 
    /// The algorithm sorts all values prior to starting.  Then, it flips the last two values.  After that, it increments
    /// the next value in the next position to the left and repeats after it sorts everything to the right of the current
    /// increment column.  Once it goes to the maximum value possible for this increment column, it increments the next 
    /// column and repeats.
    /// 
    /// <insert more detail>
    /// </summary>
    public class Algorithm
    {
        /// <summary>
        /// List of values to be processed
        /// </summary>
        private ValuesList valuesList;

        /// <summary>
        /// List of all possible permutations of other cities
        /// </summary>
        private List<string> permutations;

        private long endCnt = 0;
        private bool showDisplay = false;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="input"></param>
        /// <param name="showDisplay"></param>
        public Algorithm(string input, bool showDisplay)
        {
            this.valuesList = new ValuesList(input);
            this.showDisplay = showDisplay;
            this.permutations = new List<string>();
        }
        
        public void Run()
        {
            string result = string.Empty;

            RunPermutation();

            Console.WriteLine("Factorial for " + valuesList.Values.Count.ToString() + " is " + endCnt.ToString());
            Console.WriteLine("Press key when ready for next!");
            while (result != "'")
            {
                result = Console.ReadLine();
            }
        }
        public string RunReturnValue()
        {
            string result = RunPermutation();

            return result;
        }
        public List<string> RunReturnAllPermutations()
        {
            RunPermutation();

            return this.permutations;
        }
        public long RunPrintPermutationCount()
        {
            RunPermutation();

            return valuesList.DisplayCtr;
        }

        private string RunPermutation()
        {
            endCnt = Utilities.CalculateFactorial(valuesList.Values.Count);
            string result = string.Empty;

            while (valuesList.DisplayCtr < endCnt)
            {
                valuesList.Display(showDisplay);
                //this.permutations.Add(valuesList.GetLastDisplay());

                valuesList.SetNextOperation();
                valuesList = PerformListOperation(valuesList);
            }

            result = valuesList.GetLastDisplay();

            return result;
        }
        private ValuesList PerformListOperation(ValuesList valuesList)
        {
            if (!valuesList.ProcessingDone && valuesList.Operation == 1)
            {
                valuesList.Values = HandleSimpleSwap(valuesList.Values);
            }
            else if (!valuesList.ProcessingDone)
            {
                valuesList.Values = this.IncrementPosition(valuesList.Values, valuesList.Operation + 1);
            }
           
            return valuesList;
        }
        private List<int> HandleSimpleSwap(List<int> values)
        {
            int position = values.Count - 1;
            int tmp = values[position];
            values[position] = values[position - 1];
            values[position - 1] = tmp;

            return values;
        }
        private List<int> IncrementPosition(List<int> values, int incrementPosition)
        {
            List<int> valuesTmp = new List<int>();

            //create list of all items to right of increment position and sort
            int positionCtr = values.Count - incrementPosition;
            while (positionCtr < values.Count)
            {
                valuesTmp.Add(values[positionCtr]);
                positionCtr++;
            }
            valuesTmp = Utilities.Sort(valuesTmp);

            //get value to increment, increase it to next biggest number and remove that from the list to sort, sort and add
            int valueToIncrement = values[values.Count - incrementPosition];
            int incrementedValue = Utilities.GetNextBiggerNumber(valuesTmp, valueToIncrement);
            valuesTmp.Remove(incrementedValue);
            valuesTmp = Utilities.Sort(valuesTmp);
            values[values.Count - incrementPosition] = incrementedValue;

            //add sorted values to right of the increment value
            positionCtr = (values.Count - incrementPosition) + 1;
            int sortCtr = 0;
            while (positionCtr < values.Count)
            {
                values[positionCtr] = valuesTmp[sortCtr];
                positionCtr++;
                sortCtr++;
            }

            return values;
        }
    }
}
