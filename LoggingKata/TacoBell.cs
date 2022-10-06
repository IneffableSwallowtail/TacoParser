using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingKata
{
    public class TacoBell : ITrackable
    {
        double latitude;
        double longitude;
        Point point = new Point();

        public TacoBell() { }

        public TacoBell(Point Point)
        {
            Point = point;
        }
        public TacoBell(double Latitude, double Longitude)
        {
            latitude = Latitude;
            longitude = Longitude;
            point.Latitude = latitude;
            point.Longitude = longitude;
        }
        public string Name { get; set; }
        public Point Location { get; set; }
    }
}
