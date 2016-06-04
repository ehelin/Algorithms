using System;
using System.Collections.Generic;

namespace Algorithms.Permutation
{
    public class Algorithm
    {
        private ValuesList valuesList;
        private long endCnt = 0;
        private bool showDisplay = false;

        public Algorithm(string input, bool showDisplay)
        {
            this.valuesList = new ValuesList(input);
            this.showDisplay = showDisplay;
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

        private string RunPermutation()
        {
            endCnt = Utilities.CalculateFactorial(valuesList.Values.Count);
            string result = string.Empty;

            while (valuesList.DisplayCtr < endCnt)
            {
                valuesList.Display(showDisplay);
                valuesList.SetNextOperation();

                valuesList = PerformListOperation(valuesList);
            }

            result = valuesList.GetLastDisplay();

            return result;
        }
        private ValuesList PerformListOperation(ValuesList valuesList)
        {
            if (!valuesList.ProcessingDone && valuesList.Operation == ListOperations.FLIP_LAST_TWO_LIST_MEMBERS)
            {
                valuesList.Values = HandleSimpleSwap(valuesList.Values);
            }

            else if (!valuesList.ProcessingDone && valuesList.Operation == ListOperations.INCREMENT_POSITION_TWO_REPEAT_SUB_OPERATIONS)
            {
                valuesList.Values = this.IncrementPosition(valuesList.Values, ListOperationIndexes.INCREMENT_POSITION_TWO_INDEX);
            }

            else if (!valuesList.ProcessingDone && valuesList.Operation == ListOperations.INCREMENT_POSITION_THREE_REPEAT_SUB_OPERATIONS)
            {
                valuesList.Values = this.IncrementPosition(valuesList.Values, ListOperationIndexes.INCREMENT_POSITION_THREE_INDEX);
            }

            else if (!valuesList.ProcessingDone && valuesList.Operation == ListOperations.INCREMENT_POSITION_FOUR_REPEAT_SUB_OPERATIONS)
            {
                valuesList.Values = this.IncrementPosition(valuesList.Values, ListOperationIndexes.INCREMENT_POSITION_FOUR_INDEX);
            }

            else if (!valuesList.ProcessingDone && valuesList.Operation == ListOperations.INCREMENT_POSITION_FIVE_REPEAT_SUB_OPERATIONS)
            {
                valuesList.Values = this.IncrementPosition(valuesList.Values, ListOperationIndexes.INCREMENT_POSITION_FIVE_INDEX);
            }

            else if (!valuesList.ProcessingDone && valuesList.Operation == ListOperations.INCREMENT_POSITION_SIX_REPEAT_SUB_OPERATIONS)
            {
                valuesList.Values = this.IncrementPosition(valuesList.Values, ListOperationIndexes.INCREMENT_POSITION_SIX_INDEX);
            }

            else if (!valuesList.ProcessingDone && valuesList.Operation == ListOperations.INCREMENT_POSITION_SEVEN_REPEAT_SUB_OPERATIONS)
            {
                valuesList.Values = this.IncrementPosition(valuesList.Values, ListOperationIndexes.INCREMENT_POSITION_SEVEN_INDEX);
            }

            else if (!valuesList.ProcessingDone && valuesList.Operation == ListOperations.INCREMENT_POSITION_EIGHT_REPEAT_SUB_OPERATIONS)
            {
                valuesList.Values = this.IncrementPosition(valuesList.Values, ListOperationIndexes.INCREMENT_POSITION_EIGHT_INDEX);
            }

            else if (!valuesList.ProcessingDone && valuesList.Operation == ListOperations.INCREMENT_POSITION_NINE_REPEAT_SUB_OPERATIONS)
            {
                valuesList.Values = this.IncrementPosition(valuesList.Values, ListOperationIndexes.INCREMENT_POSITION_NINE_INDEX);
            }

            else if (!valuesList.ProcessingDone && valuesList.Operation == ListOperations.INCREMENT_POSITION_TEN_REPEAT_SUB_OPERATIONS)
            {
                valuesList.Values = this.IncrementPosition(valuesList.Values, ListOperationIndexes.INCREMENT_POSITION_TEN_INDEX);
            }

            else if (!valuesList.ProcessingDone)
                throw new Exception("Unknown exception");

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
            List<int> values1 = new List<int>();

            int positionCtr = values.Count - incrementPosition;
            while (positionCtr < values.Count)
            {
                values1.Add(values[positionCtr]);
                positionCtr++;
            }
            values1 = Utilities.Sort(values1);

            int valueToIncrement = values[values.Count - incrementPosition];
            int incrementedValue = Utilities.GetNextBiggerNumber(values1, valueToIncrement);

            values1.Remove(incrementedValue);
            values1 = Utilities.Sort(values1);

            values[values.Count - incrementPosition] = incrementedValue;
            positionCtr = (values.Count - incrementPosition) + 1;

            int sortCtr = 0;
            while (positionCtr < values.Count)
            {
                values[positionCtr] = values1[sortCtr];
                positionCtr++;
                sortCtr++;
            }

            return values;
        }
    }
}
