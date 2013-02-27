using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public string Add(string input)
        {
            var delimiters = new List<string> {",", "\n"};
            var result = 0;

            CheckForBespokeDelimiter(input, delimiters);

            var numbers = input.Split(delimiters.ToArray(), StringSplitOptions.None);

            CheckForNegatives(numbers);

            foreach(var number in numbers)
            {
                int output;
                Int32.TryParse(number,out output);
                if (output < 1000)
                {
                    result += output;
                }
            }

            return result.ToString(CultureInfo.InvariantCulture);
        }

        private static void CheckForNegatives(IEnumerable<string> numbers)
        {
            var negativesList = string.Empty;
            foreach (var number in numbers)
            {
                int output;
                Int32.TryParse(number, out output);
                if (output < 0)
                {
                    negativesList += output + ",";
                }
            }

            if (negativesList.Length > 0)
            {
                throw new Exception(string.Concat("Negatives not allowed: ", negativesList.Remove(negativesList.Length - 1, 1)));
            }
        }

        private static void CheckForBespokeDelimiter(string input, ICollection<string> delimiters)
        {
            if (input.Length <= 2) return;
            switch (input.Substring(0, 2))
            {
                case "//":
                    if (input.Substring(2, 1) != "[")
                    {
                        delimiters.Add(input.Substring(2, 1));
                    }
                    else
                    {
                        foreach (Match m in Regex.Matches(input, @"(?<=\[)(.*?)(?=\])")) //looks for [ ... ]
                        {
                            var startLocation = m.Index;
                            var endLocation = m.Index + m.Value.Length;
                            delimiters.Add(input.Substring(startLocation, endLocation - startLocation));
                        }                       
                    }
                    break;
            }
        }
    }
}
