using RandomString4Net.Exceptions;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RandomString4Net
{
    public static class RandomString
    {
        public static string GetString(Types types, int maxLength = 10, bool randomLength = false)
        {
            return GetRandomStrings(types.GetString(), 1, maxLength, randomLength)[0];
        }

        public static string GetString(Types types, string symbolsToInclude, int maxLength = 10, bool randomLength = false)
        {
            ValidateSymbols(symbolsToInclude);
            string inputString = string.Format("{0}{1}", types.GetString(), symbolsToInclude);
            return GetRandomStrings(inputString, 1, maxLength, randomLength)[0];
        }

        public static List<string> GetStrings(Types types, int count, int maxLength = 10, bool randomLength = false)
        {
            string inputString = types.GetString();
            return GetRandomStrings(inputString, count, maxLength, randomLength);
        }

        public static List<string> GetStrings(Types types, int count, string symbolsToInclude, int maxLength = 10, bool randomLength = false)
        {
            ValidateSymbols(symbolsToInclude);
            string inputString = string.Format("{0}{1}", types.GetString(), symbolsToInclude);
            return GetRandomStrings(inputString, count, maxLength, randomLength);
        }

        private static void ValidateSymbols(string inputSymbols)
        {
            foreach(char symbol in inputSymbols)
                if (!DataSource.Symbols.Contains(symbol.ToString()))
                    throw new InvalidSymbolsException(string.Format("Input symbols should be a subset of {0}", DataSource.Symbols));
        }

        private static List<string> GetRandomStrings(string inputString, int count, int maxLength, bool randomLength)
        {
            // generating a random seed for the Random()
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] randomSeeds = new byte[1];
            rngCryptoServiceProvider.GetBytes(randomSeeds);

            // creating an instance of Random() using the random seed value
            List<string> randomStrings = new List<string>();
            Random random = new Random(randomSeeds[0]);
            int outputStringLength = randomLength ? random.Next(maxLength) : maxLength;
            int inputStringLength = inputString.Length;

            for (int i = 0; i < count; i++)
            {
                StringBuilder currentRandomString = new StringBuilder();
                for (int j = 0; j < outputStringLength; j++)
                    currentRandomString.Append(inputString[random.Next(inputStringLength)]);
                randomStrings.Add(currentRandomString.ToString());
            }
            return randomStrings;
        }
    }
}
