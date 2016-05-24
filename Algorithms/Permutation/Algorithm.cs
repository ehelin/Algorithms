﻿using System.Collections.Generic;
using System;

namespace Algorithms.Permutation
{
    /// <summary>
    /// This algorithm finds (I hope :)) all the permutations for the last 4 numbers of a six number string.  I intent to use it in the traveling salesman algorithm
    /// </summary>
    public class Algorithm
    {
        private string input;

        public Algorithm(string input)
        {
            this.input = input;
        }

        private List<int> Sort(List<int> values)
        {
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

        private List<int> Setup()
        {
            List<int> values = new List<int>();
            foreach (char character in input.ToCharArray())
            {
                string curChar = character.ToString();
                values.Add(Convert.ToInt32(curChar));
            }

            return values;
        }
        public void RunExample()
        {
            Console.WriteLine("Starting Permutation Algorithm");

            List<int>values = Setup();
            values = Sort(values);
            Run(values);

            Console.WriteLine("Permutation Algorithm Complete!");
        }

        private string Display(List<int> values)
        {
            string line = string.Empty;

            foreach (int character in values)
                line += character.ToString();

            Console.Write(line);

            Console.Write("\n");

            return line;
        }

        private void Run(List<int> values)
        {
            int position = values.Count - 1;
            int maxValue = values[position];
            int curIncrementPosition = 2;
            int masterCtr = 0;

            int ctr = 0;
            while (true)
            {
                string line = Display(values);

                if (masterCtr == 23)
                {
                    break;
                }

                int compareValue = values[position - curIncrementPosition];
                if (compareValue == maxValue && ctr >= 5)
                {
                    int incrementedValue = values[curIncrementPosition];
                    int myCtr = curIncrementPosition;
                    curIncrementPosition = curIncrementPosition + 1;
                    List<int> values1 = new List<int>();
                    incrementedValue++;

                    while (myCtr < values.Count)
                    {
                        values1.Add(values[myCtr]);
                        myCtr++;
                    }

                    values1.Remove(incrementedValue);
                    values1 = Sort(values1);

                    int positionCtr = values.Count - (curIncrementPosition + 1);
                    values[positionCtr] = incrementedValue;
                    positionCtr++;

                    int sortCtr = 0;
                    while (positionCtr < values.Count)
                    {
                        values[positionCtr] = values1[sortCtr];
                        positionCtr++;
                        sortCtr++;
                    }

                    ctr = -1;
                    curIncrementPosition = 2;
                }                                      //123456     

                if (ctr % 2 == 0 && ctr >= 0)                   //123465 - flip last 2
                {
                    int tmp = values[position];
                    values[position] = values[position - 1];
                    values[position - 1] = tmp;
                }
                else if (ctr % 2 != 0 && ctr >= 0)                          //123546 - increase 3rd
                {
                    List<int> values1 = new List<int>();

                    int positionCtr = curIncrementPosition;
                    while (positionCtr >= 0)
                    {
                        values1.Add(values[position - positionCtr]);
                        positionCtr--;
                    }
                    values1 = Sort(values1);

                    int incrementedValue = values[position - curIncrementPosition];
                    incrementedValue = GetNextBiggerNumber(values1, incrementedValue);
                    
                    values1.Remove(incrementedValue);
                    values1 = Sort(values1);

                    positionCtr = values.Count - (curIncrementPosition + 1);

                    //positionCtr = curIncrementPosition + 1;
                    values[positionCtr] = incrementedValue;
                    positionCtr++;

                    int sortCtr = 0;
                    while (positionCtr < values.Count)
                    {
                        values[positionCtr] = values1[sortCtr];
                        positionCtr++;
                        sortCtr++;
                    }
                }

                ctr++;
                masterCtr++;
            }
        }

        private int GetNextBiggerNumber(List<int> values, int curValue)
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
