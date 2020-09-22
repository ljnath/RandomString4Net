using RandomString4Net.Exceptions;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

#if ! NET20
    using System.Linq;
#endif

namespace RandomString4Net
{
    /// <summary>
    /// Main class of the library containing the publically exposed methods and internal logic for random number generation
    /// </summary>
    public static class RandomString
    {
        /// <summary>
        /// Generates a random string of input type <c>types</c> having a maximum string length of <c>maxLength</c>
        /// </summary>
        /// <param name="types">Type of RandomString4Net.Types is the type of input string for random string generation</param>
        /// <param name="maxLength">Maximum length of a random string to be generated; default is 10</param>
        /// <param name="forceUnique">Boolean choice to force generation of only unique numbers, count may not be met if this is set to true</param>
        /// <returns>A newly generated random string</returns>
        /// <exception cref="InvalidLengthException">Thown if <c>count</c> or <c>maxLenght</c> is less then or equal to 0</exception>
        public static string GetString(Types types, int maxLength = 10, bool randomLength = false)
        {
            return GetRandomStrings(types.GetString(), 1, maxLength, randomLength, false)[0];
        }

        /// <summary>
        /// Generates a random string of input type <c>types</c> having a maximum string length of <c>maxLength</c> including symbols specified as <c>symbolsToInclude</c>
        /// </summary>
        /// <param name="types">Type of RandomString4Net.Types is the type of input string for random string generation</param>
        /// <param name="symbolsToInclude">Subset of symbols from the list of supported symbols, specified as a string</param>
        /// <param name="maxLength">Maximum length of a random string to be generated; default is 10</param>
        /// <param name="randomLength">Boolean choice if the length of the generated random string should be random as well</param>
        /// <returns>A newly generated random string</returns>
        /// <exception cref="UnsupportedSymbolException">Thown when the input subset of string is not present in the list of supported symbols</exception>
        /// <exception cref="InvalidLengthException">Thown if <c>count</c> or <c>maxLenght</c> is less then or equal to 0</exception>
        public static string GetString(Types types, string symbolsToInclude, int maxLength = 10, bool randomLength = false)
        {
            ValidateSymbols(symbolsToInclude);
            string inputString = string.Format("{0}{1}", types.GetString(), symbolsToInclude);
            return GetRandomStrings(inputString, 1, maxLength, randomLength, false)[0];
        }

        /// <summary>
        /// Generates a list of random strings of input type <c>types</c> having a maximum string length of <c>maxLength</c>
        /// </summary>
        /// <param name="types">Type of RandomString4Net.Types is the type of input string for random string generation</param>
        /// <param name="count">Number of random strings to be generated</param>
        /// <param name="maxLength">Maximum length of a random string to be generated; default is 10</param>
        /// <param name="randomLength">Boolean choice if the length of the generated random string should be random as well</param>
        /// <param name="forceUnique">Boolean choice to force generation of only unique numbers, count may not be met if this is set to true</param>
        /// <returns>A list of random strings</returns>
        /// <exception cref="InvalidLengthException">Thown if <c>count</c> or <c>maxLenght</c> is less then or equal to 0</exception>
        public static List<string> GetStrings(Types types, int count, int maxLength = 10, bool randomLength = false, bool forceUnique = false)
        {
            string inputString = types.GetString();
            return GetRandomStrings(inputString, count, maxLength, randomLength, forceUnique);
        }

        /// <summary>
        /// Generates a list of random strings of input type <c>types</c> having a maximum string length of <c>maxLength</c>
        /// </summary>
        /// <param name="types">Type of RandomString4Net.Types is the type of input string for random string generation</param>
        /// <param name="count">Number of random strings to be generated</param>
        /// <param name="symbolsToInclude">Subset of symbols from the list of supported symbols, specified as a string</param>
        /// <param name="maxLength">Maximum length of a random string to be generated; default is 10</param>
        /// <param name="randomLength">Boolean choice if the length of the generated random string should be random as well</param>
        /// <param name="forceUnique">Boolean choice to force generation of only unique numbers, count may not be met if this is set to true</param>
        /// <returns>A list of random strings</returns>
        /// <exception cref="UnsupportedSymbolException">Thown when the input subset of string is not present in the list of supported symbols</exception>
        /// <exception cref="InvalidLengthException">Thown if <c>count</c> or <c>maxLenght</c> is less then or equal to 0</exception>
        public static List<string> GetStrings(Types types, int count, string symbolsToInclude, int maxLength = 10, bool randomLength = false, bool forceUnique = false)
        {
            ValidateSymbols(symbolsToInclude);
            string inputString = string.Format("{0}{1}", types.GetString(), symbolsToInclude);
            return GetRandomStrings(inputString, count, maxLength, randomLength, forceUnique);
        }


        /// <summary>
        /// Checks if all the symbols specified in <c>inputSybols</c> are present in the list of supported symbols
        /// </summary>
        /// <param name="inputSymbols">String of symbols for validation </param>
        /// <exception cref="UnsupportedSymbolException">Thown when the input symbols are not present in the list of supported symbols</exception>
        private static void ValidateSymbols(string inputSymbols)
        {
            if (!Regex.IsMatch(inputSymbols, string.Format(@"^[{0}]+$", DataSource.Symbols)))
                throw new UnsupportedSymbolException(string.Format("Input symbols should be a subset of {0}", DataSource.Symbols));
        }

        /// <summary>
        /// Method responsible for generating random strings
        /// </summary>
        /// <param name="inputString">String whose characters are to be used for generating random strings</param>
        /// <param name="count">Number of random string to generate</param>
        /// <param name="maxLength">Maximum length of random string</param>
        /// <param name="randomLength">Boolean choice if the length of the generated random string should be random as well</param>
        /// <param name="forceUnique">Boolean choice to force generation of only unique numbers, count may not be met if this is set to true</param>
        /// <returns>A list of random strings</returns>
        /// <exception cref="InvalidLengthException">Thown if <c>count</c> or <c>maxLenght</c> is less then or equal to 0</exception>
        private static List<string> GetRandomStrings(string inputString, int count, int maxLength, bool randomLength, bool forceUnique)
        {
            if (count <= 0 || maxLength <= 0)
                throw new InvalidLengthException("Number and length of random strings should be a non-zero postive numbver");

            // generating a random seed for the Random()
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] randomSeeds = new byte[1];
            rngCryptoServiceProvider.GetBytes(randomSeeds);

            // creating an instance of Random() using the random seed value
            Random random = new Random(randomSeeds[0]);

            int inputStringLength = inputString.Length;
            int outputStringLength;

#if NET20
            List<string> randomStrings = new List<string>();
#else
            HashSet<string> randomStrings = new HashSet<string>();
#endif

            for (int i = 0; i < count; i++)
            {
                outputStringLength = randomLength ? random.Next(1, maxLength) : maxLength;
                StringBuilder currentRandomString = new StringBuilder();
                for (int j = 0; j < outputStringLength; j++)
                    currentRandomString.Append(inputString[random.Next(inputStringLength)]);

                if (forceUnique && randomStrings.Contains(currentRandomString.ToString()))
                    continue;
                randomStrings.Add(currentRandomString.ToString());
            }

#if NET20
            return randomStrings;
#else
            List<string> finalRandomStrings = randomStrings.ToList();
            return finalRandomStrings;
#endif
        }
    }
}
