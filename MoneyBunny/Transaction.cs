using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBunny
{
    [DebuggerDisplay("{Date} {Type} {Value}")]
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Reference { get; set; }
        public Value Value { get; set; }
    }
}
