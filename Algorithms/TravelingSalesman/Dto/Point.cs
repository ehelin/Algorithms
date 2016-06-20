namespace Algorithms.TravelingSalesman.Dto
{
    /// <summary>
    /// Point for 2 dimensional grid
    /// </summary>
    public class Point
    {
        /// <summary>
        /// X,Y on 2 dimensional grid
        /// </summary>
        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// Path name that this point is on
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x, int y, string name)
        {
            this.X = x;
            this.Y = y;
            this.Name = name;
        }

        /// <summary>
        /// Returns string value for class
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Name: " + this.Name + ",X=" + X.ToString() + ", Y=" + Y.ToString();
        }
    }
}
