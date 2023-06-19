using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Helpers.Generator
{
    public static class KeyGenerator
    {
        public static string Generate()
        {
            Random random = new Random();

            string symbols = "!@#$%^&*()_+=-[]{}|;:,.<>/?";
            string chars = string.Concat(Enumerable.Range(0, 26).Select(i => (char)('a' + i))
                                          .Concat(Enumerable.Range(0, 26).Select(i => (char)('A' + i)))
                                          .Concat(Enumerable.Range(0, 10).Select(i => (char)('0' + i)))
                                          .Concat(symbols));

            string key = new string(Enumerable.Repeat(chars, 23)
                                              .Select(s => s[random.Next(s.Length)]).ToArray());
            return key;
        }
    }
}
