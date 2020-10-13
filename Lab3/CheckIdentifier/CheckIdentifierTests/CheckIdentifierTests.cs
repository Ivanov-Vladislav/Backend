using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckIdentifier;

namespace CheckIdentifierTests
{
    [TestClass]
    public class CheckIdentifierTests
    {
        [TestMethod]
        public void IsLetter()
        {
            Assert.AreEqual(false, CheckIdentifierLib.IsLetter('9'));
            Assert.AreEqual(false, CheckIdentifierLib.IsLetter('-'));
            Assert.AreEqual(true, CheckIdentifierLib.IsLetter('O'));
            Assert.AreEqual(true, CheckIdentifierLib.IsLetter('o'));
        }
        [TestMethod]
        public void IncorrectIdentifier()
        {
            Assert.AreEqual(false, CheckIdentifierLib.IsCorrectIdentifier("O!o"));
            Assert.AreEqual(false, CheckIdentifierLib.IsCorrectIdentifier("7Oo"));
            Assert.AreEqual(true, CheckIdentifierLib.IsCorrectIdentifier("ch"));
            Assert.AreEqual(true, CheckIdentifierLib.IsCorrectIdentifier("Ch1"));
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ParseArgs_FalseReturned()
        {
            string[] args = { };
            Assert.AreEqual(false, Program.ParseArgs(args));
            args = new[] { "", "" };
            Assert.AreEqual(false, Program.ParseArgs(args));
        }

        [TestMethod]
        public void ParseArgs_TrueReturned()
        {
            string[] args = { "123" };
            Assert.AreEqual(true, Program.ParseArgs(args));
        }
    }
}
