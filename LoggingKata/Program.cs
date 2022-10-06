using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);
            if (lines.Length < 1) logger.LogWarning("There are no lines");
            if (lines.Length > 0 && lines.Length < 2) logger.LogError("There is only one line");

            Console.WriteLine(lines);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();
            var store = lines.Select(parser.Parse).ToArray();

            ITrackable farthestTaco1 = new TacoBell();
            ITrackable farthestTaco2 = new TacoBell();
            double longestDistance = 0;

            var point1 = new Point();
            var point2 = new Point();
            GeoCoordinate coorA = new GeoCoordinate();
            GeoCoordinate coorB = new GeoCoordinate();
            double distance;

            foreach (var firstStore in store)
            {
                point1 = firstStore.Location;
                coorA.Latitude = point1.Latitude;
                coorA.Longitude = point1.Longitude;
                foreach (var secondStore in store)
                {
                    point2 = secondStore.Location;
                    coorB.Latitude = point2.Latitude;
                    coorB.Longitude = point2.Longitude;
                    distance = coorA.GetDistanceTo(coorB);
                    if (distance > longestDistance)
                    {
                        longestDistance = distance;

                        farthestTaco1.Name = firstStore.Name;
                        farthestTaco1.Location = point1;

                        farthestTaco2.Name = secondStore.Name;
                        farthestTaco2.Location = point2;
                    }
                }
            }

            double miles = Math.Round(longestDistance * 0.62137119); //rants about Imperial
            Console.WriteLine(longestDistance);


            Console.WriteLine(String.Format($"The two Taco Bells the farthest apart are {farthestTaco1.Name} and {farthestTaco2.Name} with a distance of {miles:n0} miles."));
    }
    }
}
