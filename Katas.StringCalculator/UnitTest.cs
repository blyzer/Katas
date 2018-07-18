using Microsoft.VisualStudio.TestTools.UnitTesting;
using Katas.StringCalculator;

namespace Katas.StringCalculator
{
    [TestClass]
    public class UniTest
    {
        [TestMethod]
        public void Add_EmptyString_ReturnsZero()
        {
            // Act
            string result = StrCalculator.StringCalculator("");

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Add_ReturnsNumber(string input, string expected)
        {
            // Act
            string result = StrCalculator.StringCalculator(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Sub_ReturnsNumber(string input, string expected)
        {
            // Act
            string result = StrCalculator.StringCalculator(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Div_ReturnsNumber(string input, string expected)
        {
            // Act
            string result = StrCalculator.StringCalculator(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Mul_ReturnsNumber(string input, string expected)
        {
            // Act
            string result = StrCalculator.StringCalculator(input);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
