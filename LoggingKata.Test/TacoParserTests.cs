using System;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            var tacoParser = new TacoParser();

            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        public void ShouldParseLongitude(string line, double expected)
        {
            var tacoParser = new TacoParser();

            var tacoBell = tacoParser.Parse(line);
            var point = tacoBell.Location;

            Assert.Equal(expected, point.Longitude);
        }

        [Theory]
        [InlineData("30.459515, -84.35516, Taco Bell Tallahassee...", 30.459515)]
        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParser = new TacoParser();

            var tacoBell = tacoParser.Parse(line);
            var point = tacoBell.Location;

            Assert.Equal(expected, point.Latitude);
        }
    }
}
