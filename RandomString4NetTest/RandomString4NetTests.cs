using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomString4Net;
using RandomString4Net.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RandomString4NetTest
{
    [TestClass]
    public class RandomString4NetTests
    {
        [TestMethod]
        public void ValidateTypeGetString()
        {
            string[] numbersAsString = Types.NUMBERS.GetString();
            Assert.AreEqual("0123456789", numbersAsString[0]);
        }

        [TestMethod]
        public void ValidateSingleRandomString()
        {
            string randomString = RandomString.GetString(Types.ALPHABET_LOWERCASE);
            Assert.IsNotNull(randomString);
        }

        [TestMethod]
        public void ValidateSingleRandomStringWithSymbols()
        {
            string randomString = RandomString.GetString(Types.ALPHABET_LOWERCASE, "+*-/");
            Assert.IsTrue(Regex.IsMatch(randomString, @"^[a-z+*-/]+$"));
        }

        [TestMethod]
        [ExpectedException(typeof(UnsupportedSymbolException))]
        public void ValidateSingleRandomStringWithBadSymbols()
        {
            RandomString.GetString(Types.ALPHABET_LOWERCASE, "+*-/₹");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidLengthException))]
        public void ValidateSingleRandomStringOfInvalidLength()
        {
            RandomString.GetString(Types.ALPHABET_LOWERCASE, 0);
        }

        [TestMethod]
        public void ValidateMultipleRandomStrings()
        {
            List<string> randomStrings = RandomString.GetStrings(Types.ALPHABET_LOWERCASE, 5);
            Assert.IsTrue(randomStrings.Count == 5);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidLengthException))]
        public void ValidateMultipleRandomStringsOfBadCount()
        {
            RandomString.GetStrings(Types.ALPHABET_LOWERCASE, 0);
        }

        [TestMethod]
        public void ValidateMultipleRandomStringsWithSymbols()
        {
            List<string> randomStrings = RandomString.GetStrings(Types.ALPHABET_UPPERCASE, 2, "+*-/");
            foreach (string randomString in randomStrings)
                Assert.IsTrue(Regex.IsMatch(randomString, @"^[A-Z+*-/]+$", RegexOptions.Compiled));
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

        [TestMethod]
        public void ValidateLowercaseAlphabetWithCustomSymbols()
        {
            string randomString = RandomString.GetString(Types.ALPHABET_LOWERCASE, "*&^%$#@!");
            Assert.IsTrue(Regex.IsMatch(randomString, @"^[a-z*&^%$#@!]+$"));
        }

        [TestMethod]
        public void ValidateUppercaseAlphabetWithCustomSymbols()
        {
            string randomString = RandomString.GetString(Types.ALPHABET_UPPERCASE);
            Assert.IsTrue(Regex.IsMatch(randomString, @"^[A-Z*&^%$#@!]+$"));
        }

        [TestMethod]
        public void ValidateMixedcaseAlphabetWithCustomSymbols()
        {
            string randomString = RandomString.GetString(Types.ALPHABET_MIXEDCASE);
            Assert.IsTrue(Regex.IsMatch(randomString, @"^[a-zA-Z*&^%$#@!]+$"));
        }

        [TestMethod]
        public void ValidateLowercaseAlphaNumericWithSymbols()
        {
            string randomString = RandomString.GetString(Types.ALPHANUMERIC_LOWERCASE_WITH_SYMBOLS);
            Assert.IsTrue(Regex.IsMatch(randomString, @"^[0-9a-z!#$%&'()*+,-./:;<=>?@[\]\\^_`{|}~""]+$"));
        }

        [TestMethod]
        public void ValidateUppercaseAlphaNumericWithSymbols()
        {
            string randomString = RandomString.GetString(Types.ALPHANUMERIC_UPPERCASE_WITH_SYMBOLS, 100);
            System.Console.WriteLine(randomString);
            Assert.IsTrue(Regex.IsMatch(randomString, @"^[0-9A-Z!#$%&'()*+,-./:;<=>?@[\]\\^_`{|}~""]+$"));
        }

        [TestMethod]
        public void ValidateMixedcaseAlphaNumericWithSymbols()
        {
            string randomString = RandomString.GetString(Types.ALPHABET_MIXEDCASE_WITH_SYMBOLS);
            Assert.IsTrue(Regex.IsMatch(randomString, @"^[0-9a-zA-Z!#$%&'()*+,-./:;<=>?@[\]\\^_`{|}~""]+$"));
        }

        [TestMethod]
        public void ValidateRandomNumbers()
        {
            List<string> randomStrings = RandomString.GetStrings(Types.NUMBERS, 10);
            foreach (string randomString in randomStrings)
                Assert.IsTrue(Regex.IsMatch(randomString, "^[0-9]+$", RegexOptions.Compiled));
        }

        [TestMethod]
        public void ValidateRandomNumbersOfMaxLength()
        {
            List<string> randomStrings = RandomString.GetStrings(Types.NUMBERS, 10, 20);
            foreach (string randomString in randomStrings)
                Assert.IsTrue(Regex.IsMatch(randomString, "^[0-9]{20}$", RegexOptions.Compiled));
        }

        [TestMethod]
        public void ValidateRandomNumbersOfRandomLength()
        {
            List<string> randomStrings = RandomString.GetStrings(Types.NUMBERS, 10, 15, true);
            foreach (string randomString in randomStrings)
                Assert.IsTrue(Regex.IsMatch(randomString, "^[0-9]{1,15}$", RegexOptions.Compiled));
        }

        [TestMethod]
        public void ValidateTrueRandomness()
        {
            for (int i = 0; i < 100; i++)
            {
                List<string> randomStrings = RandomString.GetStrings(Types.NUMBERS, 100000, 10, false, true);
                var anyDuplicate = randomStrings.GroupBy(x => x).Any(g => g.Count() > 1);
                Assert.IsFalse(anyDuplicate);
            }
        }

        [TestMethod]
        public void ValidateForceOccuranceForAlphabetWithCustomSymbols()
        {
            for (int i = 0; i < 100; i++)
            {
                List<string> randomStrings = RandomString.GetStrings(Types.ALPHABET_LOWERCASE_WITH_SYMBOLS, symbolsToInclude: "*&^%$#@!", count: 1000, maxLength: 20, forceUnique: false, forceOccuranceOfEachType: true);
                foreach (string randomString in randomStrings)
                    Assert.IsTrue(Regex.IsMatch(randomString, "^[a-z*&^%$#@!]{20}$", RegexOptions.Compiled));
            }
        }

        [TestMethod]
        public void ValidateForceOccuranceForAlphabetUppercaseWithCustomSymbols()
        {
            for (int i = 0; i < 100; i++)
            {
                List<string> randomStrings = RandomString.GetStrings(Types.ALPHABET_UPPERCASE_WITH_SYMBOLS, symbolsToInclude: "*&^%$#@!", count: 1000, maxLength: 20, forceUnique: false, forceOccuranceOfEachType: true);
                foreach (string randomString in randomStrings)
                    Assert.IsTrue(Regex.IsMatch(randomString, "^[A-Z*&^%$#@!]{20}$", RegexOptions.Compiled));
            }
        }

        [TestMethod]
        public void ValidateForceOccuranceForAlphaNumericLowercase()
        {
            for (int i = 0; i < 100; i++)
            {
                List<string> randomStrings = RandomString.GetStrings(Types.ALPHANUMERIC_LOWERCASE, count:1000, maxLength:20, forceUnique:false, forceOccuranceOfEachType:true);
                foreach (string randomString in randomStrings)
                    Assert.IsTrue(Regex.IsMatch(randomString, "^[a-z0-9]{20}$",RegexOptions.Compiled));
            }
        }

        [TestMethod]
        public void ValidateForceOccuranceForAlphaNumericLowercaseWithCustomSymbols()
        {
            for (int i = 0; i < 100; i++)
            {
                List<string> randomStrings = RandomString.GetStrings(Types.ALPHANUMERIC_LOWERCASE_WITH_SYMBOLS, symbolsToInclude:"*&^%$#@!", count: 1000, maxLength: 20, forceUnique: false, forceOccuranceOfEachType: true);
                foreach (string randomString in randomStrings)
                    Assert.IsTrue(Regex.IsMatch(randomString, "^[a-z0-9*&^%$#@!]{20}$", RegexOptions.Compiled));
            }
        }

        [TestMethod]
        public void ValidateForceOccuranceForAlphaNumericUppercase()
        {
            for (int i = 0; i < 100; i++)
            {
                List<string> randomStrings = RandomString.GetStrings(Types.ALPHANUMERIC_UPPERCASE, count: 1000, maxLength: 20, forceUnique: false, forceOccuranceOfEachType: true);
                foreach (string randomString in randomStrings)
                    Assert.IsTrue(Regex.IsMatch(randomString, "^[A-Z0-9]{20}$", RegexOptions.Compiled));
            }
        }

        [TestMethod]
        public void ValidateForceOccuranceForAlphaNumericUppercaseWithCustomSymbols()
        {
            for (int i = 0; i < 100; i++)
            {
                List<string> randomStrings = RandomString.GetStrings(Types.ALPHANUMERIC_UPPERCASE_WITH_SYMBOLS, symbolsToInclude: "*&^%$#@!", count: 1000, maxLength: 20, forceUnique: false, forceOccuranceOfEachType: true);
                foreach (string randomString in randomStrings)
                    Assert.IsTrue(Regex.IsMatch(randomString, "^[A-Z0-9*&^%$#@!]{20}$", RegexOptions.Compiled));
            }
        }

        [TestMethod]
        public void ValidateForceOccuranceForAlphaNumericMixedcase()
        {
            for (int i = 0; i < 100; i++)
            {
                List<string> randomStrings = RandomString.GetStrings(Types.ALPHANUMERIC_MIXEDCASE, count: 1000, maxLength: 20, forceUnique: false, forceOccuranceOfEachType: true);
                foreach (string randomString in randomStrings)
                    Assert.IsTrue(Regex.IsMatch(randomString, "^[a-zA-Z0-9]{20}$", RegexOptions.Compiled));
            }
        }

        [TestMethod]
        public void ValidateForceOccuranceForAlphaNumericMixedcaseWithCustomSymbols()
        {
            for (int i = 0; i < 100; i++)
            {
                List<string> randomStrings = RandomString.GetStrings(Types.ALPHANUMERIC_MIXEDCASE_WITH_SYMBOLS, symbolsToInclude: "*&^%$#@!", count: 1000, maxLength: 20, forceUnique: false, forceOccuranceOfEachType: true);
                foreach (string randomString in randomStrings)
                    Assert.IsTrue(Regex.IsMatch(randomString, "^[a-zA-Z0-9*&^%$#@!]{20}$", RegexOptions.Compiled));
            }
        }
    }
}
