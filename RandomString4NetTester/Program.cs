using RandomString4Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RandomString4NetTester
{
    static class Program
    {
        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string randomString = RandomString.GetString(Types.ALPHABET_LOWERCASE);
            stopwatch.Stop();
            Console.WriteLine($"Genrated 1 random string, time taken = {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine(randomString);

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine("\n");
                stopwatch.Start();
                List<string> randomStrings = RandomString.GetStrings(Types.NUMBERS, i * 10);
                stopwatch.Stop();
                Console.WriteLine($"Generated a list of {stopwatch.ElapsedMilliseconds} random strings of Type NUMBERS, time taken = {i * 10} ms");
                randomStrings.ForEach(str => Console.Write(str + ", "));
            }

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine("\n");
                stopwatch.Start();
                List<string> randomStrings = RandomString.GetStrings(Types.ALPHANUMERIC_MIXEDCASE, count: i * 10, symbolsToInclude: "+-*/", maxLength: 20, forceUnique: true);
                stopwatch.Stop();
                Console.WriteLine($"Generated a list of {stopwatch.ElapsedMilliseconds} random strings of type ALPHANUMERIC_MIXEDCASE with custom symbols, time taken = {i * 10} ms");
                randomStrings.ForEach(str => Console.Write(str + ", "));
            }

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine("\n");
                stopwatch.Start();
                List<string> randomStrings = RandomString.GetStrings(Types.ALPHANUMERIC_MIXEDCASE_WITH_SYMBOLS, count: i * 10, symbolsToInclude: "+-*/", maxLength: 20, forceUnique: true, forceOccuranceOfEachType: true);
                stopwatch.Stop();
                Console.WriteLine($"Generated a list of {stopwatch.ElapsedMilliseconds} random strings of type ALPHANUMERIC_MIXEDCASE_WITH_SYMBOLS with custom symbols and forced occurance of each type, time taken = {i * 10} ms");
                randomStrings.ForEach(str => Console.Write(str + ", "));
            }

            Console.WriteLine("\n\nGenerating 100000 random string check for duplicates for 100 times");
            stopwatch.Start();
            for (int i = 0; i < 100; i++)
            {
                List<string> randomNumbers = RandomString.GetStrings(Types.NUMBERS, 100000, 10, false, true);

                var anyDuplicate = randomNumbers.GroupBy(x => x).Any(g => g.Count() > 1);
                var allUnique = randomNumbers.GroupBy(x => x).All(g => g.Count() == 1);

                Console.WriteLine($"{i + 1}. duplicate = {anyDuplicate} ; unique = {allUnique}");
            }
            stopwatch.Stop();
            Console.WriteLine($"Time taken = {stopwatch.ElapsedMilliseconds} ms");

            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
