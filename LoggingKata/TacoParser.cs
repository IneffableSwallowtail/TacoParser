using System;

namespace LoggingKata
{
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                logger.LogInfo("Array is less than 3");
                return null;
            }

            var tacoBell = new TacoBell();
            var point = new Point();
            point.Latitude = Convert.ToDouble(cells[0]);
            point.Longitude = Convert.ToDouble(cells[1]);
            tacoBell.Location = point;
            tacoBell.Name = cells[2];

            return tacoBell;
        }
    }
}