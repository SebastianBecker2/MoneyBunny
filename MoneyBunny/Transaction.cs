namespace MoneyBunny
{
    using MoneyBunny.ExtensionMethods;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    [DebuggerDisplay("{Date} {Type} {Value}")]
    public class Transaction
    {
        public long? TransactionId { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Reference { get; set; }
        public int Value { get; set; }
        public long? CategoryId { get; set; }

        public override bool Equals(object obj) => obj is Transaction transaction &&
                   Date == transaction.Date &&
                   Type == transaction.Type &&
                   Reference == transaction.Reference &&
                   Value == transaction.Value;

        public override int GetHashCode() => HashCode.Combine(Date, Type, Reference, Value);

        public override string ToString() => $"{Date:d} {Value.ToValueString()}";

        public static bool operator ==(Transaction left, Transaction right) => EqualityComparer<Transaction>.Default.Equals(left, right);

        public static bool operator !=(Transaction left, Transaction right) => !(left == right);
    }
}
