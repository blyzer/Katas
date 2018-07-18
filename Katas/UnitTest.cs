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
            Assert.AreEqual("Raspu\ntin\nDance",Wrapper.Wrap("Rasputin Baila", 5));
        }

        [TestMethod]
        public static void NotSplit_EmtpyString()
        {
            Assert.AreEqual("", Wrapper.Wrap("", 0));
        }

        [TestMethod]
        public static void NotSplit_WhenColumnsBiggerThanText()
        {
            Assert.AreEqual("this is a test", Wrapper.Wrap("this is a test", 20));
        }

        [TestMethod]
        public static void SplitSingleWord_WhenColumnsSmallerThanText()
        {
            Assert.AreEqual("very\nlong", Wrapper.Wrap("verylong", 4));
            Assert.AreEqual("very\nlong\ntext", Wrapper.Wrap("verylongtext", 4));
            Assert.AreEqual("very\nvery\nlong\ntext", Wrapper.Wrap("veryverylongtext", 4));
        }

        [TestMethod]
        public static void SplitSentenceFromSpaces()
        {
            Assert.AreEqual("two\nwor\nds", Wrapper.Wrap("two words", 3));
            Assert.AreEqual("words\nwords", Wrapper.Wrap("words words", 7));
            Assert.AreEqual("words\nwords\nwords", Wrapper.Wrap("words words words", 7));
            Assert.AreEqual("two\ntwo\ntwo", Wrapper.Wrap("two two two", 3));

        }

        [TestMethod]
        public static void SpaceAtTheBeginning()
        {
            Assert.AreEqual(" two\ntwo\ntwo", Wrapper.Wrap(" two two two", 4));
        }
    }
}
