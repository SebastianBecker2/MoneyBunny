using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBunny.Rules
{
    public class ReferenceRule : IRule
    {
        public IEnumerable<string> Keywords { get; }

        public string ComparatorText => Type.GetComparators().First();
        public string ValueText => string.Join(", ", Keywords);
        public RuleType Type => RuleType.Reference;

        public ReferenceRule(IEnumerable<string> keywords)
        {
            if (keywords == null || !keywords.Any())
            {
                throw new ArgumentNullException(nameof(keywords),
                    "A list of at least one keyword must be provided.");
            }

            Keywords = keywords;
        }

        public bool Apply(Transaction transaction)
        {
            return Keywords.Any(w => transaction.Reference.Contains(w));
        }
    }
}
