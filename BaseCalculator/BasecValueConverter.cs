using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCalculator
{
	public class BasedValueConverter
	{
		private readonly long value;
		private enum ValueType : byte { SByte, Byte, Short, UShort, Int, UInt, Long, ULong }
		private enum Basement : byte { Bin, Oct, Dec, Hex }
		private readonly byte[,] MaxLength =
					{   //[type,basement]
					{      8,     3,     3,     2}, // 0=SByte
					{      8,     3,     3,     2}, // 1=Byte
					{     16,     6,     5,     4}, // 2=Short
					{     16,     6,     5,     4}, // 3=UShort
					{     32,    11,    10,     8}, // 4=Int
					{     32,    11,    10,     8}, // 5=UInt
					{     64,    22,    19,    16}, // 6=Long
					{     64,    22,    20,    16}  // 7=ULong
					// 0=Bin, 1=Oct, 2=Dec, 3=Hex
				};
		private readonly ValueType valueType;

		private BasedValueConverter()
		{ }

		public BasedValueConverter(byte value)
		{
			this.value = value;
			valueType = ValueType.Byte;
		}

		public BasedValueConverter(sbyte value)
		{
			this.value = value;
			valueType = ValueType.SByte;
		}

		public BasedValueConverter(short value)
		{
			this.value = value;
			valueType = ValueType.Short;
		}

		public BasedValueConverter(ushort value)
		{
			this.value = value;
			valueType = ValueType.UShort;
		}

		public BasedValueConverter(int value)
		{
			this.value = value;
			valueType = ValueType.Int;
		}

		public BasedValueConverter(uint value)
		{
			this.value = value;
			valueType = ValueType.UInt;
		}

		public BasedValueConverter(long value)
		{
			this.value = value;
			valueType = ValueType.Long;
		}

		public BasedValueConverter(ulong value)
		{
			this.value = (long)value;
			valueType = ValueType.ULong;
		}

		public string ToStringBin()
		{
			return ToBasedString(Basement.Bin);
		}

		public string ToStringOct()
		{
			return ToBasedString(Basement.Oct);
		}

		public string ToStringDec()
		{
			return ToBasedString(Basement.Dec);
		}

		public string ToStringHex()
		{
			return ToBasedString(Basement.Hex);
		}

		private string ToBasedString(Basement basement)
		{
            byte maxlength = GetMaxLength(this.valueType, basement);
            var toBase = basement switch
            {
                Basement.Bin => 2,
                Basement.Oct => 8,
                Basement.Dec => 10,
                Basement.Hex => 16,
                _ => throw new NotSupportedException(String.Format("Basement '{0}' not supported, supported values are: 2=Bin, 8=Oct, 10=Dec, 16=Hex", basement)),
            };
            string result;
            switch (valueType)
			{
				case ValueType.Byte:
					result = Convert.ToString((byte)this.value, toBase);
					break;
				case ValueType.SByte:
					// no base sopport for sbyte
					//result = Convert.ToString((sbyte)this.value,basement);
					byte bval = (byte)this.value;
					result = Convert.ToString(bval, toBase);
					break;
				case ValueType.Short:
					result = Convert.ToString((short)this.value, toBase);
					break;
				case ValueType.UShort:
					// no base sopport for ushort
					//result = Convert.ToString((ushort)this.value,basement);
					short sval = (short)this.value;
					result = Convert.ToString(sval, toBase);
					break;
				case ValueType.Int:
					result = Convert.ToString((int)this.value, toBase);
					break;
				case ValueType.UInt:
					// no base sopport for uint
					//result = Convert.ToString((uint)this.value,basement);
					int ival = (int)this.value;
					result = Convert.ToString(ival, toBase);
					break;
				case ValueType.Long:
					result = Convert.ToString((long)this.value, toBase);
					break;
				case ValueType.ULong:
					// no base sopport for ulong
					//result = Convert.ToString((ulong)this.value,basement);
					long lval = (long)this.value;
					result = Convert.ToString(lval, toBase);
					break;
				default:
					throw new NotSupportedException(String.Format("valueType '{0}' not supported, supported values are: 0=SByte, 1=Byte, 2=Short, 3=UShort, 4=Int, 5=UInt, 6=Long, 7=ULong", valueType));
			}


            result = basement switch
            {
                Basement.Bin => result.PadLeft(maxlength, '0'),
                Basement.Oct => result.PadLeft(maxlength, '0'),
                Basement.Dec => string.Format(string.Concat("{0:D", maxlength, "}"), this.value),
                Basement.Hex => result.ToUpper().PadLeft(maxlength, '0'),
                _ => throw new NotSupportedException(String.Format("Basement '{0}' not supported, supported values are: 2=Bin, 8=Oct, 10=Dec, 16=Hex", basement)),
            };
            return result;
		}

		private byte GetMaxLength(ValueType valType, Basement basement)
		{
			return MaxLength[(int)valueType, (int)basement];
		}
	}
}
