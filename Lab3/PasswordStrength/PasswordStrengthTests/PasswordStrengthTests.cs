using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordStrength;
namespace PasswordStrengthTests
{
    [TestClass]
    public class PasswordStrengthLibTests
    {
        [TestMethod]
        public void PasswordStrength()
        {
            Assert.AreEqual(7, PasswordStrengthLib.PasswordStrengthProgramm("1"));
            Assert.AreEqual(72, PasswordStrengthLib.PasswordStrengthProgramm("Qwerty123"));
        }


        [TestMethod]
        public void StrengthByLength()
        {
            Assert.AreEqual(16, PasswordStrengthLib.StrengthByLength("Ag1B"));
        }


        [TestMethod]
        public void CalculateByNumbers()
        {
            Assert.AreEqual(8, PasswordStrengthLib.CalculateByNumbers("Ag1B2"));
            Assert.AreEqual(0, PasswordStrengthLib.CalculateByNumbers("qwe"));
        }


        [TestMethod]
        public void CalculateByUpperCase() 
        {
            Assert.AreEqual(0, PasswordStrengthLib.CalculateByUpperCase("X"));
            Assert.AreEqual(6, PasswordStrengthLib.CalculateByUpperCase("Xxxx"));
        }


        [TestMethod]
        public void CalculateByLowerCase() 
        {
            Assert.AreEqual(0, PasswordStrengthLib.CalculateByLowerCase("a"));
            Assert.AreEqual(0, PasswordStrengthLib.CalculateByLowerCase("AAA"));
        }

        [TestMethod]
        public void CalculateByNumbers() 
        {
            Assert.AreEqual(0, PasswordStrengthLib.CalculateByNumbers("132ab"));
        }


        [TestMethod]
        public void CalculateByNumbers() 
        {
            Assert.AreEqual(-1, PasswordStrengthLib.CalculateByNumbers("1"));
            Assert.AreEqual(-4, PasswordStrengthLib.CalculateByNumbers("1123"));
        }

        [TestMethod]
        public void CalculateByReapetedSymbols()
        {
            Assert.AreEqual(-3, PasswordStrengthLib.CalculateByReapetedSymbols("aa12a"));
            Assert.AreEqual(-7, PasswordStrengthLib.CalculateByReapetedSymbols("aa1111a"));
            Assert.AreEqual(0, PasswordStrengthLib.CalculateByReapetedSymbols("123a"));
            Assert.AreEqual(0, PasswordStrengthLib.CalculateByReapetedSymbols("aA"));
        }
    }
}
