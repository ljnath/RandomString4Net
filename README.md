# RandomString4Net
### Version 1.9.0

Author : Lakhya Jyoti Nath (ljnath)<br>
Date : September 2020 - January 2025<br>
Email : ljnath@ljnath.com<br>
Website : https://www.ljnath.com

[![Nuget](https://img.shields.io/nuget/v/RandomString4Net)](https://www.nuget.org/packages/RandomString4Net/)
[![Nuget](https://img.shields.io/nuget/dt/RandomString4Net)](https://www.nuget.org/stats/packages/RandomString4Net)
![GitHub](https://img.shields.io/github/license/ljnath/RandomString4Net)
![CodeFactor Grade](https://img.shields.io/codefactor/grade/github/ljnath/RandOMString4Net)
![Codecov](https://img.shields.io/codecov/c/github/ljnath/RandomString4Net)


## Introduction
RandomString4Net is a library developed in .NET Framework to generate N random strings of M length from various categories. It is fast and suports string generation of various length.<br><br>
It is parameterized to generate both a single or a list of random strings.<br>
Random strings can be of types alphabet and alphanumeric supporting all the cases viz. lower, upper and mixed.<br>
It also supports symbol during the random string generation process. Following are the list of supported symbols
<br>
!#$%&'()*+,-./:;<=>?@[]\^_`{|}~"

It also allows you to generate random string with only a subset of symbols from the above supported list. It is an ideal use for project like
* password generator
* mobile number generator
* unique-id generator
* unique filename generator
* raw data generator for data processing/parsing projects
* fake name generator
etc. etc.



## Features
* Supports single or multiple random string generation 
* Supports random string generation from alphabet, numbers, symbols or a combination of them
* Supports customized length of randon string
* Supports random length of generated strings with a fixed max length
* Supports true unique random number generation (v1.3.0)
* Built with compilation conditions to take advantage of newer .NET Framework functionalities
* Improved performance in newer .NET Framework ( >2.0)
* Added support to force include strings of each type (version 1.4.0)
* Added support for .NET (>5.0)
* Added support for .NET Core (>2.2)
* Added support for .NET Standard (>2.0)
* Added support for RandomNumberGenerator in .NET 6.0 and higher as RNGCryptoServiceProvider is marked as obsolete
* Added support for .NET 8.0
* Added support for .NET 9.0
* Updated random seed to 4 (https://github.com/jshergal/)


## Supported Types
* **NUMBER** : *0123456789*
* **SYMBOLS** : *!#$%&'()\*+,-./:;<=>?@[]\^_`{|}~"*
* **ALPHABET_LOWERCASE** : *abcdefghijklmnopqrstuvwxyz*
* **ALPHABET_UPPERCASE** : *ABCDEFGHIJKLMNOPQRSTUVWXYZ*
* **ALPHABET_MIXEDCASE** : *abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ*
* **ALPHANUMERIC_LOWERCASE** : *abcdefghijklmnopqrstuvwxyz0123456789*
* **ALPHANUMERIC_UPPERCASE** : *ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789*
* **ALPHANUMERIC_MIXEDCASE** : *abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789*
* **ALPHABET_LOWERCASE_WITH_SYMBOLS** : *abcdefghijklmnopqrstuvwxyz!#$%&'()\*+,-./:;<=>?@[]\^_`{|}~"*
* **ALPHABET_UPPERCASE_WITH_SYMBOLS** : *ABCDEFGHIJKLMNOPQRSTUVWXYZ!#$%&'()\*+,-./:;<=>?@[]\^_`{|}~"*
* **ALPHABET_MIXEDCASE_WITH_SYMBOLS** : *abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!#$%&'()\*+,-./:;<=>?@[]\^_`{|}~"*
* **ALPHANUMERIC_LOWERCASE_WITH_SYMBOLS** : *abcdefghijklmnopqrstuvwxyz0123456789!#$%&'()\*+,-./:;<=>?@[]\^_`{|}~"*
* **ALPHANUMERIC_UPPERCASE_WITH_SYMBOLS** : *ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!#$%&'()\*+,-./:;<=>?@[]\^_`{|}~"*
* **ALPHANUMERIC_MIXEDCASE_WITH_SYMBOLS** : *abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789" !#$%&'()\*+,-./:;<=>?@[]\^_`{|}~"*


## Get Started
### 1. Install Package
```ini
PM> Install-Package RandomString4Net
```
### 2. Add reference in your project

### 3. Call the methods in your program
```csharp
using RandomString4Net;

namespace RandomString4NetTester
{
    public void Main()
    {
        // generating one random string from lowercase alphabets
        string randomString = RandomString.GetString(Types.ALPHABET_LOWERCASE);
        System.Console.WriteLine(randomString);

        // generating 100 random string from all mixedcase alphabet, numbers and all supported symbols
        List<string> randomAlphaNumbericStrings = RandomString.GetStrings(Types.ALPHANUMERIC_MIXEDCASE_WITH_SYMBOLS, 100);
        foreach (string s in randomAlphaNumbericStrings)
            System.Console.WriteLine(s);

        // generating 200 random string from uppercase alphabet with custom symbols
        List<string> randomAlphabetWithCustomSymbols = RandomString.GetStrings(Types.ALPHABET_UPPERCASE, 200, "/+*-");
        foreach (string s in randomAlphabetWithCustomSymbols)
            System.Console.WriteLine(s);

        // generating 1000 true random strings of length 20 from uppercase alphabet with custom symbols
        List<string> trueUniqueRandomStrings = RandomString.GetStrings(Types.ALPHABET_UPPERCASE, 1000, 20, false, true);
        foreach (string s in trueUniqueRandomStrings)
            System.Console.WriteLine(s);

        // generating 100 random string of mixedcase alphanummeric with custom symbols
        List<string> randomAlphabetWithCustomSymbols = RandomString.GetStrings(Types.ALPHANUMERIC_MIXEDCASE_WITH_SYMBOLS, 100, "/+*-", forceOccuranceOfEachType: true);
        foreach (string s in randomAlphabetWithCustomSymbols)
            System.Console.WriteLine(s);
    }
}
```
    
## Give a Star! ⭐️

If you find this repository useful, please give it a star.
Thanks in advance !

## License

Copyright © 2020-2025 [Lakhya's Innovation Inc.](https://github.com/ljnath/) under the [MIT License](https://github.com/ljnath/RandomString4Net/blob/master/LICENSE).
