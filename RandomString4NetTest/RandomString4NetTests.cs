using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomString4Net;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RandomString4NetTest
{
    [TestClass]
    public class RandomString4NetTests
    {
        [TestMethod]
        public void ValidateSingleRandomString()
        {
            string randomString = RandomString.GetString(Types.ALPHABET_LOWERCASE);
            Assert.IsNotNull(randomString);
        }

        [TestMethod]
        public void ValidateMultipleRandomStrings()
        {
            List<string> randomStrings = RandomString.GetStrings(Types.ALPHABET_LOWERCASE, 5);
            Assert.IsTrue(randomStrings.Count == 5);
        }

        [TestMethod]
        public void ValidateLowercaseAlphabet()
        {
            string randomString = RandomString.GetString(Types.ALPHABET_LOWERCASE);
            Assert.IsTrue(Regex.IsMatch(randomString, @"^[a-z]+$"));
        }

        [TestMethod]
        public void ValidateUppercaseAlphabet()
        {
            string randomString = RandomString.GetString(Types.ALPHABET_UPPERCASE);
            Assert.IsTrue(Regex.IsMatch(randomString, @"^[A-Z]+$"));
        }

        [TestMethod]
        public void ValidateMixedcaseAlphabet()
        {
            string randomString = RandomString.GetString(Types.ALPHABET_MIXEDCASE);
            Assert.IsTrue(Regex.IsMatch(randomString, @"^[A-Za-z]+$"));

        }
    }
}
