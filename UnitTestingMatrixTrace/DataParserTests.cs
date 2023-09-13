using MatrixTrace;

namespace MatrixTrace.Tests.UnitTesting.xUnit
{
    public class DataParserTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("    ")]
        [InlineData("0")]
        [InlineData("000")]
        [InlineData("-456")]
        [InlineData("-456.23")]
        [InlineData("123j3v")]
        [InlineData("123.45")]
        [InlineData("  123.45")]
        [InlineData("  1 0")]
        [InlineData("1 0    ")]
        [InlineData("    0   ")]
        [InlineData("     1 0    ")]
        [InlineData("9999999999999999999999999999999999999999999999999")]
        [InlineData("-9999999999999999999999999999999999999999999999999")]
        [InlineData("2147483648")]   // int.MaxValue + 1
        [InlineData("-2147483649")]  // int.MinValue - 1
        public void ToPositive_IncorrectString_ThrowsArgumentOutOfRangeException(string input)
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DataParser.GetPositiveInt(input));
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("545", 545)]
        [InlineData("0101", 101)]
        [InlineData("+121", 121)]
        [InlineData("1   ", 1)]
        [InlineData("     10", 10)]
        [InlineData("    123   ", 123)]
        [InlineData("2147483647", int.MaxValue)]
        public void ToPositive_CorrectString_ReturnsIntegerNumber(string input, int expected)
        {
            // Act
            Int32 actual = DataParser.GetPositiveInt(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}