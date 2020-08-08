namespace MoneyBunny.Rules
{
    public interface IRule
    {
        long? RuleId { get; }
        string ComparatorText { get; }
        string ValueText { get; }
        RuleType Type { get; }
        long CategoryId { get; }

        bool Apply(Transaction transaction);
    }
}
