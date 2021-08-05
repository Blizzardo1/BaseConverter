using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCalculator
{
    public record NumberRecord(string Number, int Base, bool Unsigned = false)
    {
        public string Binary            => Unsigned ? Number.UnsignedConvertTo(Base,  2) : Number.ConvertTo(Base,  2);
        // public string Ternary        => Unsigned ? Number.UnsignedConvertTo(Base,  3) : Number.ConvertTo(Base,  3);
        // public string Quaternary     => Unsigned ? Number.UnsignedConvertTo(Base,  4) : Number.ConvertTo(Base,  4);
        // public string Quinary        => Unsigned ? Number.UnsignedConvertTo(Base,  5) : Number.ConvertTo(Base,  5);
        // public string Senary         => Unsigned ? Number.UnsignedConvertTo(Base,  6) : Number.ConvertTo(Base,  6);
        // public string Septernary     => Unsigned ? Number.UnsignedConvertTo(Base,  7) : Number.ConvertTo(Base,  7);
        public string Octal             => Unsigned ? Number.UnsignedConvertTo(Base,  8) : Number.ConvertTo(Base,  8);
        // public string Nonary         => Unsigned ? Number.UnsignedConvertTo(Base,  9) : Number.ConvertTo(Base,  9);
        public string Decimal           => Unsigned ? Number.UnsignedConvertTo(Base, 10) : Number.ConvertTo(Base, 10);
        // public string Undecimal      => Unsigned ? Number.UnsignedConvertTo(Base, 11) : Number.ConvertTo(Base, 11);
        // public string Duodecimal     => Unsigned ? Number.UnsignedConvertTo(Base, 12) : Number.ConvertTo(Base, 12);
        public string Hexadecimal       => Unsigned ? Number.UnsignedConvertTo(Base, 16) : Number.ConvertTo(Base, 16);
        // public string Vigesimal      => Unsigned ? Number.UnsignedConvertTo(Base, 20) : Number.ConvertTo(Base, 20);
        // public string Sexagesimal    => Unsigned ? Number.UnsignedConvertTo(Base, 60) : Number.ConvertTo(Base, 60);
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Base  2: {Binary}");
            // sb.AppendLine($"Base  3: {Ternary}");
            // sb.AppendLine($"Base  4: {Quaternary}");
            // sb.AppendLine($"Base  5: {Quinary}");
            // sb.AppendLine($"Base  6: {Senary}");
            // sb.AppendLine($"Base  7: {Septernary}");
            sb.AppendLine($"Base  8: {Octal}");
            // sb.AppendLine($"Base  9: {Nonary}");
            sb.AppendLine($"Base 10: {Decimal}");
            // sb.AppendLine($"Base 11: {Undecimal}");
            // sb.AppendLine($"Base 12: {Duodecimal}");
            sb.AppendLine($"Base 16: {Hexadecimal}");
            //sb.AppendLine($"Base 20: {Vigesimal}");
            //sb.AppendLine($"Base 60: {Sexagesimal}");

            return sb.ToString();
        }
    }
}
