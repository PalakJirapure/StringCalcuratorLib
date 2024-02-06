using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculatorLib
{
    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            return string.IsNullOrEmpty(numbers) ? 0 : SumNumbers(GetValidNumbers(numbers));
        }

        private static IEnumerable<int> GetValidNumbers(string numbers)
        {
            string[] delimiters = GetDelimiters(ref numbers);

            string delimiterPattern = string.Join("|", delimiters.Select(Regex.Escape));
            string[] numberStrings = Regex.Split(numbers, delimiterPattern);

            foreach (string numberString in numberStrings)
            {
                if (int.TryParse(numberString, out int number))
                {
                    if (number < 0)
                    {
                        throw new ArgumentException($"Negatives not allowed: {numberString}");
                    }

                    // Ignore numbers greater than 1000
                    if (number <= 1000)
                    {
                        yield return number;
                    }
                }
                else
                {
                    throw new ArgumentException($"Invalid input: {numberString}");
                }
            }
        }

        private static string[] GetDelimiters(ref string numbers)
        {
            if (numbers.StartsWith("//"))
            {
                var delimiterMatch = Regex.Match(numbers, @"//(.+?)\n");
                if (delimiterMatch.Success)
                {
                    numbers = numbers.Substring(delimiterMatch.Length);
                    return delimiterMatch.Groups[1].Value.Split(new[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries);
                }
            }
            return new[] { ",", "\n" };
        }

        private static int SumNumbers(IEnumerable<int> numbers)
        {
            List<int> negatives = new List<int>();
            int sum = numbers.Aggregate(0, (acc, number) =>
            {
                if (number < 0)
                {
                    negatives.Add(number);
                }
                return acc + number;
            });

            if (negatives.Any())
            {
                throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negatives)}");
            }

            return sum;
        }
    }
}


