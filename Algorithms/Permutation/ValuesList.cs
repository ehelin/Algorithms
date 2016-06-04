using System;
using System.Collections.Generic;

namespace Algorithms.Permutation
{
    public class ValuesList
    {
        /// <summary>
        /// List of values being processed
        /// </summary>
        public List<int> Values { get; set; }

        /// <summary>
        /// List of operations - 00000 - flip last two, 00001 - increment second to last, 00021 - increment third to last, etc
        /// </summary>
        public List<int> ValuesOperationList { get; set; }

        /// <summary>
        /// Max value possible in any column  (i.e. max value in sorted sequence)
        /// </summary>
        public int MaxValue { get; set; }

        /// <summary>
        /// All permutations possible calculated
        /// </summary>
        public bool ProcessingDone { get; set; }

        /// <summary>
        /// Counter on display
        /// </summary>
        public int DisplayCtr { get; set; }

        /// <summary>
        /// Operation to be applied to next interation
        /// </summary>
        public string Operation { get; set; }
        
        //DO I need this?
        public int LineCtr { get; set; }

        /// <summary>
        /// Last sequence displayed to user
        /// </summary>
        private string lastDisplay = string.Empty;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="input"></param>
        public ValuesList(string input)
        {
            Values = new List<int>();
            ValuesOperationList = new List<int>();

            Init(input);
        }

        //TODO - refactor
        public void SetNextOperation()
        {
            if (ValuesOperationList[ValuesOperationList.Count - 1] == 0)
            {
                Operation = ListOperations.FLIP_LAST_TWO_LIST_MEMBERS;
                ValuesOperationList[ValuesOperationList.Count - 1]++;
            }

            else if (ValuesOperationList[ValuesOperationList.Count - 1] == 1
                && ValuesOperationList[ValuesOperationList.Count - 2] < 2)
            {
                if (Values.Count < ListOperationIndexes.INCREMENT_POSITION_TWO_INDEX)
                {
                    this.ProcessingDone = true;
                }
                else
                {
                    Operation = ListOperations.INCREMENT_POSITION_TWO_REPEAT_SUB_OPERATIONS;
                    ValuesOperationList[ValuesOperationList.Count - 2]++;
                    ValuesOperationList[ValuesOperationList.Count - 1] = 0;
                }
            }

            else if (ValuesOperationList[ValuesOperationList.Count - 1] == 1
                && ValuesOperationList[ValuesOperationList.Count - 2] == 2
                && ValuesOperationList[ValuesOperationList.Count - 3] < 3)
            {
                if (Values.Count < ListOperationIndexes.INCREMENT_POSITION_THREE_INDEX)
                {
                    this.ProcessingDone = true;
                }
                else
                {
                    Operation = ListOperations.INCREMENT_POSITION_THREE_REPEAT_SUB_OPERATIONS;
                    ValuesOperationList[ValuesOperationList.Count - 3]++;
                    ValuesOperationList[ValuesOperationList.Count - 2] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 1] = 0;
                }
            }

            else if (ValuesOperationList[ValuesOperationList.Count - 1] == 1
                && ValuesOperationList[ValuesOperationList.Count - 2] == 2
                && ValuesOperationList[ValuesOperationList.Count - 3] == 3
                && ValuesOperationList[ValuesOperationList.Count - 4] < 4)
            {
                if (Values.Count < ListOperationIndexes.INCREMENT_POSITION_FOUR_INDEX)
                {
                    this.ProcessingDone = true;
                }
                else
                {
                    Operation = ListOperations.INCREMENT_POSITION_FOUR_REPEAT_SUB_OPERATIONS;
                    ValuesOperationList[ValuesOperationList.Count - 4]++;
                    ValuesOperationList[ValuesOperationList.Count - 3] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 2] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 1] = 0;
                }
            }

            else if (ValuesOperationList[ValuesOperationList.Count - 1] == 1
                && ValuesOperationList[ValuesOperationList.Count - 2] == 2
                && ValuesOperationList[ValuesOperationList.Count - 3] == 3
                && ValuesOperationList[ValuesOperationList.Count - 4] == 4
                && ValuesOperationList[ValuesOperationList.Count - 5] < 5)
            {
                if (Values.Count < ListOperationIndexes.INCREMENT_POSITION_FIVE_INDEX)
                {
                    this.ProcessingDone = true;
                }
                else
                {
                    Operation = ListOperations.INCREMENT_POSITION_FIVE_REPEAT_SUB_OPERATIONS;
                    ValuesOperationList[ValuesOperationList.Count - 5]++;
                    ValuesOperationList[ValuesOperationList.Count - 4] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 3] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 2] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 1] = 0;
                }
            }

            else if (ValuesOperationList[ValuesOperationList.Count - 1] == 1
                && ValuesOperationList[ValuesOperationList.Count - 2] == 2
                && ValuesOperationList[ValuesOperationList.Count - 3] == 3
                && ValuesOperationList[ValuesOperationList.Count - 4] == 4
                && ValuesOperationList[ValuesOperationList.Count - 5] == 5
                && ValuesOperationList[ValuesOperationList.Count - 6] < 6)
            {
                if (Values.Count < ListOperationIndexes.INCREMENT_POSITION_SIX_INDEX)
                {
                    this.ProcessingDone = true;
                }
                else
                {
                    Operation = ListOperations.INCREMENT_POSITION_SIX_REPEAT_SUB_OPERATIONS;
                    ValuesOperationList[ValuesOperationList.Count - 6]++;
                    ValuesOperationList[ValuesOperationList.Count - 5] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 4] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 3] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 2] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 1] = 0;
                }
            }

            else if (ValuesOperationList[ValuesOperationList.Count - 1] == 1
                && ValuesOperationList[ValuesOperationList.Count - 2] == 2
                && ValuesOperationList[ValuesOperationList.Count - 3] == 3
                && ValuesOperationList[ValuesOperationList.Count - 4] == 4
                && ValuesOperationList[ValuesOperationList.Count - 5] == 5
                && ValuesOperationList[ValuesOperationList.Count - 6] == 6
                && ValuesOperationList[ValuesOperationList.Count - 7] < 7)
            {
                if (Values.Count < ListOperationIndexes.INCREMENT_POSITION_SEVEN_INDEX)
                {
                    this.ProcessingDone = true;
                }
                else
                {
                    Operation = ListOperations.INCREMENT_POSITION_SEVEN_REPEAT_SUB_OPERATIONS;
                    ValuesOperationList[ValuesOperationList.Count - 7]++;
                    ValuesOperationList[ValuesOperationList.Count - 6] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 5] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 4] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 3] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 2] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 1] = 0;
                }
            }

            else if (ValuesOperationList[ValuesOperationList.Count - 1] == 1
                && ValuesOperationList[ValuesOperationList.Count - 2] == 2
                && ValuesOperationList[ValuesOperationList.Count - 3] == 3
                && ValuesOperationList[ValuesOperationList.Count - 4] == 4
                && ValuesOperationList[ValuesOperationList.Count - 5] == 5
                && ValuesOperationList[ValuesOperationList.Count - 6] == 6
                && ValuesOperationList[ValuesOperationList.Count - 7] == 7
                && ValuesOperationList[ValuesOperationList.Count - 8] < 8)
            {
                if (Values.Count < ListOperationIndexes.INCREMENT_POSITION_EIGHT_INDEX)
                {
                    this.ProcessingDone = true;
                }
                else
                {
                    Operation = ListOperations.INCREMENT_POSITION_EIGHT_REPEAT_SUB_OPERATIONS;
                    ValuesOperationList[ValuesOperationList.Count - 8]++;
                    ValuesOperationList[ValuesOperationList.Count - 7] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 6] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 5] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 4] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 3] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 2] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 1] = 0;
                }
            }

            else if (ValuesOperationList[ValuesOperationList.Count - 1] == 1
                && ValuesOperationList[ValuesOperationList.Count - 2] == 2
                && ValuesOperationList[ValuesOperationList.Count - 3] == 3
                && ValuesOperationList[ValuesOperationList.Count - 4] == 4
                && ValuesOperationList[ValuesOperationList.Count - 5] == 5
                && ValuesOperationList[ValuesOperationList.Count - 6] == 6
                && ValuesOperationList[ValuesOperationList.Count - 7] == 7
                && ValuesOperationList[ValuesOperationList.Count - 8] == 8
                && ValuesOperationList[ValuesOperationList.Count - 9] < 9)
            {
                if (Values.Count < ListOperationIndexes.INCREMENT_POSITION_NINE_INDEX)
                {
                    this.ProcessingDone = true;
                }
                else
                {
                    Operation = ListOperations.INCREMENT_POSITION_NINE_REPEAT_SUB_OPERATIONS;
                    ValuesOperationList[ValuesOperationList.Count - 9]++;
                    ValuesOperationList[ValuesOperationList.Count - 8] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 7] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 6] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 5] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 4] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 3] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 2] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 1] = 0;
                }
            }
            else if (ValuesOperationList[ValuesOperationList.Count - 1] == 1
              && ValuesOperationList[ValuesOperationList.Count - 2] == 2
              && ValuesOperationList[ValuesOperationList.Count - 3] == 3
              && ValuesOperationList[ValuesOperationList.Count - 4] == 4
              && ValuesOperationList[ValuesOperationList.Count - 5] == 5
              && ValuesOperationList[ValuesOperationList.Count - 6] == 6
              && ValuesOperationList[ValuesOperationList.Count - 7] == 7
              && ValuesOperationList[ValuesOperationList.Count - 8] == 8
              && ValuesOperationList[ValuesOperationList.Count - 9] == 9
              && ValuesOperationList[ValuesOperationList.Count - 10] < 10)
            {
                if (Values.Count < ListOperationIndexes.INCREMENT_POSITION_TEN_INDEX)
                {
                    this.ProcessingDone = true;
                }
                else
                {
                    Operation = ListOperations.INCREMENT_POSITION_TEN_REPEAT_SUB_OPERATIONS;
                    ValuesOperationList[ValuesOperationList.Count - 10]++;
                    ValuesOperationList[ValuesOperationList.Count - 9] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 8] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 7] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 6] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 5] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 4] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 3] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 2] = 0;
                    ValuesOperationList[ValuesOperationList.Count - 1] = 0;
                }
            }

        }
        public void Display(bool showDisplay, bool omitNumbering = false)
        {
            string line = string.Empty;

            foreach (int character in this.Values)
                line += character.ToString() + "-";
            line = line.Trim('-');

            if (lastDisplay != line)
            {
                if (showDisplay)
                {
                    if (!omitNumbering)
                    {
                        Console.Write(String.Format("{0:000}", LineCtr) + "-");
                        LineCtr++;
                        DisplayCtr++;
                    }

                    Console.Write(line);
                    Console.Write("\n");
                }

                lastDisplay = line;
            }
        }
        public string GetLastDisplay()
        {
            return lastDisplay;
        }


        private void SetOperationListToZero()
        {
            for(int ctr = 0; ctr < ValuesOperationList.Count; ctr++)
            {
                ValuesOperationList[ctr] = 0;
            }
        }
        private void Init(string input)
        {
            string[] characters = input.Split(',');

            foreach (string character in characters)
            {
                Values.Add(Convert.ToInt32(character));
                ValuesOperationList.Add(0);
            }

            Values = Utilities.Sort(Values);
            this.MaxValue = Values[Values.Count - 1];

            DisplayCtr = 0;
            LineCtr = 1;
        }
    }
}
