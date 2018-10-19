using System;
using System.Globalization;

namespace Rethought.Optional
{
    public static class Parse
    {
        public static Option<byte> ToByte(string s)
        {
            return byte.TryParse(s, out var result) ? result : default;
        }

        public static Option<byte> ToByte(string s, IFormatProvider provider, NumberStyles styles)
        {
            return byte.TryParse(s, styles, provider, out var result) ? result : default;
        }

        public static Option<sbyte> ToSByte(string s)
        {
            return sbyte.TryParse(s, out var result) ? result : default;
        }

        public static Option<sbyte> ToSByte(string s, IFormatProvider provider, NumberStyles styles)
        {
            return sbyte.TryParse(s, styles, provider, out var result) ? result : default;
        }

        public static Option<short> ToShort(string s)
        {
            return short.TryParse(s, out var result) ? result : default;
        }

        public static Option<short> ToShort(string s, IFormatProvider provider, NumberStyles styles)
        {
            return short.TryParse(s, styles, provider, out var result) ? result : default;
        }

        public static Option<ushort> ToUShort(string s)
        {
            return ushort.TryParse(s, out var result) ? result : default;
        }

        public static Option<ushort> ToUShort(string s, IFormatProvider provider, NumberStyles styles)
        {
            return ushort.TryParse(s, styles, provider, out var result) ? result : default;
        }

        public static Option<int> ToInt(string s)
        {
            return int.TryParse(s, out var result) ? result : default;
        }

        public static Option<int> ToInt(string s, IFormatProvider provider, NumberStyles styles)
        {
            return int.TryParse(s, styles, provider, out var result) ? result : default;
        }
        
        public static Option<uint> ToUInt(string s)
        {
            return uint.TryParse(s, out var result) ? result : default;
        }
        
        public static Option<uint> ToUInt(string s, IFormatProvider provider, NumberStyles styles)
        {
            return uint.TryParse(s, styles, provider, out var result) ? result : default;
        }

        public static Option<long> ToLong(string s)
        {
            return long.TryParse(s, out var result) ? result : default;
        }

        public static Option<long> ToLong(string s, IFormatProvider provider, NumberStyles styles)
        {
            return long.TryParse(s, styles, provider, out var result) ? result : default;
        }
        
        public static Option<ulong> ToULong(string s)
        {
            return ulong.TryParse(s, out var result) ? result : default;
        }
        
        public static Option<ulong> ToULong(string s, IFormatProvider provider, NumberStyles styles)
        {
            return ulong.TryParse(s, styles, provider, out var result) ? result : default;
        }

        public static Option<float> ToFloat(string s)
        {
            return float.TryParse(s, out var result) ? result : default;
        }

        public static Option<float> ToFloat(string s, IFormatProvider provider, NumberStyles styles)
        {
            return float.TryParse(s, styles, provider, out var result) ? result : default;
        }

        public static Option<double> ToDouble(string s)
        {
            return double.TryParse(s, out var result) ? result : default;
        }

        public static Option<double> ToDouble(string s, IFormatProvider provider, NumberStyles styles)
        {
            return double.TryParse(s, styles, provider, out var result) ? result : default;
        }

        public static Option<decimal> ToDecimal(string s)
        {
            return decimal.TryParse(s, out var result) ? result : default;
        }

        public static Option<decimal> ToDecimal(string s, IFormatProvider provider, NumberStyles styles)
        {
            return decimal.TryParse(s, styles, provider, out var result) ? result : default;
        }

        public static Option<bool> ToBool(string s)
        {
            return bool.TryParse(s, out var result) ? result : default;
        }

        public static Option<char> ToChar(string s)
        {
            return char.TryParse(s, out var result) ? result : default;
        }

        public static Option<DateTime> ToDateTime(string s)
        {
            return DateTime.TryParse(s, out var result) ? result : default;
        }

        public static Option<DateTime> ToDateTime(string s, IFormatProvider provider, DateTimeStyles styles)
        {
            return DateTime.TryParse(s, provider, styles, out var result) ? result : default;
        }

        public static Option<DateTime> ToDateTimeExact(
            string s,
            string format,
            IFormatProvider provider,
            DateTimeStyles styles)
        {
            return DateTime.TryParseExact(s, format, provider, styles, out var result) ? result : default;
        }

        public static Option<DateTime> ToDateTimeExact(
            string s,
            string[] formats,
            IFormatProvider provider,
            DateTimeStyles styles)
        {
            return DateTime.TryParseExact(s, formats, provider, styles, out var result) ? result : default;
        }

        public static Option<TimeSpan> ToTimeSpan(string s)
        {
            return TimeSpan.TryParse(s, out var result) ? result : default;
        }

        public static Option<DateTimeOffset> ToDateTimeOffset(string s)
        {
            return DateTimeOffset.TryParse(s, out var result) ? result : default;
        }

        public static Option<DateTimeOffset> ToDateTimeOffset(string s, IFormatProvider provider, DateTimeStyles styles)
        {
            return DateTimeOffset.TryParse(s, provider, styles, out var result) ? result : default;
        }

        public static Option<DateTimeOffset> ToDateTimeOffsetExact(
            string s,
            string format,
            IFormatProvider provider,
            DateTimeStyles styles)
        {
            return DateTimeOffset.TryParseExact(s, format, provider, styles, out var result) ? result : default;
        }

        public static Option<DateTimeOffset> ToDateTimeOffsetExact(
            string s,
            string[] formats,
            IFormatProvider provider,
            DateTimeStyles styles)
        {
            return DateTimeOffset.TryParseExact(s, formats, provider, styles, out var result) ? result : default;
        }
    }
}