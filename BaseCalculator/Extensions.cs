using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCalculator
{
    public static class Extensions
    {
        public static bool IsEmpty(this string s) => string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s);
        public static long ToInt64(this string s, int from) => Convert.ToInt64(s, from);
        public static ulong ToUInt64(this string s, int from) => Convert.ToUInt64(s, from);

        public static string ConvertTo(this string s, int from, int to) => Convert.ToString(s.ToInt64(from), to);
        public static string UnsignedConvertTo(this string s, int from, int to)
        {
            BasedValueConverter bvc = new(s.ToUInt64(from));
            return to switch
            {
                2 => bvc.ToStringBin(),
                8 => bvc.ToStringOct(),
                10 => bvc.ToStringDec(),
                16 => bvc.ToStringHex(),
                _ => throw new ArgumentException("Invalid Base")
            };
        }
    }
}
