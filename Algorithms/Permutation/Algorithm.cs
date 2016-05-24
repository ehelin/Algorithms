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

        private void Display(List<int> values)
        {
            foreach (int character in values)
                Console.Write(character.ToString());

            Console.Write("\n");
        }

        private void Run(List<int> values)
        {
            int position = values.Count - 1;
            int maxValue = values[position];

            int ctr = 0;
            while (true)
            {
                Display(values);                                        //123456

                if (ctr == 0 || ctr == 2 || ctr == 4)                   //123465 - flip last 2
                {
                    int tmp = values[position];
                    values[position] = values[position - 1];
                    values[position - 1] = tmp;
                }
                else if (ctr == 1 || ctr == 3)                          //123546 - increase 3rd
                {
                    int val1 = values[position - 2];
                    int val2 = values[position - 1];
                    int val3 = values[position];

                    List<int> shortSort = new List<int>();
                    shortSort.Add(val1);
                    shortSort.Add(val2);
                    shortSort.Add(val3);
                    shortSort = Sort(shortSort);

                    int incrementedValue = 0;

                    if (ctr == 1)
                    {
                        incrementedValue = shortSort[ctr];
                    }
                    else if (ctr == 3)
                    {
                        int tmp = ctr - 1;
                        incrementedValue = shortSort[tmp];
                    }

                    shortSort.Clear();

                    if (val1 != incrementedValue)
                        shortSort.Add(val1);
                    if (val2 != incrementedValue)
                        shortSort.Add(val2);
                    if (val3 != incrementedValue)
                        shortSort.Add(val3);

                    shortSort = Sort(shortSort);

                    values[position - 2] = incrementedValue;
                    values[position - 1] = shortSort[0];
                    values[position] = shortSort[1];
                }
                else                                                    //124356 - increment 4th
                {
                    if (values[2] == maxValue)
                        break;

                    int val1 = values[position - 3];
                    int val2 = values[position - 2];
                    int val3 = values[position - 1];
                    int val4 = values[position];

                    int incrementedValue = val1 + 1;
                    List<int> shortSort = new List<int>();

                    if (val1 != incrementedValue)
                        shortSort.Add(val1);
                    if (val2 != incrementedValue)
                        shortSort.Add(val2);
                    if (val3 != incrementedValue)
                        shortSort.Add(val3);
                    if (val4 != incrementedValue)
                        shortSort.Add(val4);

                    shortSort = Sort(shortSort);

                    values[position - 3] = incrementedValue;
                    values[position - 2] = shortSort[0];
                    values[position - 1] = shortSort[1];
                    values[position] = shortSort[2];

                    ctr = -1;
                }

                ctr++;
            }
        }
    }
}
