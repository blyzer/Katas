using Microsoft.VisualStudio.TestTools.UnitTesting;
using Katas.Wrap;

namespace Test
{
    [TestClass]
    public static class UnitTest1
    {
        [TestMethod]
        public static void TestWordWrap()
        {
            Assert.AreEqual("Raspu\ntin\nBai\nla",Wrapper.Wrap("Rasputin Baila", 5));
        }
    }
}
