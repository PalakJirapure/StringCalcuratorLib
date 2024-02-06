using StringCalculatorLib;

namespace StringClacularLib.Tests
{
    public class StringCalculatorAddOperationTestSuite
    {
        [Fact]
        public void GivenEmptyStringInputZeroIsExpected()
        {
            //AAA
            string input = "";
            int expectedResult = 0;
            //Act
            int actualResult = StringCalculator.Add(input);
            //Assert
            Assert.Equal(expectedResult, actualResult);

        }

        [Fact]
        public void GivenOneNumberStringInputTheNumberItselfIsExpected()
        {
            //AAA
            string input = "1";
            int expectedResult = 1;
            //Act
            int actualResult = StringCalculator.Add(input);
            //Assert
            Assert.Equal(expectedResult, actualResult);

        }
        [Fact]
        public void GivenTwoNumberStringInputTheSumOfNumberIsExpected()
        {
            //AAA
            string input = "1,2";
            int expectedResult = 3;
            //Act
            int actualResult = StringCalculator.Add(input);
            //Assert
            Assert.Equal(expectedResult, actualResult);

        }
        [Fact]
        public void GivenNumbersAndNewLineBetwenStringInputTheSumOfNumbersIsExpected()
        {
            //AAA
            string input = "1\n2,3";
            int expectedResult = 6;
            //Act
            int actualResult = StringCalculator.Add(input);
            //Assert
            Assert.Equal(expectedResult, actualResult);

        }
        [Fact]
        public void GivenNumbersAndCustomDelemeterStringInputTheSumOfNumbersIsExpected()
        {
            string input = "//;\n1;2";
            int expectedResult = 3;
            int actualResult = StringCalculator.Add(input);
            Assert.Equal(expectedResult, actualResult);

        }
        [Fact]
        public void GivenNegativeNumberStringInputExceptionIsExpected()
        {
            // Arrange
            string input = "-1,2";
            string expectedResult = "Negatives not allowed: -1";

            // Act and Assert
            var ex = Assert.Throws<ArgumentException>(() => StringCalculator.Add(input));
            Assert.Equal(expectedResult, ex.Message);

        }
        [Fact]
        public void GivenNumbersGreaterThan1000StringThenNumberGreaterThan1000IgnoredIsExpected()
        {
            // Arrange
            string input = "1000,2";
            int expectedResult = 2;

            //Act
            int actualResult = StringCalculator.Add(input);
            //Assert
            Assert.Equal(expectedResult, actualResult);

        }
        [Fact]
        public void GivenNumbersAndDelemeterOfAnyLengthThanSumOfNumberOnlyIsExpected()
        {
            string input = "//[***]\n1***2***3";
            int expectedResult = 6;
            int actualResult = StringCalculator.Add(input);
            Assert.Equal(expectedResult, actualResult);

        }
        [Fact]
        public void GivenNumbersAndMultipleDelemeterThanSumOfNumberOnlyIsExpected()
        {
            // Arrange
            string input = "//[*][%]\n1*2%3";
            int expectedResult = 6;

            //Act
            int actualResult = StringCalculator.Add(input);
            //Assert
            Assert.Equal(expectedResult, actualResult);

        }
    }
}