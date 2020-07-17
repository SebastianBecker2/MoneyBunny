using sun.tools.tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBunny
{
    public static class ValueExtension
    {
        public static string ToValueString(this int value)
        {
            return string.Format("{0:N2}", (double)value / 100);
        }
    }
}
