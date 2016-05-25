using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Permutation
{
    public class AlgorithmList
    {
        public List<int> values;
        public List<int> valuesCopy;

        public AlgorithmList()
        {
            values = new List<int>();
            valuesCopy = new List<int>();
        }

        public AlgorithmList(string input)
        {
            this.values = new List<int>();
            this.valuesCopy = new List<int>();

            foreach (char character in input.ToCharArray())
            {
                string curChar = character.ToString();
                values.Add(Convert.ToInt32(curChar));
            }
            Sort();

            CreateCopy();
        }

        public void Sort()
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
        }

        public void Display()
        {
            string line = string.Empty;

            foreach (int character in values)
                line += character.ToString();

            Console.Write(line);

            Console.Write("\n");
        }

        private void CreateCopy()
        {
            valuesCopy = new List<int>();

            foreach (int value in values)
                valuesCopy.Add(value);
        }

    }
}
