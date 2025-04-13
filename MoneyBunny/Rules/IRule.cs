namespace MoneyBunny.Rules
{
    public interface IRule
    {
        public long? RuleId { get; }
        public string ComparatorText { get; }
        public string ValueText { get; }
        public RuleType Type { get; }
        public long CategoryId { get; }

        public bool Apply(Transaction transaction);
    }
}
