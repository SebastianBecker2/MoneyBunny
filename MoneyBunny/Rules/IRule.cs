using DCSoft.RTF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
