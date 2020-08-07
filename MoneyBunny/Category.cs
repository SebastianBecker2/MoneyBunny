using System;
using System.Collections.Generic;
using System.Linq;
using MoneyBunny.Rules;
using Newtonsoft.Json;

namespace MoneyBunny
{
    public class Category
    {
        public static Category NewCategory(string name, IEnumerable<IRule> rules = null)
        {
            return new Category()
            {
                Name = name,
                Rules = rules,
            };
        }

        public long? CategoryId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public IEnumerable<IRule> Rules { get; set; }

        public Category()
        {
        }

        public bool ApplyRules(Transaction transaction)
        {
            if (Rules == null)
            {
                return false;
            }

            return Rules.All(r => r.Apply(transaction));
        }

        public override bool Equals(object obj)
        {
            return obj is Category category &&
                   CategoryId == category.CategoryId;
        }

        public override int GetHashCode()
        {
            return 2108858624 + CategoryId.GetHashCode();
        }

        public static bool operator ==(Category left, Category right)
        {
            return EqualityComparer<Category>.Default.Equals(left, right);
        }

        public static bool operator !=(Category left, Category right)
        {
            return !(left == right);
        }
    }
}
