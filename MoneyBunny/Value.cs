using com.sun.xml.@internal.fastinfoset.util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBunny
{
    public enum Sign
    {
        Positive,
        Negative,
    }

    [DebuggerDisplay("{Amount} {Sign}")]
    public class Value
    {
        public int Amount;
        public Sign Sign;

        public override string ToString()
        {
            if (Sign == Sign.Positive)
            {
                return string.Format("{0:N2} H", (double)Amount / 100);
            }
            else
            {
                return string.Format("{0:N2} S", (double)Amount / 100);
            }
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Value);
        }

        public bool Equals(Value p)
        {
            // If parameter is null, return false.
            if (Object.ReferenceEquals(p, null))
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, p))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != p.GetType())
            {
                return false;
            }

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return (Amount == p.Amount) && (Sign == p.Sign);
        }

        public static bool operator ==(Value lhs, Value rhs)
        {
            // Check for null on left side.
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Value lhs, Value rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            return (int)Sign * 0x00010000 + Amount;
        }
    }
}
