using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCalculator
{
    public record NumberRecord(string Number, int Base, bool UseFloatingPoint = false) {
        private static readonly char[] BaseChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()-=_+;\'\":?\\/.,<>".ToCharArray();
        private static char[] GetChars(int @base) => BaseChars.Take(@base).ToArray();
        
        public string Binary         => UseFloatingPoint ? Number.ExperimentalConvertTo(Base, 2) : Number.ConvertTo(Base,  GetChars(2));
        public string Ternary        => /* UseFloatingPoint ? Number.ExperimentalConvertTo(Base,  3) : */ Number.ConvertTo(Base,  GetChars(3));
        public string Quaternary     => /* UseFloatingPoint ? Number.ExperimentalConvertTo(Base,  4) : */ Number.ConvertTo(Base,  GetChars(4));
        public string Quinary        => /* UseFloatingPoint ? Number.ExperimentalConvertTo(Base,  5) : */ Number.ConvertTo(Base,  GetChars(5));
        public string Senary         => /* UseFloatingPoint ? Number.ExperimentalConvertTo(Base,  6) : */ Number.ConvertTo(Base,  GetChars(6));
        public string Septernary     => /* UseFloatingPoint ? Number.ExperimentalConvertTo(Base,  7) : */ Number.ConvertTo(Base,  GetChars(7));
        public string Octal          => UseFloatingPoint ? Number.ExperimentalConvertTo(Base,  8) : Number.ConvertTo(Base,  GetChars(8));
        public string Nonary         => /* UseFloatingPoint ? Number.ExperimentalConvertTo(Base,  9) :  */Number.ConvertTo(Base,  GetChars(9));
        public string Decimal        => /* UseFloatingPoint ? Number.ExperimentalConvertTo(Base,  10) : */ Number.ConvertTo(Base, GetChars(10));
        public string Undecimal      => /* UseFloatingPoint ? Number.ExperimentalConvertTo(Base,  11) : */ Number.ConvertTo(Base, GetChars(11));
        public string Duodecimal     => /* UseFloatingPoint ? Number.ExperimentalConvertTo(Base,  12) : */ Number.ConvertTo(Base, GetChars(12));
        public string Hexadecimal    => UseFloatingPoint ? Number.ExperimentalConvertTo(Base,  16) : Number.ConvertTo(Base, GetChars(16));
        public string Vigesimal      => /* UseFloatingPoint ? Number.ExperimentalConvertTo(Base,  20) : */ Number.ConvertTo(Base, GetChars(20));
        public string Sexagesimal    => /* UseFloatingPoint ? Number.ExperimentalConvertTo(Base,  60) : */ Number.ConvertTo(Base, GetChars(60));
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Base  2: {Binary}");
            sb.AppendLine($"Base  3: {Ternary}");
            sb.AppendLine($"Base  4: {Quaternary}");
            sb.AppendLine($"Base  5: {Quinary}");
            sb.AppendLine($"Base  6: {Senary}");
            sb.AppendLine($"Base  7: {Septernary}");
            sb.AppendLine($"Base  8: {Octal}");
            sb.AppendLine($"Base  9: {Nonary}");
            sb.AppendLine($"Base 10: {Decimal}");
            sb.AppendLine($"Base 11: {Undecimal}");
            sb.AppendLine($"Base 12: {Duodecimal}");
            sb.AppendLine($"Base 16: {Hexadecimal}");
            sb.AppendLine($"Base 20: {Vigesimal}");
            sb.AppendLine($"Base 60: {Sexagesimal}");

            return sb.ToString();
        }
    }
}
