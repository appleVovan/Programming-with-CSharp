using AR.ProgrammingWithCSharp.CMS.Common;
using System;
using Xunit;

namespace AR.ProgrammingWithCSharp.CMS.Tests.Common
{
    public class StringHandlerTests
    {
        [Fact]
        public void InsertSpacesValidTest()
        {
            //Arrange
            var input = "TwentyOnePilotsVinyl";
            var expected = "Twenty One Pilots Vinyl";

            //Act
            var actual = input.InsertSpaces();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertSpacesCorrectString()
        {
            //Arrange
            var input = "Twenty One Pilots Vinyl";
            var expected = "Twenty One Pilots Vinyl";

            //Act
            var actual = StringHandler.InsertSpaces(input);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
