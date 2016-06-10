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
        protected long printCounts = 0;    //number of sequence that would have been printed

        protected void Init()
        {
            string[] strValues = Input.Split(',');
            values = new int[strValues.Length];

            for (int ctr = 0; ctr < strValues.Length; ctr++)
            {
                values[ctr] = Convert.ToInt32(strValues[ctr]);
            }
        }
        protected void Print(int[] intValues)
        {
            string line = string.Empty;

            foreach (int value in intValues)
            {
                line += value.ToString() + ",";
            }

            line = line.Trim(',');

            Console.WriteLine(line);
        }
    }
}
