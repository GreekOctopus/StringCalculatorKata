using System;
using NUnit.Framework;
using StringCalculatorKata;

namespace StringCalculatorKataTests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("","0")]
        [TestCase("1", "1")]
        [TestCase("1,2", "3")]
        [TestCase("1,2,3,1,5,11", "23")]
        public void AddWithStringNumbersExpectCorrectResults(string input, string result)
        {
            var target = new StringCalculator();
            Assert.That(target.Add(input), Is.EqualTo(result));
        }

        [TestCase("\n", "0")]
        [TestCase("1\n", "1")]
        [TestCase("1\n2", "3")]
        [TestCase("1\n2,3,1\n5,11", "23")]
        public void AddWithStringNumbersAndNewLineExpectCorrectResults(string input, string result)
        {
            var target = new StringCalculator();
            Assert.That(target.Add(input), Is.EqualTo(result));
        }

        [TestCase("\n", "0")]
        [TestCase("1\n", "1")]
        [TestCase("1\n2", "3")]
        [TestCase("1\n2,3,1\n5,11", "23")]
        [TestCase("//;1\n2;3,1\n5,11", "23")]
        public void AddWithStringNumbersAndNewLineAndExtraDelimiterExpectCorrectResults(string input, string result)
        {
            var target = new StringCalculator();
            Assert.That(target.Add(input), Is.EqualTo(result));
        }

        [TestCase("-1,2", "Negatives not allowed: -1")]
        [TestCase("2,-4,3,-5", "Negatives not allowed: -4,-5")]
        public void AddWithStringNumbersAndNegativeNumbersThrows(string input, string message)
        {
            var target = new StringCalculator();
            var ex = Assert.Throws<Exception>(() => target.Add(input));
            Assert.That(ex.Message, Is.EqualTo(message));
        }

        [TestCase("1001,2", "2")]
        [TestCase("1001,2,3", "5")]
        public void AddWithStringNumbersGreatetThan1000ExpectCorrectResults(string input, string result)
        {
            var target = new StringCalculator();
            Assert.That(target.Add(input), Is.EqualTo(result));
        }

        [TestCase("//[***]\n1***2***3", "6")]
        public void AddWithStringNumbersAndNewLineAndExtraDelimiterWithVariableLengthExpectCorrectResults(string input, string result)
        {
            var target = new StringCalculator();
            Assert.That(target.Add(input), Is.EqualTo(result));
        }

        [TestCase("//[*][%]\n1*2%3", "6")]
        [TestCase("//[**][%]\n1**2%3", "6")]
        [TestCase("//[***][%%]\n1***2%%3", "6")]
        public void AddWithStringNumbersAndNewLineAndExtraDelimiterAndMultipleVariableLengthExpectCorrectResults(string input, string result)
        {
            var target = new StringCalculator();
            Assert.That(target.Add(input), Is.EqualTo(result));
        }

    }
}
