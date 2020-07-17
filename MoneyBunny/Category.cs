using System;
using System.Collections.Generic;

namespace MoneyBunny
{
    public class Category
    {
        public static Category NewCategory(string name)
        {
            return new Category()
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
            };
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Category category &&
                   Id == category.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + EqualityComparer<string>.Default.GetHashCode(Id);
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
