using RandomString4Net;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RandomString4NetTester
{
    static class Program
    {
        static void Main()
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            string randomString = RandomString.GetString(Types.ALPHABET_LOWERCASE);
            s.Stop();
            System.Console.WriteLine(string.Format("Genrated 1 random string, time taken = {0} ms", s.ElapsedMilliseconds));
            System.Console.WriteLine(randomString);

            for (int i = 1; i <= 3; i++)
            {
                System.Console.WriteLine("\n");
                s.Start();
                List<string> randomStrings = RandomString.GetStrings(Types.NUMBERS, i * 10);
                s.Stop();
                System.Console.WriteLine(string.Format("Generated a list of {1} random strings of Type NUMBERS, time taken = {0} ms", s.ElapsedMilliseconds, i * 10));
                foreach (string str in randomStrings)
                    System.Console.Write(str + ", ");
            }

            for (int i = 1; i <= 3; i++)
            {
                System.Console.WriteLine("\n");
                s.Start();
                List<string> randomStrings = RandomString.GetStrings(Types.ALPHANUMERIC_MIXEDCASE, count: i * 10, symbolsToInclude: "+-*/", maxLength: 20, forceUnique: true);
                s.Stop();
                System.Console.WriteLine(string.Format("Generated a list of {1} random strings of type ALPHANUMERIC_MIXEDCASE with custom symbols, time taken = {0} ms", s.ElapsedMilliseconds, i * 10));
                foreach (string str in randomStrings)
                    System.Console.Write(str + ", ");
            }

            for (int i = 1; i <= 3; i++)
            {
                System.Console.WriteLine("\n");
                s.Start();
                List<string> randomStrings = RandomString.GetStrings(Types.ALPHANUMERIC_MIXEDCASE_WITH_SYMBOLS, count: i * 10, symbolsToInclude: "+-*/", maxLength: 20, forceUnique: true, forceOccuranceOfEachType: true);
                s.Stop();
                System.Console.WriteLine(string.Format("Generated a list of {1} random strings of type ALPHANUMERIC_MIXEDCASE_WITH_SYMBOLS with custom symbols and forced occurance of each type, time taken = {0} ms", s.ElapsedMilliseconds, i * 10));
                foreach (string str in randomStrings)
                    System.Console.Write(str + ", ");
            }

            s.Start();
            for (int i = 0; i < 100; i++)
            {
                List<string> randomNumbers = RandomString.GetStrings(Types.NUMBERS, 100000, 10, false, true);

                var anyDuplicate = randomNumbers.GroupBy(x => x).Any(g => g.Count() > 1);
                var allUnique = randomNumbers.GroupBy(x => x).All(g => g.Count() == 1);

                if (anyDuplicate)
                    System.Console.WriteLine(i + 1 + ". duplicate = " + anyDuplicate + " ; unique = " + allUnique);
            }
            s.Stop();
            System.Console.WriteLine(string.Format("Time taken = {0} ms or {1} s", s.ElapsedMilliseconds, s.ElapsedMilliseconds / 1000));



            System.Console.WriteLine("\n\nPress any key to exit...");
            System.Console.ReadKey();
        }
    }
}
