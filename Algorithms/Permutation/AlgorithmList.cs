using System;
using System.Collections.Generic;

namespace Algorithms.Permutation
{
    /// <summary>
    /// Encapsulated list for value management so it is abstracted from the core algorithm.
    /// </summary>
    public class AlgorithmList
    {
        //List of values being processed
        public List<int> values;     
           
        //Copy of value list for ancillary processing
        public List<int> valuesCopy;    
        
        //increment position index on value list...starting at 3rd from end and moving forward)
        public int curIncrementPosition;

        //max value for comparing when to increase increment position
        public int maxValue;

        //TODO - comment these
        public int position;
        public int subTractionValue;

        //counter for console output
        private int displayCtr;

        public AlgorithmList()
        {
            values = new List<int>();
            valuesCopy = new List<int>();
        }
        
        public AlgorithmList(string input)
        {
            this.values = new List<int>();
            this.valuesCopy = new List<int>();

            Initialize(input);
        }

        #region Algorithm Methods

        public bool ReadyToExit()
        {
            bool readyToExit = false;

            foreach (int value in values)
            {
                if (value == 0)
                {
                    readyToExit = true;
                    break;
                }
            }

            return readyToExit;
        }
        public void HandleSimpleSwap()
        {
            int tmp = values[position];
            values[position] = values[position - 1];
            values[position - 1] = tmp;
        }


        public void Display(bool omitNumbering = false)
        {
            string line = string.Empty;

            if (!omitNumbering)
            {
                Console.Write(String.Format("{0:000}", displayCtr) + "-");
                displayCtr++;
            }

           foreach (int character in values)
                line += character.ToString() + "-";

            line = line.Trim('-');

            Console.Write(line);
            Console.Write("\n");
        }

        #endregion

        #region Private Methods

        private void Initialize(string input)
        {
            string[] characters = input.Split(',');

            foreach (string character in characters)
            {
                values.Add(Convert.ToInt32(character));
            }

            values = Utilities.Sort(values);
            CreateCopy();

            this.curIncrementPosition = values.Count - 3;
            this.position = values.Count - 1;
            this.maxValue = values[values.Count - 1];
            this.subTractionValue = 4;
            this.displayCtr = 1;
        }
        private void CreateCopy()
        {
            valuesCopy = new List<int>();

            foreach (int value in values)
                valuesCopy.Add(value);
        }

        #endregion
    }
}
