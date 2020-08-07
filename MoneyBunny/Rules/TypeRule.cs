using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBunny.Rules
{
    public class TypeRule : Rule
    {
        public IEnumerable<string> Keywords { get; }

        public override string ComparatorText => Type.GetComparators().First();
        public override string ValueText => string.Join(", ", Keywords);
        public override RuleType Type => RuleType.Type;

        public TypeRule(IEnumerable<string> keywords)
        {
            if (keywords == null || !keywords.Any())
            {
                throw new ArgumentNullException(nameof(keywords),
                    "A list of at least one keyword must be provided.");
            }
        }

        public override bool Apply(Transaction transaction)
        {
            return Keywords.Any(w => transaction.Type.Contains(w));
        }
    }
}
