using System;
using System.Collections.Generic;

namespace Algorithms.Permutation.HomeGrown
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
        
        public void SetNextOperation()
        {
            //first swap of farthest right numbers in the sorted equence
            if (Utilities.ExecuteCommand(ValuesOperationList, 1))
            {
                Operation = 1;
                ValuesOperationList = Utilities.ResetOperationArray(ValuesOperationList, 1);
            }

            //working back towards the left side of the sorted sequence
            else
            {
                bool done = false;
                int incrementPosition = 2;

                while (!done)
                {
                    int compareValue = incrementPosition + 1;
                    if (!Utilities.ProcessingDone(Values, compareValue, out doneProcessing))
                    {
                        if (Utilities.ExecuteCommand(ValuesOperationList, incrementPosition))
                        {
                            done = true;
                            Operation = incrementPosition;
                            ValuesOperationList = Utilities.ResetOperationArray(ValuesOperationList, incrementPosition);
                        }
                    }
                    else
                    {
                        break;
                    }

                    incrementPosition++;
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
