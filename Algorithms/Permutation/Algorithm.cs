﻿using System;
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

        protected void Init()
        {
            start = DateTime.Now;
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

            if (this.ShowOutput)
            {
                foreach (int value in intValues)
                {
                    line += value.ToString() + ",";
                }

                line = line.Trim(',');
            }
            else if (printCounts % 1000000000 == 0)
            {
                line = printCounts.ToString();
            }

            if (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine("Goal: 30414093201713378043612608166064768844377641568960512000000000000");
                Console.WriteLine("Current: " + line);
                Console.WriteLine("(Start/Current - (" + this.start.ToString() + "/" + DateTime.Now.ToString() + ")");
            }
        }
    }
}
