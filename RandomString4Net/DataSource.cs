namespace RandomString4Net
{
    /// <summary>
    /// Class containing the valid inputs for random string generation 
    /// </summary>
    internal static class DataSource
    {
        internal static string Alphabets { get { return "abcdefghijklmnopqrstuvwxyz"; } }
        internal static string Numbers { get { return "0123456789"; } }
        internal static string Symbols { get { return @"!#$%&'()*+,-./:;<=>?@[\]\\^_`{|}~"""; } }
    }
}
