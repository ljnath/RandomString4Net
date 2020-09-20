# RandomString4Net
### Version 1.1.0

Author : Lakhya Jyoti Nath (ljnath)<br>
Date : September 2020<br>
Email : ljnath@ljnath.com<br>
Website : https://www.ljnath.com

[![Nuget](https://img.shields.io/nuget/v/RandomString4Net)](https://www.nuget.org/packages/RandomString4Net/)
[![Nuget](https://img.shields.io/nuget/dt/RandomString4Net)](www.nuget.org/stats/packages/RandomString4Net)
[![Travis (.org)](https://img.shields.io/travis/ljnath/RandomString4Net)](https://travis-ci.org/github/ljnath/RandomString4Net)
![GitHub](https://img.shields.io/github/license/ljnath/RandomString4Net)


## Introduction
RandomString4Net is a library developed in .NET Framework to generate N random strings of M length from various categories. <br>It is fast and suports string generation of various length thus making it ideal for automatic password generation or any similar process.<br><br>
It is parameterized to generate both a single or a list of random strings.<br>
Random strings can be of types alphabet and alphanumeric supporting all the cases viz. lower, upper and mixed.<br>
It also supports symbol during the random string generation process. Following are the list of supported symbols
<br>
!#$%&'()*+,-./:;<=>?@[]\^_`{|}~"

It also allows you to generate random string with only a subset of symbols from the above supported list.
<br><br>

## Supported Types
* **NUMERIC** : *0123456789*
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
    