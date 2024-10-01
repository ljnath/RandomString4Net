using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RandomString4Net;
using RandomString4Net.Exceptions;

namespace RandomString4NetTestFramework35
{
    public class RandomString4NetDotNetFramework
    {
        [Test]
        public void ValidateTypeGetString()
        {
            string[] numbersAsString = Types.NUMBERS.GetString();
            Assert.AreEqual("0123456789", numbersAsString[0]);
        }

        [Test]
        public void ValidateSingleRandomString()
        {
            string randomString = RandomString.GetString(Types.ALPHABET_LOWERCASE);
            Assert.IsNotNull(randomString);
        }

        [Test]
        public void ValidateSingleRandomStringWithSymbols()
        {
            string randomString = RandomString.GetString(Types.ALPHABET_LOWERCASE, "+*-/");
            Assert.IsTrue(Regex.IsMatch(randomString, @"^[a-z+*-/]+$"));
        }

        [Test]
        public void ValidateSingleRandomStringWithBadSymbols()
        {
            Assert.Throws<UnsupportedSymbolException>(() => RandomString.GetString(Types.ALPHABET_LOWERCASE, "+*-/₹"));
        }

        [Test]
        public void ValidateSingleRandomStringOfInvalidLength()
        {
            Assert.Throws<InvalidLengthException>(() => RandomString.GetString(Types.ALPHABET_LOWERCASE, 0));
        }

        [Test]
        public void ValidateMultipleRandomStrings()
        {
            List<string> randomStrings = RandomString.GetStrings(Types.ALPHABET_LOWERCASE, 5);
            Assert.IsTrue(randomStrings.Count == 5);
        }

        [Test]
        public void ValidateMultipleRandomStringsOfBadCount()
        {
            Assert.Throws<InvalidLengthException>(() => RandomString.GetStrings(Types.ALPHABET_LOWERCASE, 0));
        }

        [Test]
        public void ValidateMultipleRandomStringsWithSymbols()
        {
            List<string> randomStrings = RandomString.GetStrings(Types.ALPHABET_UPPERCASE, 2, "+*-/");
            Regex compiledRegex = new Regex(@"^[A-Z+*-/]+$", RegexOptions.Compiled);
            foreach (string randomString in randomStrings)
                Assert.IsTrue(compiledRegex.IsMatch(randomString));
        }

        [Test]
        public void ValidateLowercaseAlphabet()
        {
            string randomString = RandomString.GetString(Types.ALPHABET_LOWERCASE);
            Assert.IsTrue(Regex.IsMatch(randomString, @"^[a-z]+$"));
        }

        [Test]
        public void ValidateUppercaseAlphabet()
        {
            string randomString = RandomString.GetString(Types.ALPHABET_UPPERCASE);
            Assert.IsTrue(Regex.IsMatch(randomString, @"^[A-Z]+$"));
        }

        [Test]
        public void ValidateMixedcaseAlphabet()
        {
            string randomString = RandomString.GetString(Types.ALPHABET_MIXEDCASE);
            Assert.IsTrue(Regex.IsMatch(randomString, @"^[A-Za-z]+$"));
        }

        [Test]
        public void ValidateLowercaseAlphabetWithCustomSymbols()
        {
            string randomString = RandomString.GetString(Types.ALPHABET_LOWERCASE, "*&^%$#@!");
            Assert.IsTrue(Regex.IsMatch(randomString, @"^[a-z*&^%$#@!]+$"));
        }

        [Test]
        public void ValidateUppercaseAlphabetWithCustomSymbols()
        {
            string randomString = RandomString.GetString(Types.ALPHABET_UPPERCASE);
            Assert.IsTrue(Regex.IsMatch(randomString, @"^[A-Z*&^%$#@!]+$"));
        }

        [Test]
        public void ValidateMixedcaseAlphabetWithCustomSymbols()
        {
            string randomString = RandomString.GetString(Types.ALPHABET_MIXEDCASE);
            Assert.IsTrue(Regex.IsMatch(randomString, @"^[a-zA-Z*&^%$#@!]+$"));
        }

        [Test]
        public void ValidateLowercaseAlphaNumericWithSymbols()
        {
            string randomString = RandomString.GetString(Types.ALPHANUMERIC_LOWERCASE_WITH_SYMBOLS);
            Assert.IsTrue(Regex.IsMatch(randomString, @"^[0-9a-z!#$%&'()*+,-./:;<=>?@[\]\\^_`{|}~""]+$"));
        }

        [Test]
        public void ValidateUppercaseAlphaNumericWithSymbols()
        {
            string randomString = RandomString.GetString(Types.ALPHANUMERIC_UPPERCASE_WITH_SYMBOLS, 100);
            System.Console.WriteLine(randomString);
            Assert.IsTrue(Regex.IsMatch(randomString, @"^[0-9A-Z!#$%&'()*+,-./:;<=>?@[\]\\^_`{|}~""]+$"));
        }

        [Test]
        public void ValidateMixedcaseAlphaNumericWithSymbols()
        {
            string randomString = RandomString.GetString(Types.ALPHABET_MIXEDCASE_WITH_SYMBOLS);
            Assert.IsTrue(Regex.IsMatch(randomString, @"^[0-9a-zA-Z!#$%&'()*+,-./:;<=>?@[\]\\^_`{|}~""]+$"));
        }

        [Test]
        public void ValidateRandomNumbers()
        {
            List<string> randomStrings = RandomString.GetStrings(Types.NUMBERS, 10);
            Regex compiledRegex = new Regex("^[0-9]+$", RegexOptions.Compiled);
            foreach (string randomString in randomStrings)
                Assert.IsTrue(compiledRegex.IsMatch(randomString));
        }

        [Test]
        public void ValidateRandomNumbersOfMaxLength()
        {
            List<string> randomStrings = RandomString.GetStrings(Types.NUMBERS, 10, 20);
            Regex compiledRegex = new Regex("^[0-9]{20}$", RegexOptions.Compiled);
            foreach (string randomString in randomStrings)
                Assert.IsTrue(compiledRegex.IsMatch(randomString));
        }

        [Test]
        public void ValidateRandomNumbersOfRandomLength()
        {
            List<string> randomStrings = RandomString.GetStrings(Types.NUMBERS, 10, 15, true);
            Regex compiledRegex = new Regex("^[0-9]{1,15}$", RegexOptions.Compiled);
            foreach (string randomString in randomStrings)
                Assert.IsTrue(compiledRegex.IsMatch(randomString));
        }

        [Test]
        public void ValidateTrueRandomness()
        {
            for (int i = 0; i < 100; i++)
            {
                List<string> randomStrings = RandomString.GetStrings(Types.NUMBERS, 10000, 10, false, true);
                var anyDuplicate = randomStrings.GroupBy(x => x).Any(g => g.Count() > 1);
                Assert.IsFalse(anyDuplicate);
            }
        }

        [Test]
        public void ValidateForceOccuranceForAlphabetWithCustomSymbols()
        {
            Regex compiledRegex = new Regex("^[a-z*&^%$#@!]{20}$", RegexOptions.Compiled);
            for (int i = 0; i < 100; i++)
            {
                List<string> randomStrings = RandomString.GetStrings(Types.ALPHABET_LOWERCASE_WITH_SYMBOLS, symbolsToInclude: "*&^%$#@!", count: 1000, maxLength: 20, forceUnique: false, forceOccuranceOfEachType: true);
                foreach (string randomString in randomStrings)
                    Assert.IsTrue(compiledRegex.IsMatch(randomString));
            }
        }

        [Test]
        public void ValidateForceOccuranceForAlphabetUppercaseWithCustomSymbols()
        {
            Regex compiledRegex = new Regex("^[A-Z*&^%$#@!]{20}$", RegexOptions.Compiled);
            for (int i = 0; i < 100; i++)
            {
                List<string> randomStrings = RandomString.GetStrings(Types.ALPHABET_UPPERCASE_WITH_SYMBOLS, symbolsToInclude: "*&^%$#@!", count: 1000, maxLength: 20, forceUnique: false, forceOccuranceOfEachType: true);
                foreach (string randomString in randomStrings)
                    Assert.IsTrue(compiledRegex.IsMatch(randomString));
            }
        }

        [Test]
        public void ValidateForceOccuranceForAlphaNumericLowercase()
        {
            Regex compiledRegex = new Regex("^[a-z0-9]{20}$", RegexOptions.Compiled);
            for (int i = 0; i < 100; i++)
            {
                List<string> randomStrings = RandomString.GetStrings(Types.ALPHANUMERIC_LOWERCASE, count:1000, maxLength:20, forceUnique:false, forceOccuranceOfEachType:true);
                foreach (string randomString in randomStrings)
                    Assert.IsTrue(compiledRegex.IsMatch(randomString));
            }
        }

        [Test]
        public void ValidateForceOccuranceForAlphaNumericLowercaseWithCustomSymbols()
        {
            Regex compiledRegex = new Regex("^[a-z0-9*&^%$#@!]{20}$", RegexOptions.Compiled);
            for (int i = 0; i < 100; i++)
            {
                List<string> randomStrings = RandomString.GetStrings(Types.ALPHANUMERIC_LOWERCASE_WITH_SYMBOLS, symbolsToInclude:"*&^%$#@!", count: 1000, maxLength: 20, forceUnique: false, forceOccuranceOfEachType: true);
                foreach (string randomString in randomStrings)
                    Assert.IsTrue(compiledRegex.IsMatch(randomString));
            }
        }

        [Test]
        public void ValidateForceOccuranceForAlphaNumericUppercase()
        {
            Regex compiledRegex = new Regex("^[A-Z0-9]{20}$", RegexOptions.Compiled);
            for (int i = 0; i < 100; i++)
            {
                List<string> randomStrings = RandomString.GetStrings(Types.ALPHANUMERIC_UPPERCASE, count: 1000, maxLength: 20, forceUnique: false, forceOccuranceOfEachType: true);
                foreach (string randomString in randomStrings)
                    Assert.IsTrue(compiledRegex.IsMatch(randomString));
            }
        }

        [Test]
        public void ValidateForceOccuranceForAlphaNumericUppercaseWithCustomSymbols()
        {
            Regex compiledRegex = new Regex("^[A-Z0-9*&^%$#@!]{20}$", RegexOptions.Compiled);
            for (int i = 0; i < 100; i++)
            {
                List<string> randomStrings = RandomString.GetStrings(Types.ALPHANUMERIC_UPPERCASE_WITH_SYMBOLS, symbolsToInclude: "*&^%$#@!", count: 1000, maxLength: 20, forceUnique: false, forceOccuranceOfEachType: true);
                foreach (string randomString in randomStrings)
                    Assert.IsTrue(compiledRegex.IsMatch(randomString));
            }
        }

        [Test]
        public void ValidateForceOccuranceForAlphaNumericMixedcase()
        {
            Regex compiledRegex = new Regex("^[a-zA-Z0-9]{20}$", RegexOptions.Compiled);
            for (int i = 0; i < 100; i++)
            {
                List<string> randomStrings = RandomString.GetStrings(Types.ALPHANUMERIC_MIXEDCASE, count: 1000, maxLength: 20, forceUnique: false, forceOccuranceOfEachType: true);
                foreach (string randomString in randomStrings)
                    Assert.IsTrue(compiledRegex.IsMatch(randomString));
            }
        }

        [Test]
        public void ValidateForceOccuranceForAlphaNumericMixedcaseWithCustomSymbols()
        {
            Regex compiledRegex = new Regex("^[a-zA-Z0-9*&^%$#@!]{20}$", RegexOptions.Compiled);
            for (int i = 0; i < 100; i++)
            {
                List<string> randomStrings = RandomString.GetStrings(Types.ALPHANUMERIC_MIXEDCASE_WITH_SYMBOLS, symbolsToInclude: "*&^%$#@!", count: 1000, maxLength: 20, forceUnique: false, forceOccuranceOfEachType: true);
                foreach (string randomString in randomStrings)
                    Assert.IsTrue(compiledRegex.IsMatch(randomString));
            }
        }

        [Test]
        public void ValidateForceOccuranceForAlphaNumericMixedcaseWithoutCustomSymbols()
        {
            Regex compiledRegex = new Regex(@"^[0-9a-zA-Z!#$%&'()*+,-.:;<=>?@[\]/\\|^_`{}~""]{20}$", RegexOptions.Compiled);
            for (int i = 0; i < 100; i++)
            {
                List<string> randomStrings = RandomString.GetStrings(Types.ALPHANUMERIC_MIXEDCASE_WITH_SYMBOLS, count: 1000, maxLength: 20, forceUnique: false, forceOccuranceOfEachType: true);
                foreach (string randomString in randomStrings)
                    Assert.IsTrue(compiledRegex.IsMatch(randomString));
            }
        }
    }
}