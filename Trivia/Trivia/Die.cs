using System;
using System.Diagnostics.CodeAnalysis;

namespace Trivia
{
    public sealed class Die : IEquatable<Die>
    {
        private readonly int _value;

        public Die(int roll)
        {
            if (roll > 6 || roll < 1)
            {
                throw new ArgumentException();
            }

            _value = roll;
        }

        public bool Equals([AllowNull] Die other)
        {
            return _value == other._value;
        }

        public int GetValue()
        {
            return _value;
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public static int operator %(Die left, int right)
        {
            return left._value % right;
        }

        public static bool operator ==(Die left, Die right)
        {
            return left._value == right._value;
        }

        public static bool operator !=(Die left, Die right)
        {
            return left._value != right._value;
        }
    }
}
