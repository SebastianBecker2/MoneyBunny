using MoneyBunny.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MoneyBunny
{
    [DebuggerDisplay("{Date} {Type} {Value}")]
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Reference { get; set; }
        public int Value { get; set; }
        public string CategoryId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Transaction transaction &&
                   Date == transaction.Date &&
                   Type == transaction.Type &&
                   Reference == transaction.Reference &&
                   Value == transaction.Value;
        }

        public override int GetHashCode()
        {
            int hashCode = -1494278302;
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Reference);
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return Date.ToString("d") + " " + Value.ToValueString();
        }

        public static bool operator ==(Transaction left, Transaction right)
        {
            return EqualityComparer<Transaction>.Default.Equals(left, right);
        }

        public static bool operator !=(Transaction left, Transaction right)
        {
            return !(left == right);
        }
    }
}
