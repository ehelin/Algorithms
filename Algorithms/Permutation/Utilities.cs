using System.Collections.Generic;

namespace Algorithms.Permutation
{
    public class Utilities
    {
        public static List<int> Sort(List<int> values)
        {
            //Starting with bubble sort for ease of use...replace with quick sort?
            for (int outer = 0; outer < values.Count - 1; outer++)
            {
                for (int inner = 0; inner < values.Count - 1; inner++)
                {
                    if (inner + 1 > values.Count)
                        break;

                    if (values[inner] > values[inner + 1])
                    {
                        int val = values[inner];
                        values[inner] = values[inner + 1];
                        values[inner + 1] = val;
                    }
                }
            }

            return values;
        }
        public static bool ProcessingDone(List<int> Values, int compareValue, out bool doneProcessing)
        {
            doneProcessing = false;

            if (Values.Count < compareValue)
            {
                doneProcessing = true;
            }

            return doneProcessing;
        }
        public static bool ExecuteCommand(List<int> ValuesOperationList,
                                          int indexToIncrement)
        {
            bool executeCommand = true;
            int ctr = indexToIncrement - 1;
            int curIndexValue = ValuesOperationList[ValuesOperationList.Count - indexToIncrement];

            while (ctr > 0)
            {
                if (ValuesOperationList[ValuesOperationList.Count - ctr] != ctr)
                {
                    executeCommand = false;
                    break;
                }

                ctr--;
            }

            if (executeCommand && curIndexValue >= indexToIncrement)
            {
                executeCommand = false;
            }

            return executeCommand;
        }
        public static List<int> ResetOperationArray(List<int> ValuesOperationList, int indexToIncrement)
        {
            int ctr = indexToIncrement-1;
            int curIndexValue = ValuesOperationList[ValuesOperationList.Count - indexToIncrement];
            curIndexValue = curIndexValue + 1;

            while (ctr > 0)
            {
                ValuesOperationList[ValuesOperationList.Count - ctr] = 0;
                ctr--;
            }

            ValuesOperationList[ValuesOperationList.Count - indexToIncrement] = curIndexValue;

            return ValuesOperationList;
        }
        public static int CalculateFactorial(int value)
        {
            int factorial = value;
            int ctr = 1;

            while (ctr < value)
            {
                factorial = factorial * (value - ctr);
                ctr++;
            }

            return factorial;
        }
        public static int GetNextBiggerNumber(List<int> values, int curValue)
        {
            int nxtValue = 0;

            foreach (int value in values)
            {
                if (value > curValue && value > nxtValue)
                {
                    nxtValue = value;
                    break;
                }
            }

            return nxtValue;
        }
    }
}
