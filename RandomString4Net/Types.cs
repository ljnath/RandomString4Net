using System;

namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class ExtensionAttribute : Attribute { }
}

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
        /// Returns the string corresponding to the enum <c>Types</c>
        /// </summary>
        /// <param name="types"><c>Types</c> for whose equivalent string needs to be constructed</param>
        /// <returns>String equivalent of Enum <c>Types</c></returns>
        public static string GetString(this Types types)
        {
            switch (types)
            {
                case Types.ALPHABET_LOWERCASE: return DataSource.Alphabets;
                case Types.ALPHABET_LOWERCASE_WITH_SYMBOLS: return string.Format("{0}{1}", DataSource.Alphabets, DataSource.Symbols);

                case Types.ALPHABET_UPPERCASE: return Types.ALPHABET_LOWERCASE.GetString().ToUpper();
                case Types.ALPHABET_UPPERCASE_WITH_SYMBOLS: return Types.ALPHABET_LOWERCASE_WITH_SYMBOLS.GetString().ToUpper();

                case Types.ALPHABET_MIXEDCASE: return string.Format("{0}{1}", DataSource.Alphabets.ToLower(), DataSource.Alphabets.ToUpper());
                case Types.ALPHABET_MIXEDCASE_WITH_SYMBOLS: return string.Format("{0}{1}", Types.ALPHABET_MIXEDCASE.GetString(), DataSource.Symbols);

                case Types.ALPHANUMERIC_LOWERCASE: return string.Format("{0}{1}", DataSource.Alphabets, DataSource.Numbers);
                case Types.ALPHANUMERIC_LOWERCASE_WITH_SYMBOLS: return string.Format("{0}{1}", Types.ALPHANUMERIC_LOWERCASE.GetString(), DataSource.Symbols);

                case Types.ALPHANUMERIC_UPPERCASE: return Types.ALPHANUMERIC_LOWERCASE.GetString().ToUpper();
                case Types.ALPHANUMERIC_UPPERCASE_WITH_SYMBOLS: return Types.ALPHANUMERIC_LOWERCASE_WITH_SYMBOLS.GetString().ToUpper();

                case Types.ALPHANUMERIC_MIXEDCASE: return string.Format("{0}{1}", Types.ALPHABET_MIXEDCASE.GetString(), DataSource.Numbers);
                case Types.ALPHANUMERIC_MIXEDCASE_WITH_SYMBOLS: return string.Format("{0}{1}", Types.ALPHANUMERIC_MIXEDCASE.GetString(), DataSource.Symbols);

                case Types.NUMBERS: return DataSource.Numbers;
            }
            return string.Empty;
        }
    }
}