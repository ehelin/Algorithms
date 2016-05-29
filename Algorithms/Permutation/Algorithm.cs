using System.Collections.Generic;
using System;

namespace Algorithms.Permutation
{
    /// <summary>
    /// This algorithm finds (I hope :)) all the permutations for the last 4 numbers of a six number string.  I intent to use it in the traveling salesman algorithm
    /// </summary>
    public class Algorithm
    {
        //string of characters to calculate permutations on
        private string input;

        public Algorithm(string input)
        {
            this.input = input;
        }
        
        public void RunExample()
        {
            AlgorithmList values = PreRunSteps();
                                               
            Run(values);

            PostRunSteps();
        }

        #region Algorithm Methods

        private void Run(AlgorithmList values)
        {
            int masterCtr = 0;
            int ctr = 0;
            bool done = false;

            while (!done)
            {
                //Try working in the ready to exit test and see if that will work in place of masterCtr tests
                if (values.ReadyToExit())
                {
                    done = true;
                    break;
                }

                if (masterCtr == 22 || masterCtr == 52 || masterCtr == 98 || masterCtr == 165 
                    || masterCtr == 257 || masterCtr == 378 || masterCtr == 531)
                {
                    values.curIncrementPosition--;
                    values.subTractionValue++;

                    if (values.curIncrementPosition <= 0)
                    {
                        done = true;
                        break;
                    }
                }

                values.Display();

                //increase next position left? (i.e. smaller index)
                int compareValue = values.values[values.curIncrementPosition];
                if (compareValue == values.maxValue && ctr >= 5)                                   
                {
                    int tmpIncrementPosition = values.values.Count - values.subTractionValue;
                    values = HandleIncrement(values, tmpIncrementPosition);
                    ctr = -1;
                }

                //flip last 2
                if (ctr % 2 == 0 && ctr >= 0)                                               
                {
                    values.HandleSimpleSwap();
                }
                //increase next level up
                else if (ctr % 2 != 0 && ctr >= 0)                                          
                {
                    values = HandleSubIncrement(values);
                }

                ctr++;
                masterCtr++;
            }
        }

        #region Algorithm Private Methods

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

        private AlgorithmList HandleSubIncrement(AlgorithmList values)
        {
            AlgorithmList values1 = new AlgorithmList();

            int positionCtr = values.curIncrementPosition;
            while (positionCtr < values.values.Count)
            {
                values1.values.Add(values.values[positionCtr]);
                positionCtr++;
            }
            values1.Sort();

            int incrementedValue = values.values[values.curIncrementPosition];
            incrementedValue = GetNextBiggerNumber(values1, incrementedValue);

            values1.values.Remove(incrementedValue);
            values1.Sort();
            
            values.values[values.curIncrementPosition] = incrementedValue;
            positionCtr = values.curIncrementPosition + 1;

            int sortCtr = 0;
            while (positionCtr < values.values.Count)
            {
                values.values[positionCtr] = values1.values[sortCtr];
                positionCtr++;
                sortCtr++;
            }

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

        #endregion

        #endregion

        #region Non-Algorithm Methods

        private AlgorithmList PreRunSteps()
        {
            Console.WriteLine("Starting Permutation Algorithm");
            Console.WriteLine("Seed string - " + this.input);

            AlgorithmList values = new AlgorithmList(this.input);
            Console.Write("Seed string sorted - ");
            values.Display(true);

            return values;
        }
        private void PostRunSteps()
        {
            Console.WriteLine("Permutation Algorithm Complete!");
            Console.WriteLine("");
        }

        #endregion
    }
}
