using System.Collections;
using System.Collections.Generic;

namespace Algorithms.TravelingSalesman
{
    //I am not hitting every possibility, so I need to implement this algorithm (I think)
    //to get each possibility
//123456
//123465 - flip last 2

//123546 - increase 3rd
//123564 - flip last 2

//123645 - increase 3rd
//123654 - flip last 2

//can't increment 3

//124356 - increment 4th
//124365 - flip last 2
//124536 - increase 3rd
//124563 - flip last 2
//124635 - increase 3rd
//124653 - flip last 2

//can't increment 3

//125346 - increment 4th
//125364 - flip last 2
//125436 - increase 3rd
//125463 - flip last 2
//125634 - increase 3rd
//125643 - flip last 2
    public class Cityv2
    {
        public string Name { get; set; }
        public int NameNumber { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool AddedToGrid { get; set; }

        public Cityv2(string Name, int NameNumber, int X, int Y)
        {
            this.Name = Name;
            this.NameNumber = NameNumber;
            this.X = X;
            this.Y = Y;
        }
        
    }
}
