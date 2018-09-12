using Microsoft.VisualStudio.TestTools.UnitTesting;
using Katas.Calculator;

namespace Katas.UnitTest
{
    [TestClass]
    public static class UniTest
    {
        [TestMethod]
        public static void Add_EmptyString_ReturnsZero()
        {
            // Act
            string result = StringCalculator.NumbersCalculator("");

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public static void Add_ReturnsNumber(string input, string expected)
        {
            // Act
            string result = StringCalculator.NumbersCalculator(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public static void Sub_ReturnsNumber(string input, string expected)
        {
            // Act
            string result = StringCalculator.NumbersCalculator(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public static void Div_ReturnsNumber(string input, string expected)
        {
            // Act
            string result = StringCalculator.NumbersCalculator(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public static void Mul_ReturnsNumber(string input, string expected)
        {
            // Act
            string result = StringCalculator.NumbersCalculator(input);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
