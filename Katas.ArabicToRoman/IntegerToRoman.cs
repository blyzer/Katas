using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katas.StringCalculator
{
    [TestClass]
    public class UniTest
    {

        [DataTestMethod]
        [DataRow(5)]
        [DataRow(3840)]
        [DataRow(5900)]
        public void AddInteger_ReturnsRomanNumber(int input, string expected)
        {
            // Act
            string result = ArabicToRoman.IntegerNumeralsToRomanNumerals.Converter(input);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
