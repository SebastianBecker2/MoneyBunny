namespace MoneyBunny
{
    using System.Collections.Generic;
    using System.Linq;
    using MoneyBunny.Rules;
    using Newtonsoft.Json;

    public class Category
    {
        public static Category NewCategory(string name, IEnumerable<IRule> rules = null) => new Category()
        {
            Name = name,
            Rules = rules,
        };

        public long? CategoryId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public IEnumerable<IRule> Rules { get; set; }

        public Category()
        {
        }

        public bool ApplyRules(Transaction transaction)
        {
            if (Rules == null || !Rules.Any())
            {
                return false;
            }

            return Rules.All(r => r.Apply(transaction));
        }

        public override bool Equals(object obj) => obj is Category category &&
                   CategoryId == category.CategoryId;

        public override int GetHashCode() => 2108858624 + CategoryId.GetHashCode();

        public static bool operator ==(Category left, Category right) => EqualityComparer<Category>.Default.Equals(left, right);

        public static bool operator !=(Category left, Category right) => !(left == right);
    }
}
