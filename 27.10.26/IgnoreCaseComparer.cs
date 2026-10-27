using System;
using System.Collections.Generic;

namespace _27._10._26
{
    internal class IgnoreCaseComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return string.Equals(
                x,
                y,
                StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(string obj)
        {
            return StringComparer.OrdinalIgnoreCase
                .GetHashCode(obj);
        }
    }
}
