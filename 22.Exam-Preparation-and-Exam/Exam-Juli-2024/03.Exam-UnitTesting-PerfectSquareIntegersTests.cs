using NUnit.Framework;

namespace TestApp.Tests
{
    public class PerfectSquareIntegersTests
    {
        [Test]
        public void Test_FindPerfectSquares_StartNumberGreaterThanEndNumber_ReturnsErrorMessage()
        {
            //Arrange
            string expectedResult = "Start number should be less than end number.";

            //Act
            string actualResult = PerfectSquareIntegers.FindPerfectSquares(10, 1);
            Assert.That(expectedResult, Is.EqualTo(actualResult));

        }

        [Test]
        public void Test_FindPerfectSquares_GetSameSquareIntegerForStartAndEnd_ReturnsSameSquareInteger()
        {
            //Arrange
            string expectedResult = "1";

            //Act
            string actualResult = PerfectSquareIntegers.FindPerfectSquares(1, 1);
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void Test_FindPerfectSquares_GetZeroAsSingleInteger_ReturnsZero()
        {

            //Arrange
            string expectedResult = "0";

            //Act
            string actualResult = PerfectSquareIntegers.FindPerfectSquares(0, 0);
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void Test_FindPerfectSquares_RangeIncludesMultiplePerfectSquares_RetursOnlySquareIntegers()
        {
            //Arrange
            string expectedResult = "1 4 9 16 25 36 49";

            //Act
            string actualResult = PerfectSquareIntegers.FindPerfectSquares(1, 50);
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void Test_FindPerfectSquares_NoPerfectSquaresInRange_ReturnsEmptyString()
        {
            //Arrange
            string expectedResult = "";

            //Act
            string actualResult = PerfectSquareIntegers.FindPerfectSquares(2, 3);
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }
    }
}
