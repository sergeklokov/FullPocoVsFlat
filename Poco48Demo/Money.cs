
using System;

namespace Poco48Demo
{
    public sealed class Money : IEquatable<Money>
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal amount, string currency)
        {
            if (string.IsNullOrWhiteSpace(currency))
                throw new ArgumentException("Currency is required.", nameof(currency));

            Amount = amount;
            Currency = currency;
        }

        public override string ToString() => string.Format("{0:0.00} {1}", Amount, Currency);

        public bool Equals(Money other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Amount == other.Amount && string.Equals(Currency, other.Currency, StringComparison.Ordinal);
        }
        public override bool Equals(object obj) => Equals(obj as Money);
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Amount.GetHashCode();
                hash = hash * 23 + (Currency ?? "").GetHashCode();
                return hash;
            }
        }
        public static bool operator ==(Money left, Money right)
        {
            if (ReferenceEquals(left, right)) return true;
            if ((object)left == null || (object)right == null) return false;
            return left.Equals(right);
        }
        public static bool operator !=(Money left, Money right) => !(left == right);

        public Money WithAmount(decimal amount) => new Money(amount, Currency);
        public Money WithCurrency(string currency) => new Money(Amount, currency);
    }
}
