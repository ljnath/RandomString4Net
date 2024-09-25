/**
 * 
 * RandomString4Net - .NET library to generate N random strings of M length from various categories
 * Copyright (c) 2020-2023 Lakhya Jyoti Nath
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 * 
 * Website: https://ljnath.com
 * Email: ljnath@ljnath.com / lakhya.sci@gmail.com
 * 
 **/
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
        /// <param name="randomLength">Boolean choice if the length of the generated random string should be random as well</param>
        /// <param name="forceOccuranceOfEachType">Boolean choice to indicate if string of each sub-type should present in the generated random string</param>
        /// <returns>A newly generated random string</returns>
        /// <exception cref="InvalidLengthException">Thown if <c>count</c> or <c>maxLenght</c> is less then or equal to 0</exception>
        public static string GetString(Types types, int maxLength = 10, bool randomLength = false, bool forceOccuranceOfEachType = false)
        {
            return GetRandomStrings(types.GetString(), 1, maxLength, randomLength, false, forceOccuranceOfEachType)[0];
        }

        /// <summary>
        /// Generates a random string of input type <c>types</c> having a maximum string length of <c>maxLength</c> including symbols specified as <c>symbolsToInclude</c>
        /// </summary>
        /// <param name="types">Type of RandomString4Net.Types is the type of input string for random string generation</param>
        /// <param name="symbolsToInclude">Subset of symbols from the list of supported symbols, specified as a string</param>
        /// <param name="maxLength">Maximum length of a random string to be generated; default is 10</param>
        /// <param name="randomLength">Boolean choice if the length of the generated random string should be random as well</param>
        /// <param name="forceOccuranceOfEachType">Boolean choice to indicate if string of each sub-type should present in the generated random string</param>
        /// <returns>A newly generated random string</returns>
        /// <exception cref="UnsupportedSymbolException">Thown when the input subset of string is not present in the list of supported symbols</exception>
        /// <exception cref="InvalidLengthException">Thown if <c>count</c> or <c>maxLenght</c> is less then or equal to 0</exception>
        public static string GetString(Types types, string symbolsToInclude, int maxLength = 10, bool randomLength = false, bool forceOccuranceOfEachType = false)
        {
#if NET20
            List<string> inputStrings = new List<string>();
#else
            HashSet<string> inputStrings = new HashSet<string>();
#endif
            foreach (String tempString in types.GetString())
                // excluding symbols as custom symbols are specified
                if (!tempString.Contains("@"))
                    inputStrings.Add(tempString);

            ValidateSymbols(symbolsToInclude);
            inputStrings.Add(symbolsToInclude);

            return GetRandomStrings(inputStrings.ToArray(), 1, maxLength, randomLength, false, forceOccuranceOfEachType)[0];
        }

        /// <summary>
        /// Generates a list of random strings of input type <c>types</c> having a maximum string length of <c>maxLength</c>
        /// </summary>
        /// <param name="types">Type of RandomString4Net.Types is the type of input string for random string generation</param>
        /// <param name="count">Number of random strings to be generated</param>
        /// <param name="maxLength">Maximum length of a random string to be generated; default is 10</param>
        /// <param name="randomLength">Boolean choice if the length of the generated random string should be random as well</param>
        /// <param name="forceUnique">Boolean choice to force generation of only unique numbers, count may not be met if this is set to true</param>
        /// <param name="forceOccuranceOfEachType">Boolean choice to indicate if string of each sub-type should present in the generated random string</param>
        /// <returns>A list of random strings</returns>
        /// <exception cref="InvalidLengthException">Thown if <c>count</c> or <c>maxLenght</c> is less then or equal to 0</exception>
        public static List<string> GetStrings(Types types, int count, int maxLength = 10, bool randomLength = false, bool forceUnique = false, bool forceOccuranceOfEachType = false)
        {
            return GetRandomStrings(types.GetString(), count, maxLength, randomLength, forceUnique, forceOccuranceOfEachType);
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
        /// <param name="forceOccuranceOfEachType">Boolean choice to indicate if string of each sub-type should present in the generated random string</param>
        /// <returns>A list of random strings</returns>
        /// <exception cref="UnsupportedSymbolException">Thown when the input subset of string is not present in the list of supported symbols</exception>
        /// <exception cref="InvalidLengthException">Thown if <c>count</c> or <c>maxLenght</c> is less then or equal to 0</exception>
        public static List<string> GetStrings(Types types, int count, string symbolsToInclude, int maxLength = 10, bool randomLength = false, bool forceUnique = false, bool forceOccuranceOfEachType = false)
        {
#if NET20
            List<string> inputStrings = new List<string>();
#else
            HashSet<string> inputStrings = new HashSet<string>();
#endif
            foreach (String tempString in types.GetString())
                // excluding symbols as custom symbols are specified
                if (!tempString.Contains("@"))
                    inputStrings.Add(tempString);

            ValidateSymbols(symbolsToInclude);
            inputStrings.Add(symbolsToInclude);

            return GetRandomStrings(inputStrings.ToArray(), count, maxLength, randomLength, forceUnique, forceOccuranceOfEachType);
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
        /// <param name="forceOccuranceOfEachType">Boolean choice to indicate if string of each sub-type should present in the generated random string</param>
        /// <returns>A list of random strings</returns>
        /// <exception cref="InvalidLengthException">Thown if <c>count</c> or <c>maxLenght</c> is less then or equal to 0</exception>
        private static List<string> GetRandomStrings(string[] inputStrings, int count, int maxLength, bool randomLength, bool forceUnique, bool forceOccuranceOfEachType)
        {
            if (count <= 0 || maxLength <= 0)
                throw new InvalidLengthException("Number and length of random strings should be a non-zero postive numbver");

            byte[] randomSeeds = new byte[4];

#if NET6_0_OR_GREATER
            RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(randomSeeds);
#else
            // generating a random seed for the Random()
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            rngCryptoServiceProvider.GetBytes(randomSeeds);
#endif

            // creating an instance of Random() using the random seed value
            Random random = new Random(BitConverter.ToInt32(randomSeeds, 0));

            if (!forceOccuranceOfEachType)
                return getRandomStrings(random, String.Join("", inputStrings), count, maxLength, randomLength, forceUnique);
            else
                return getRandomStrings(random, inputStrings, count, maxLength, randomLength, forceUnique);
        }

        private static List<String> getRandomStrings(Random randomInstance, string inputString, int count, int maxLength, bool randomLength, bool forceUnique)
        {
#if NET20
            List<string> randomStrings = new List<string>();
#else
            HashSet<string> randomStrings = new HashSet<string>();
#endif

            int inputStringLength = inputString.Length;
            int outputStringLength;

            for (int i = 0; i < count; i++)
            {
                outputStringLength = randomLength ? randomInstance.Next(1, maxLength) : maxLength;
                StringBuilder currentRandomString = new StringBuilder();

                for (int j = 0; j < outputStringLength; j++)
                    currentRandomString.Append(inputString[randomInstance.Next(inputStringLength)]);

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

        private static List<String> getRandomStrings(Random randomInstance, string[] inputStrings, int count, int maxLength, bool randomLength, bool forceUnique)
        {
#if NET20
            List<string> randomStrings = new List<string>();
#else
            HashSet<string> randomStrings = new HashSet<string>();
#endif

            int inputTypeIndex, inputStringLength, outputStringLength;

            while (randomStrings.Count < count)
            {
                outputStringLength = randomLength ? randomInstance.Next(1, maxLength) : maxLength;
                StringBuilder currentRandomString = new StringBuilder();

                for (int j = 0; j < outputStringLength; j++)
                {
                    inputTypeIndex = randomInstance.Next(0, inputStrings.Length);

                    inputStringLength = inputStrings[inputTypeIndex].Length;
                    currentRandomString.Append(inputStrings[inputTypeIndex][randomInstance.Next(inputStringLength)]);
                }

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
