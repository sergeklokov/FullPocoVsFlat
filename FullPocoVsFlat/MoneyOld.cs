using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullPocoVsFlat
{

    // C# 8 doesn’t have record, so we implement those features explicitly.

    //public sealed class MoneyOld : IEquatable<MoneyOld>
    //{
    //    public decimal Amount { get; }
    //    public string Currency { get; }

    //    public MoneyOld(decimal amount, string currency)
    //    {
    //        Amount = amount;
    //        Currency = currency ?? throw new ArgumentNullException(nameof(currency));
    //    }

    //    // Value-based equality
    //    public bool Equals(Money other) =>
    //        !(other is null) &&
    //        Amount == other.Amount &&
    //        string.Equals(Currency, other.Currency, StringComparison.Ordinal);

    //    public override bool Equals(object obj) => Equals(obj as Money);

    //    public override int GetHashCode() =>
    //        HashCode.Combine(Amount, Currency); // Available in .NET Core 2.1+ / .NET Standard 2.1+

    //    public static bool operator ==(Money left, Money right) =>
    //        ReferenceEquals(left, right) || (left is not null && left.Equals(right));

    //    public static bool operator !=(Money left, Money right) => !(left == right);

    //    // Same ToString as your record
    //    public override string ToString() => $"{Amount:0.00} {Currency}";

    //    // Optional: deconstruction (positional-record-like)
    //    public void Deconstruct(out decimal amount, out string currency)
    //    {
    //        amount = Amount;
    //        currency = Currency;
    //    }

    //    // Optional: “withers” to emulate record's `with`
    //    public Money WithAmount(decimal amount) => new Money(amount, Currency);
    //    public Money WithCurrency(string currency) => new Money(Amount, currency);
    //}

}
