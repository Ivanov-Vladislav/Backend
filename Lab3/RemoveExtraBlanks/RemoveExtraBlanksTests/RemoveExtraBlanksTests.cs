using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RemoveExtraBlanksTests
{
    [TestClass]
    public class RemoveExtraBlanksLibTests
    {
        [TestMethod]
        public void RemoveExtraBlanks_EmptyString()
        {
            Assert.AreEqual("", RemoveExtraBlanks.Program.RemoveRepetitiveSpaces(""));
        }
        [TestMethod]
        public void RemoveExtraBlanks_StringWithExtraTabs()
        {
            string str = "\t\tsasasas\t\t\trrrr\t";
            string resultStr = "tsasasas\trrrr";
            Assert.AreEqual(resultStr, RemoveExtraBlanks.Program.RemoveRepetitiveSpaces(str));
        }
        [TestMethod]
        public void RemoveExtraBlanks_StringWithExtraBlanks()
        {
            string str = "\t \t123456\t   \t 123   \t1   ";
            string resultStr = "123456\t123 1";
            Assert.AreEqual(resultStr, RemoveExtraBlanks.Program.RemoveRepetitiveSpaces(str));
        }
        [TestMethod]
        public void RemoveExtraBlanks_StringWithoutExtraBlanks_SameStringReturned()
        {
            string str = "qqqqqqq qqq";
            string resultStr = "qqqqqqq qqq";
            Assert.AreEqual(resultStr, RemoveExtraBlanks.Program.RemoveRepetitiveSpaces(str));
        }
    }
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void CopyFileWithRemoveExtraBlanks_NonExistInputFile()
        {
            Assert.AreEqual(false, RemoveExtraBlanks.Program.ParseArgs("input.txt", "output.txt"));
        }
    }
}
