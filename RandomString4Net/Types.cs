using System;

#if NET20
namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class ExtensionAttribute : Attribute { }
}
#endif

namespace RandomString4Net
{
    /// <summary>
    /// Enum <c>Types</c> are the types of categories supported by the RandomString4Net library
    /// </summary>
    public enum Types
    {
        ALPHABET_LOWERCASE,
        ALPHABET_LOWERCASE_WITH_SYMBOLS,
        ALPHABET_UPPERCASE,
        ALPHABET_UPPERCASE_WITH_SYMBOLS,
        ALPHABET_MIXEDCASE,
        ALPHABET_MIXEDCASE_WITH_SYMBOLS,
        ALPHANUMERIC_LOWERCASE,
        ALPHANUMERIC_LOWERCASE_WITH_SYMBOLS,
        ALPHANUMERIC_UPPERCASE,
        ALPHANUMERIC_UPPERCASE_WITH_SYMBOLS,
        ALPHANUMERIC_MIXEDCASE,
        ALPHANUMERIC_MIXEDCASE_WITH_SYMBOLS,
        NUMBERS
    }
    public static class TypesMethods
    {
        /// <summary>
        /// Returns an array of string corresponding to the enum <c>Types</c>
        /// </summary>
        /// <param name="types"><c>Types</c> for whose equivalent string needs to be constructed</param>
        /// <returns>Arrray of string equivalent of Enum <c>Types</c></returns>
        public static string[] GetString(this Types types)
        {
            switch (types)
            {
                case Types.ALPHABET_LOWERCASE:
                    return new string[]
                    {
                        DataSource.Alphabets
                    };

                case Types.ALPHABET_LOWERCASE_WITH_SYMBOLS:
                    return new string[] {
                        DataSource.Alphabets,
                        DataSource.Symbols
                    };

                case Types.ALPHABET_UPPERCASE:
                    return new string[]
                    {
                        DataSource.Alphabets.ToUpper()
                    };

                case Types.ALPHABET_UPPERCASE_WITH_SYMBOLS:
                    return new string[]
                    {
                        DataSource.Alphabets.ToUpper(),
                        DataSource.Symbols
                    };

                case Types.ALPHABET_MIXEDCASE:
                    return new string[]
                    {
                        DataSource.Alphabets,
                        DataSource.Alphabets.ToUpper()
                    };

                case Types.ALPHABET_MIXEDCASE_WITH_SYMBOLS:
                    return new string[]
                    {
                        DataSource.Alphabets,
                        DataSource.Alphabets.ToUpper(),
                        DataSource.Symbols
                    };

                case Types.ALPHANUMERIC_LOWERCASE:
                    return new string[]
                    {
                        DataSource.Alphabets,
                        DataSource.Numbers
                    };

                case Types.ALPHANUMERIC_LOWERCASE_WITH_SYMBOLS:
                    return new string[]
                    {
                        DataSource.Alphabets,
                        DataSource.Numbers,
                        DataSource.Symbols
                    };

                case Types.ALPHANUMERIC_UPPERCASE:
                    return new string[]
                    {
                        DataSource.Alphabets.ToUpper(),
                        DataSource.Numbers,
                    };

                case Types.ALPHANUMERIC_UPPERCASE_WITH_SYMBOLS:
                    return new string[]
                    {
                        DataSource.Alphabets.ToUpper(),
                        DataSource.Numbers,
                        DataSource.Symbols
                    };

                case Types.ALPHANUMERIC_MIXEDCASE:
                    return new string[]
                    {
                        DataSource.Alphabets,
                        DataSource.Alphabets.ToUpper(),
                        DataSource.Numbers
                    };

                case Types.ALPHANUMERIC_MIXEDCASE_WITH_SYMBOLS:
                    return new string[]
                    {
                        DataSource.Alphabets,
                        DataSource.Alphabets.ToUpper(),
                        DataSource.Numbers,
                        DataSource.Symbols
                    };

                case Types.NUMBERS:
                    return new string[]
                    {
                        DataSource.Numbers
                    };
            }
            return new string[] { String.Empty };
        }
    }
}