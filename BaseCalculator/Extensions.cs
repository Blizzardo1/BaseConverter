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

        /// <summary>
        /// Converts any number into a respected based referenced by an array of characters
        /// </summary>
        /// <param name="s">The string that contains a number sequence</param>
        /// <param name="from">The base to which the conversion is to be from</param>
        /// <param name="toBaseChars">The theoretical base to which the conversion is to convert to</param>
        /// <remarks>https://stackoverflow.com/a/923814 provided help for this method.</remarks>
        /// <returns>A <see cref="string"/> that represents a sequence of numbers based on the base the number was converted to.</returns>
        public static string ConvertTo(this string s, int from, char[] toBaseChars) {
            int value = int.Parse(s.ConvertTo(from, 10));
            // long value = BitConverter.DoubleToInt64Bits(double.Parse(s));
            
            int i = 32;
            char[] buffer = new char[i];
            int targetBase = toBaseChars.Length;
            
            do {
                buffer[ --i ] = toBaseChars[ value % targetBase ];
                value /= targetBase;
            }while(value > 0);

            char[] result = new char[32 - i];
            Array.Copy(buffer, i, result, 0, 32 - i);

            return toBaseChars.Length == 10 ? $"{int.Parse(new string(result)):0.###}" : $"{new string(result)}";
        }

        public static string ExperimentalConvertTo(this string s, int from, int to) {
            _ = double.TryParse(s, out double d);
            long val = BitConverter.DoubleToInt64Bits(d);
            byte[] array = BitConverter.GetBytes(val);
            
            return to switch
            {
                2 => Convert.ToString(val, 2),
                8 => Convert.ToString(val, 8),
                10 => BitConverter.ToInt64(array).ToString(),
                16 => string.Join("", array.Select(b => b.ToString("X2")).ToArray()),
                _ => throw new ArgumentException("Invalid Base")
            };
        }

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
