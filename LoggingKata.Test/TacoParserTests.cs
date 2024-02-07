using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.035985, , Taco Bell Acworth...", -84.683302)]

        [InlineData("34.087508, -84.575512, Taco Bell Acworth...", -84.575512)]
        [InlineData("34.376395, -84.913185, Taco Bell Adairsvill...", -84.913185)]
        [InlineData("33.22997, -86.805275, Taco Bell Alabaste...", -86.805275)]
        [InlineData("31.570771, -84.10353, Taco Bell Albany...", -84.10353)]
        [InlineData("31.597099, -84.176122, Taco Bell Albany...", -84.176122)]
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange
            TacoParser taco = new TacoParser();
            //Act
            ITrackable result = taco.Parse(line);
            //Assert
            Assert.Equal(result.Location.Longitude, expected);
        }


        //TODO: Create a test called ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.035985, , Taco Bell Acworth...", 34.035985)]

        [InlineData("34.087508, -84.575512, Taco Bell Acworth...", 34.087508)]
        [InlineData("34.376395, -84.913185, Taco Bell Adairsvill...", 34.376395)]
        [InlineData("33.22997, -86.805275, Taco Bell Alabaste...", 33.22997)]
        [InlineData("31.570771, -84.10353, Taco Bell Albany...", 31.570771)]
        [InlineData("31.597099, -84.176122, Taco Bell Albany...", 31.597099)]
        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            TacoParser taco = new TacoParser();
            //Act
            ITrackable result = taco.Parse(line);
            //Assert
            Assert.Equal(result.Location.Latitude, expected);
        }

    }
}
