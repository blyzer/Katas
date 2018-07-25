using Microsoft.VisualStudio.TestTools.UnitTesting;
using Katas.Calculator;

namespace Katas.UnitTest
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void Add_EmptyString_ReturnsZero()
        {
            // Act
            string result = StringCalculator.NumbersCalculator("");

            // Assert
            Assert.AreEqual("Must enter a number or the entered charaters are not numbers", result);
        }

        [DataTestMethod]
        [DataRow("1,2,3", "6 (1 + 2 + 3)")]
        [DataRow("53,6,8", "67 (53 + 6 + 8)")]
        [DataRow("1000,54,83", "1137 (1000 + 54 + 83)")]
        [DataRow("+1 2 3", "6 (1 + 2 + 3)")]
        [DataRow("+53 6 8", "67 (53 + 6 + 8)")]
        [DataRow("+1000 54 83", "1137 (1000 + 54 + 83)")]
        [DataRow("+1;2;3", "6 (1 + 2 + 3)")]
        [DataRow("+53;6;8", "67 (53 + 6 + 8)")]
        [DataRow("+1000;54;83", "1137 (1000 + 54 + 83)")]
        [DataRow("+1 ;2;3+", "6 (1 + 2 + 3)")]
        [DataRow("+53;6;8*", "67 (53 + 6 + 8)")]
        [DataRow("+1000;54; 83+", "1137 (1000 + 54 + 83)")]
        public void Add_ReturnsNumber(string input, string expected)
        {
            // Act
            string result = StringCalculator.NumbersCalculator(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("-1,2,3", "-4 (1 - 2 - 3)")]
        [DataRow("-53,6,8", "39 (53 - 6 - 8)")]
        [DataRow("-1000,54,83", "863 (1000 - 54 - 83)")]
        [DataRow("-1 2 3", "-4 (1 - 2 - 3)")]
        [DataRow("-53 6 8", "39 (53 - 6 - 8)")]
        [DataRow("-1000 54 83", "863 (1000 - 54 - 83)")]
        [DataRow("-1;2;3", "-4 (1 - 2 - 3)")]
        [DataRow("-53;6;8", "39 (53 - 6 - 8)")]
        [DataRow("-1000;54;83", "863 (1000 - 54 - 83)")]
        [DataRow("-1 ;2;3+", "-4 (1 - 2 - 3)")]
        [DataRow("-53;6;8*", "39 (53 - 6 - 8)")]
        [DataRow("-1000;54; 83/", "863 (1000 - 54 - 83)")]
        public void Sub_ReturnsNumber(string input, string expected)
        {
            // Act
            string result = StringCalculator.NumbersCalculator(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("/1,2,3", "0.166666666666667 (1 / 2 / 3)")]
        [DataRow("÷53,6,8", "1.10416666666667 (53 / 6 / 8)")]
        [DataRow("÷1000,54,83", "0.223114680946006 (1000 / 54 / 83)")]
        [DataRow("/1 2 3", "0.166666666666667 (1 / 2 / 3)")]
        [DataRow("÷53 6 8", "1.10416666666667 (53 / 6 / 8)")]
        [DataRow("÷1000 54 83", "0.223114680946006 (1000 / 54 / 83)")]
        [DataRow("/1;2;3", "0.166666666666667 (1 / 2 / 3)")]
        [DataRow("÷53;6;8", "1.10416666666667 (53 / 6 / 8)")]
        [DataRow("÷1000;54;83", "0.223114680946006 (1000 / 54 / 83)")]
        [DataRow("/1 ;2;3+", "0.166666666666667 (1 / 2 / 3)")]
        [DataRow("÷53;6;8*", "1.10416666666667 (53 / 6 / 8)")]
        [DataRow("÷1000;54; 83-", "0.223114680946006 (1000 / 54 / 83)")]
        public void Div_ReturnsNumber(string input, string expected)
        {
            // Act
            string result = StringCalculator.NumbersCalculator(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("*1,2,3", "6 (1 * 2 * 3)")]
        [DataRow("X53,6,8", "2544 (53 * 6 * 8)")]
        [DataRow("x1000,54,83", "4482000 (1000 * 54 * 83)")]
        [DataRow("*1 2 3", "6 (1 * 2 * 3)")]
        [DataRow("X53 6 8", "2544 (53 * 6 * 8)")]
        [DataRow("x1000 54 83", "4482000 (1000 * 54 * 83)")]
        [DataRow("*1;2;3", "6 (1 * 2 * 3)")]
        [DataRow("X53;6;8", "2544 (53 * 6 * 8)")]
        [DataRow("x1000;54;83", "4482000 (1000 * 54 * 83)")]
        [DataRow("*1 ;2;3+", "6 (1 * 2 * 3)")]
        [DataRow("X53;6;8/", "2544 (53 * 6 * 8)")]
        [DataRow("x1000;54; 83-", "4482000 (1000 * 54 * 83)")]
        public void Mul_ReturnsNumber(string input, string expected)
        {
            // Act
            string result = StringCalculator.NumbersCalculator(input);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
