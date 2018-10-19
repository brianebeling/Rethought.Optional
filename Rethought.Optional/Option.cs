using System;
using System.Collections.Generic;

namespace Rethought.Optional
{
    [Serializable]
    public struct Option<T> : IEquatable<Option<T>>, IComparable<Option<T>>
    {
        public bool HasValue { get; }

        internal T Value { get; }

        internal Option(T value, bool hasValue)
        {
            Value = value;
            HasValue = hasValue;
        }

        public bool TryGetValue(out T value)
        {
            if (HasValue)
            {
                value = Value;
                return true;
            }

            value = default;
            return false;
        }

        public bool Equals(Option<T> other)
        {
            if (!HasValue && !other.HasValue)
            {
                return true;
            }

            if (HasValue && other.HasValue)
            {
                return EqualityComparer<T>.Default.Equals(Value, other.Value);
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            return obj is Option<T> option && Equals(option);
        }

        public static bool operator ==(Option<T> left, Option<T> right)
        {
            return left.Equals(right);
        }


        public static bool operator !=(Option<T> left, Option<T> right)
        {
            return !left.Equals(right);
        }

        public static implicit operator Option<T>(T value)
        {
            return Some(value);
        }

        public override int GetHashCode()
        {
            if (!HasValue) return 0;

            return EqualityComparer<T>.Default.Equals(Value, default) ? 1 : Value.GetHashCode();
        }

        public int CompareTo(Option<T> other)
        {
            if (HasValue && !other.HasValue) return 1;
            if (!HasValue && other.HasValue) return -1;
            return Comparer<T>.Default.Compare(Value, other.Value);
        }

        public static bool operator <(Option<T> left, Option<T> right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Option<T> left, Option<T> right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Option<T> left, Option<T> right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Option<T> left, Option<T> right)
        {
            return left.CompareTo(right) >= 0;
        }

        public override string ToString()
        {
            if (!HasValue) return "None";

            return EqualityComparer<T>.Default.Equals(Value, default) ? "Some(null)" : $"Some({Value})";
        }

        public T ValueOr(T alternative)
        {
            return HasValue ? Value : alternative;
        }

        public T ValueOr(Func<T> alternativeFactory)
        {
            if (alternativeFactory == null) throw new ArgumentNullException(nameof(alternativeFactory));
            return HasValue ? Value : alternativeFactory();
        }

        public Option<T> Or(T alternative)
        {
            return HasValue ? this : Some(alternative);
        }

        public Option<T> Or(Func<T> alternativeFactory)
        {
            if (alternativeFactory == null) throw new ArgumentNullException(nameof(alternativeFactory));
            return HasValue ? this : Some(alternativeFactory());
        }

        public Option<T> Else(Option<T> alternativeOption)
        {
            return HasValue ? this : alternativeOption;
        }

        public Option<T> Else(Func<Option<T>> alternativeOptionFactory)
        {
            if (alternativeOptionFactory == null) throw new ArgumentNullException(nameof(alternativeOptionFactory));
            return HasValue ? this : alternativeOptionFactory();
        }

        public static Option<T> Some(T value)
        {
            return new Option<T>(value, true);
        }
    }
}