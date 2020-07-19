using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBunny.Rules
{
    public class TypeRule : IRule
    {
        public IEnumerable<string> Keywords { get; }

        public string ComparatorText => Type.GetComparators().First();
        public string ValueText => string.Join(", ", Keywords);
        public RuleType Type => RuleType.Type;

        public TypeRule(IEnumerable<string> keywords)
        {
            if (keywords == null || !keywords.Any())
            {
                throw new ArgumentNullException(nameof(keywords),
                    "A list of at least one keyword must be provided.");
            }
        }

        public bool Apply(Transaction transaction)
        {
            return Keywords.Any(w => transaction.Type.Contains(w));
        }
    }
}
