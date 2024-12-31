/**
 * 
 * RandomString4Net - .NET library to generate N random strings of M length from various categories
 * Copyright (c) 2020-2025 Lakhya Jyoti Nath
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
