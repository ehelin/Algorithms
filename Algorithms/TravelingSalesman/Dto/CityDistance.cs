using System.Collections.Generic;

namespace Algorithms.TravelingSalesman.Dto
{
    /// <summary>
    /// Represents a city and the distance to it in 2 d grid point moves from this city (i.e this)
    /// </summary>
    public class CityDistance
    {
        /// <summary>
        /// Destination City
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Distance to that city from this city (i.e. this)
        /// </summary>
        public int Distance { get; set; }

        public List<Point> TravelPoints { get; set; }

        public CityDistance()
        {
            this.TravelPoints = new List<Point>();
        }
    }
}
