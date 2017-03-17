using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Permutation
{
    public class Algorithm
    {
        protected string Input;          //input to find all sequences for
        protected bool ShowOutput;       //show all sequences
        protected int[] values;          //split up array version of input
        protected double printCounts = 0;    //number of sequence that would have been printed
        protected DateTime start;
        protected int[] lastShown;  //last display value array values

        protected void Init()
        {
            start = DateTime.Now;
            string[] strValues = Input.Split(',');
            values = new int[strValues.Length];
            lastShown = new int[strValues.Length];

            for (int ctr = 0; ctr < strValues.Length; ctr++)
            {
                values[ctr] = Convert.ToInt32(strValues[ctr]);
                lastShown[ctr] = Convert.ToInt32(strValues[ctr]);
            }
        }
        
        protected void ShowSwapPositions()
        {
            int[] changedIndices = GetChangedIndices(values, lastShown);

            if (ChangeOccurred(changedIndices))
            {
                Console.WriteLine("=============================");  
                PrintArray(lastShown);       //before change   
                PrintArray(changedIndices);  //change positions
                PrintArray(values);          //current position

                Console.WriteLine("");  //space between
            }
        }

        private void PrintArray(int[] array)
        {
            string line = string.Empty;

            int ctr = 0;
            foreach (int value in array)
            {
                line += value.ToString() + ",";
                lastShown[ctr] = value;
                ctr++;
            }

            line = line.Trim(',');
            Console.WriteLine(line);
        }

        //private void PrintSwapPositions(int[] intValues)
        //{
        //    string line = string.Empty;

        //    int ctr = 0;
        //    foreach (int value in intValues)
        //    {
        //        line += value.ToString() + ",";
        //        lastShown[ctr] = value;
        //        ctr++;
        //    }

        //    line = line.Trim(',');
        //    Console.WriteLine(line);
        //}
        private bool ChangeOccurred(int[] changedIndices)
        {
            bool changeOccurred = false;

            foreach (int changedIndex in changedIndices)
            {
                if (changedIndex > 0)
                {
                    changeOccurred = true;
                    break;
                }
            }

            return changeOccurred;
        }
        private int[] GetChangedIndices(int[] arrayOne, int[] arrayTwo)
        {
            int[] changeIndexes = new int[arrayOne.Length];

            if (arrayOne.Length != arrayTwo.Length)
                throw new Exception("array lengths must match");

            for (int i = 0; i < values.Length; i++)
            {
                int arrayOneValue = arrayOne[i];
                int arrayTwoValue = arrayTwo[i];

                if (arrayOneValue != arrayTwoValue)
                {
                    changeIndexes[i] = 1;
                    //break;
                }
            }

            return changeIndexes;
        }

        //TODO - refactor
        protected void Print(int[] intValues)
        {
            string line = string.Empty;

            if (this.ShowOutput)
            {
                int ctr = 0;
                foreach (int lastShownValue in lastShown)
                {
                    lastShown[ctr] = 0;
                    ctr++;
                }

                ctr = 0;
                foreach (int value in intValues)
                {
                    line += value.ToString() + ",";
                    lastShown[ctr] = value;
                    ctr++;
                }

                line = line.Trim(',');
            }
            else if (printCounts % 1000000000 == 0)
            {
                line = printCounts.ToString();
            }

            if (!string.IsNullOrEmpty(line))
            {
                //Console.WriteLine("Goal: 30414093201713378043612608166064768844377641568960512000000000000");
                //Console.WriteLine("Current: " + line);
                //Console.WriteLine("(Start/Current - (" + this.start.ToString() + "/" + DateTime.Now.ToString() + ")");
            }
        }
    }
}
