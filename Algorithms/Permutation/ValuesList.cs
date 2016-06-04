using System;
using System.Collections.Generic;

namespace Algorithms.Permutation
{
    public class ValuesList
    {
        public List<int> Values { get; set; }
        public List<int> ValuesOperationList { get; set; }
        public int MaxValue { get; set; }
        public bool ProcessingDone { get; set; }
        public int DisplayCtr { get; set; }
        public string Operation { get; set; }
        public int LineCtr { get; set; }

        public ValuesList(string input)
        {
            Values = new List<int>();
            ValuesOperationList = new List<int>();

            Init(input);
        }

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

        private string lastDisplay = string.Empty;
        public void Display(bool omitNumbering = false)
        {
            string line = string.Empty;

            foreach (int character in this.Values)
                line += character.ToString() + "-";
            line = line.Trim('-');

            if (lastDisplay != line)
            {
                if (!omitNumbering)
                {
                    Console.Write(String.Format("{0:000}", LineCtr) + "-");
                    LineCtr++;
                    DisplayCtr++;
                }

                Console.Write(line);
                Console.Write("\n");

                lastDisplay = line;
            }
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
