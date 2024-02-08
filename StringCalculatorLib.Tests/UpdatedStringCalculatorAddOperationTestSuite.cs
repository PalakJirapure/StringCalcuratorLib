using StringCalculatorLib;

namespace StringClacularLib.Tests
{
    public class StringCalculatorTests
    {
        [Theory]
        [InlineData("//;\n1;2", new[] { ";" })]
        [InlineData("//[***]\n1***2***3", new[] { "***" })]
        [InlineData("//[*][%]\n1*2%3", new[] { "*", "%" })]
        [InlineData("", null)]
        [InlineData("1,2,3", null)]
        public void GenerateCustomDelimiters_ReturnsExpected(string input, string[] expected)
        {
            // Act
            var actual = StringCalculator.GenerateCustomDelimiters(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("", new int[] { })]
        [InlineData("1", new[] { 1 })]
        [InlineData("1,2,3", new[] { 1, 2, 3 })]
        [InlineData("1\n2,3", new[] { 1, 2, 3 })]
        [InlineData("//;\n1;2", new[] { 1, 2 })]
        [InlineData("-1,2", new[] { -1, 2 })]
        [InlineData("1000,2", new[] { 1000, 2 })]
        [InlineData("1001,2", new[] { 2 })] // Numbers greater than 1000 should be ignored
        public void GenerateNumbersArray_ReturnsExpected(string input, int[] expected)
        {
            // Act
            var actual = StringCalculator.GenerateNumbersArray(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("1\n2,3", 6)]
        [InlineData("//;\n1;2", 3)]
        [InlineData("-1,2", "Negatives not allowed: -1")]
        [InlineData("1000,2", 2)]
        [InlineData("1001,2", 2)] // Numbers greater than 1000 should be ignored
        [InlineData("//[***]\n1***2***3", 6)]
        [InlineData("//[*][%]\n1*2%3", 6)]
        public void Add_ReturnsExpected(string input, object expected)
        {
            if (expected is int)
            {
                // If the expected result is an integer, assert the sum
                int expectedResult = (int)expected;
                int actualResult = StringCalculator.Add(input);
                Assert.Equal(expectedResult, actualResult);
            }
            else if (expected is string)
            {
                // If the expected result is a string, assert the exception message
                string expectedResult = (string)expected;
                var ex = Assert.Throws<ArgumentException>(() => StringCalculator.Add(input));
                Assert.Equal(expectedResult, ex.Message);
            }
        }
    }
}
