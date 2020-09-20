using RandomString4Net;
using System.Collections.Generic;
using System.Diagnostics;

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
                List<string> randomStrings = RandomString.GetStrings(Types.ALPHANUMERIC_MIXEDCASE, i * 10, "+-*/", 20, true);
                s.Stop();
                System.Console.WriteLine(string.Format("Generated a list of {1} random strings of type ALPHANUMERIC_MIXEDCASE with custom symbols, time taken = {0} ms", s.ElapsedMilliseconds, i * 10));
                foreach (string str in randomStrings)
                    System.Console.Write(str + ", ");
            }

            System.Console.WriteLine("\n\nPress any key to exit...");
            System.Console.ReadKey();
        }
    }
}
