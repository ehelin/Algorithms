using System.Collections.Generic;

namespace Algorithms.TravelingSalesman
{
    public class CityDistance
    {
        //diff with city compared too
        public int XDiff { get; set; }
        public int YDiff { get; set; }

        //2 dimensional grid - we can go N, NW, W, SW, S, SE, E, NE
        public List<string> TravelDirections { get; set; }

        public CityDistance(int XDiff, int YDiff)
        {
            this.XDiff = XDiff;
            this.YDiff = YDiff;
            TravelDirections = new List<string>();
        }
    }
}
