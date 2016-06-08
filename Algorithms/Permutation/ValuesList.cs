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
        public bool ProcessingDone
        { 
            get { return doneProcessing; }
            set { doneProcessing = value; }
        }
        private bool doneProcessing = false;

        /// <summary>
        /// Counter on display
        /// </summary>
        public int DisplayCtr { get; set; }

        /// <summary>
        /// Operation to be applied to next interation
        /// </summary>
        public int Operation { get; set; }
        
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
        
        //TODO - refactor to handle more than just 10 characters
        public void SetNextOperation()
        {
            if (Utilities.ExecuteCommand(ValuesOperationList, 1))
            {
                Operation = 1;
                ValuesOperationList = Utilities.ResetOperationArray(ValuesOperationList, 1);
            }
            
            else if (Utilities.ExecuteCommand(ValuesOperationList, 2))
            {
                if (!Utilities.ProcessingDone(Values, 3, out doneProcessing))
                {
                    Operation = 2;
                    ValuesOperationList = Utilities.ResetOperationArray(ValuesOperationList, 2);
                }
            }
            
            else if (Utilities.ExecuteCommand(ValuesOperationList, 3))
            {
                if (!Utilities.ProcessingDone(Values, 4, out doneProcessing))                
                {
                    Operation = 3;
                    ValuesOperationList = Utilities.ResetOperationArray(ValuesOperationList, 3);
                }
            }
            
            else if (Utilities.ExecuteCommand(ValuesOperationList, 4))
            {
                if (!Utilities.ProcessingDone(Values, 5, out doneProcessing))
                {
                    Operation = 4;
                    ValuesOperationList = Utilities.ResetOperationArray(ValuesOperationList, 4);
                }
            }

            else if (Utilities.ExecuteCommand(ValuesOperationList, 5))
            {
                if (!Utilities.ProcessingDone(Values, 6, out doneProcessing))
                {
                    Operation = 5;
                    ValuesOperationList = Utilities.ResetOperationArray(ValuesOperationList, 5);
                }
            }

            else if (Utilities.ExecuteCommand(ValuesOperationList, 6))
            {
                if (!Utilities.ProcessingDone(Values, 7, out doneProcessing))
                {
                    Operation = 6;
                    ValuesOperationList = Utilities.ResetOperationArray(ValuesOperationList, 6);
                }
            }

            else if (Utilities.ExecuteCommand(ValuesOperationList, 7))
            {
                if (!Utilities.ProcessingDone(Values, 8, out doneProcessing))
                {
                    Operation = 7;
                    ValuesOperationList = Utilities.ResetOperationArray(ValuesOperationList, 7);
                }
            }

            else if (Utilities.ExecuteCommand(ValuesOperationList, 8))
            {
                if (!Utilities.ProcessingDone(Values, 9, out doneProcessing))
                {
                    Operation = 8;
                    ValuesOperationList = Utilities.ResetOperationArray(ValuesOperationList, 8);
                }
            }

            else if (Utilities.ExecuteCommand(ValuesOperationList, 9))
            {
                if (!Utilities.ProcessingDone(Values, 10, out doneProcessing))
                {
                    Operation = 9;
                    ValuesOperationList = Utilities.ResetOperationArray(ValuesOperationList, 9);
                }
            }

            else if (Utilities.ExecuteCommand(ValuesOperationList,  10))
            {
                if (!Utilities.ProcessingDone(Values, 11, out doneProcessing))
                {
                    Operation = 10;
                    ValuesOperationList = Utilities.ResetOperationArray(ValuesOperationList, 10);
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
                if (!omitNumbering)
                {
                    if (showDisplay)
                        Console.Write(String.Format("{0:000}", LineCtr) + "-");

                    DisplayCtr++;
                    LineCtr++;
                }

                if (showDisplay)
                {
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
