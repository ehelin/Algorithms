using System.Collections.Generic;
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
        
        public void RunExample()
        {
            Console.WriteLine("Starting Permutation Algorithm");
            Console.WriteLine("Seed string - " + this.input);

            AlgorithmList values = new AlgorithmList(this.input);
            values.Sort();

            Console.Write("Seed string sorted - ");
            values.Display();

            int curIncrementPosition = values.values.Count - 3;                           //starting number
            int position = values.values.Count - 1;
            int maxValue = values.values[values.values.Count -1];                                       //starting number
            Run(values, curIncrementPosition, position, maxValue);

            Console.WriteLine("Permutation Algorithm Complete!");
            Console.WriteLine("");
        }
        
        private void Run(AlgorithmList values, int curIncrementPosition, int position, int maxValue)
        {
            //int curIncrementPosition = 3;
            //int maxValue = 6;// values.values[values.values.Count - 1];
            int masterCtr = 0;
            int subTractionValue = 4;

            int ctr = 0;
            while (true)
            {
                values.Display();

                if (masterCtr == 52 && values.values.Count == 7)
                {
                    break;
                }

                if ((masterCtr == 23 && values.values.Count == 7) || masterCtr == 23)
                {
                    if (masterCtr == 23 && values.values.Count == 6)
                    {
                        break;
                    }

                    if (masterCtr == 23 && values.values.Count == 7)
                    {
                        //maxValue++;// = values.values[values.values.Count - 1];
                        curIncrementPosition--;
                        subTractionValue++;
                    }
                }

                int thisIndex = curIncrementPosition;
                int compareValue = values.values[thisIndex];
                if (compareValue == maxValue && ctr >= 5)                                   //increase 4th
                {
                    int tmpIncrementPosition = values.values.Count - subTractionValue;
                    values = HandleIncrement(values, tmpIncrementPosition);
                    ctr = -1;
                }                                      

                if (ctr % 2 == 0 && ctr >= 0)                                               //flip last 2
                {
                    values = HandleSimpleSwap(values, position);
                }
                else if (ctr % 2 != 0 && ctr >= 0)                                          //increase 3rd
                {
                    values = HandleSubIncrement(values, curIncrementPosition, position);
                }

                ctr++;
                masterCtr++;
            }
        }

        private AlgorithmList HandleIncrement(AlgorithmList values, int curIncrementPosition)
        {
            int incrementedValue = values.values[curIncrementPosition];
            int myCtr = curIncrementPosition;
            //curIncrementPosition = curIncrementPosition + 1;
            AlgorithmList values1 = new AlgorithmList();
            incrementedValue++;

            while (myCtr < values.values.Count)
            {
                values1.values.Add(values.values[myCtr]);
                myCtr++;
            }

            values1.values.Remove(incrementedValue);
            values1.Sort();

            int positionCtr = curIncrementPosition;
            values.values[positionCtr] = incrementedValue;
            positionCtr++;

            int sortCtr = 0;
            while (positionCtr < values.values.Count)
            {
                values.values[positionCtr] = values1.values[sortCtr];
                positionCtr++;
                sortCtr++;
            }

            return values;
        }
        private AlgorithmList HandleSubIncrement(AlgorithmList values, int curIncrementPosition, int position)
        {
            AlgorithmList values1 = new AlgorithmList();

            int positionCtr = curIncrementPosition;
            while (positionCtr < values.values.Count)
            {
                values1.values.Add(values.values[positionCtr]);
                positionCtr++;
            }
            values1.Sort();

            int incrementedValue = values.values[curIncrementPosition];
            incrementedValue = GetNextBiggerNumber(values1, incrementedValue);

            values1.values.Remove(incrementedValue);
            values1.Sort();

            //positionCtr = values.values.Count - curIncrementPosition;

            //positionCtr = curIncrementPosition + 1;
            values.values[curIncrementPosition] = incrementedValue;
            positionCtr = curIncrementPosition + 1;

            int sortCtr = 0;
            while (positionCtr < values.values.Count)
            {
                values.values[positionCtr] = values1.values[sortCtr];
                positionCtr++;
                sortCtr++;
            }

            return values;
        }
        private AlgorithmList HandleSimpleSwap(AlgorithmList values, int position)
        {
            int tmp = values.values[position];
            values.values[position] = values.values[position - 1];
            values.values[position - 1] = tmp;

            return values;
        }
        private int GetNextBiggerNumber(AlgorithmList values, int curValue)
        {
            int nxtValue = 0;

            foreach (int value in values.values)
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
