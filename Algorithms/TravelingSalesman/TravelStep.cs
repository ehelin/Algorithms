using System.Collections.Generic;

namespace Algorithms.TravelingSalesman
{
    public class TravelStep
    {
        public int Distance { get; set; }
        public List<string> Steps { get; set; }
        public string CityName { get; set; }
        public int xDiff { get; set; }
        public int yDiff { get; set; }

        public TravelStep(int distance, string cityName, int xDiff, int yDiff)
        {
            this.Distance = distance;
            this.CityName = cityName;
            this.Steps = new List<string>();
            this.xDiff = xDiff;
            this.yDiff = yDiff;
        }
    }
}
