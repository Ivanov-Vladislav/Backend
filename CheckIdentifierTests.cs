using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIdentifierTests
{
    
    [TestClass]
    public class IsLatinLetter
    {

        [TestMethod]
        public void TrueLetter()
        {
            char letter = 'l';
            bool result = CheckIdentifier.Program.IsLetter(letter);
            Assert.AreEqual(true, result);
        }


        [TestMethod]
        public void DigitIs()
        {
            char digit = '4';
            bool result = CheckIdentifier.Program.IsLetter(digit);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Russian()
        {
            char letter = 'ь';
            bool result = CheckIdentifier.Program.IsLetter(letter);
            Assert.AreEqual(false, result);
        }
        
        
        [TestMethod]
        public void Space()
        {
            char letter = ' ';
            bool result = CheckIdentifier.Program.IsLetter(letter);
            Assert.AreEqual(false, result);
        }

    }

    [TestClass]
    public class IsLettersOrDigit
    {
        
        [TestMethod]
        public void SpaceIsNotLetterOrDigit()
        {
            string str = "hello world";
            bool result = CheckIdentifier.Program.IsLettersOrDigit(str);
            Assert.AreEqual(false, result);
        }
        
        [TestMethod]
        public void EmptyStringt()
        {
            string str = "";
            bool result = CheckIdentifier.Program.IsLettersOrDigit(str);
            Assert.AreEqual(true, result);

        [TestMethod]
        public void RussianLetter()
        {
            string str = "hи new world";
            bool result = CheckIdentifier.Program.IsLettersOrDigit(str);
            Assert.AreEqual(false, result);
        }
        
        [TestMethod]
        public void SpecialSymbol()
        {
            string str = "#MyProgram";
            bool result = CheckIdentifier.Program.IsLettersOrDigit(str);
            Assert.AreEqual(false, result);
        }
        
        [TestMethod]
        public void IsLetterOrDigit()
        {
            string str = "Vlad2";
            bool result = CheckIdentifier.Program.IsLettersOrDigit(str);
            Assert.AreEqual(true, result);
        }
    }

    [TestClass]
    public class TakeArgsTests
    

        [TestMethod]
        public void TooFewArgs()
        {
            string[] str = {};
            string input = "";
            bool result = CheckIdentifier.Program.TakeArgs(str, ref input);
            Assert.AreEqual(false, result);
        }
    	
        [TestMethod]
        public void TooManyArgs()
        {
            string[] str = { "1", "2" , "3"};
            string input = "";
            bool result = CheckIdentifier.Program.ParseArgs(str, ref input);
            Assert.AreEqual(false, result);
        }
    	
        
        [TestMethod]
        public void CorrectArgsNumber()
        {
            string[] str = { "new arg" };
            string input = "";
            bool result = CheckIdentifier.Program.ParseArgs(str, ref input);
            Assert.AreEqual(true, result);
        }
    }

    
    [TestClass]
    public class CheckIdentifierTests
    {
        [TestMethod]
        public void StartDigitIsWrong()
        {
            string str = "1worong";
            bool result = CheckIdentifier.Program.CheckIdentifier(str);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void SpecialSymbolIsWrongIdentifier()
        {
            string str = "now*isfalse";
            bool result = CheckIdentifier.Program.CheckIdentifier(str);
            Assert.AreEqual(false, result);
        }
        
        [TestMethod]
        public void RussianInclude()
        {
            string str = "русскийиндетификаторwrong";
            bool result = CheckIdentifier.Program.CheckIdentifier(str);
            Assert.AreEqual(false, result);
        }
        
        [TestMethod]
        public void EmptyString()
        {
            string str = "";
            bool result = CheckIdentifier.Program.CheckIdentifier(str);
            Assert.AreEqual(false, result);
        }

    }
}