using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katas.UnitTest
{
    [TestClass]
    public class IntegerToRomanTest
    {

        [DataTestMethod]
        [DataRow(5, "V")]
        [DataRow(3840, "ZMDCCCXL")]
        [DataRow(5900, "ↁCM")]
        public void AddInteger_ReturnsRomanNumber(int input, string expected)
        {
            // Act
            string result = IntegerToRoman.IntegerToRoman.Converter(input);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
