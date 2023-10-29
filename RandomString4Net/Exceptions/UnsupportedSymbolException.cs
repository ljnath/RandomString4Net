/**
 * 
 * RandomString4Net - .NET library to generate N random strings of M length from various categories
 * Copyright (c) 2020-2023 Lakhya Jyoti Nath
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
using System;
using System.Runtime.Serialization;

namespace RandomString4Net.Exceptions
{
    [Serializable]
    public class UnsupportedSymbolException : Exception
    {
        public UnsupportedSymbolException() : base() { }

        public UnsupportedSymbolException(string message) : base(message) { }

        public UnsupportedSymbolException(string format, params object[] args) : base(string.Format(format, args)) { }

        public UnsupportedSymbolException(string message, Exception innerException) : base(message, innerException) { }

        public UnsupportedSymbolException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException) { }

        protected UnsupportedSymbolException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
