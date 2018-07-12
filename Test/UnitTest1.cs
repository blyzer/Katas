using Microsoft.VisualStudio.TestTools.UnitTesting;
using Katas.various;

namespace Test
{
    [TestClass]
    public static class UnitTest1
    {
        [TestMethod]
        public static void TestStringCalculator()
        {
            string fulano = Program.StringCalculator("1,2,3");

            Assert.AreEqual(expected: "6", actual: Program.StringCalculator("1,2,3"));

            var valueExpected = 0;


        }
    }
}
