namespace MoneyBunny
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class MvbParser(string file_content)
    {
        private static readonly string YearOfTransactionPrefix = "Kontoauszug";
        private int yearOfTransactions;

        public List<Transaction> Transactions { get; set; } = [];

        private DateTime ParseShortDate(string text, int index = 0) => ParseLongDate(string.Concat(text.AsSpan(index, 6), $"{yearOfTransactions}"));

        private static DateTime ParseLongDate(string text, int index = 0) => DateTime.ParseExact(text.Substring(index, 10), "dd.MM.yyyy", CultureInfo.InvariantCulture);

        private static int ParseValue(string value_as_text)
        {
            var text = value_as_text.Trim(' ', '\r', '\n');

            var amount_as_text = text.Trim(' ', 'S', 'H');
            var amount = double.Parse(amount_as_text, NumberStyles.Any, CultureInfo.GetCultureInfo("de-DE"));

            if (text.EndsWith(" S", StringComparison.InvariantCulture))
            {
                return (int)(amount * -100);
            }
            else if (text.EndsWith(" H", StringComparison.InvariantCulture))
            {
                return (int)(amount * 100);
            }
            else
            {
                throw new ArgumentException("value format is invalid", nameof(value_as_text));
            }
        }

        private int GetYearOfTransaction()
        {
            var prefix_index = file_content.IndexOf(YearOfTransactionPrefix, StringComparison.InvariantCulture);
            prefix_index += YearOfTransactionPrefix.Length;
            while (file_content[prefix_index] != '/')
            {
                ++prefix_index;
            }
            ++prefix_index;
            return int.Parse(file_content.AsSpan(prefix_index, 4), CultureInfo.InvariantCulture);
        }

        private static string ParseTransactionType(string text, int index = 0)
        {
            var end_of_type_index = text.IndexOf("PN:", index, StringComparison.InvariantCulture);
            return text[index..(end_of_type_index - 1)];
        }

        private void ParseTransactions(string transactions_text)
        {
            Transaction transaction = null;

            foreach (var line in transactions_text.Split([Environment.NewLine], StringSplitOptions.RemoveEmptyEntries))
            {
                if (!line.StartsWith(' '))
                {
                    transaction = new Transaction();
                    Transactions.Add(transaction);

                    transaction.Date = ParseShortDate(line);
                    transaction.Type = ParseTransactionType(line, 14);
                    var index = line.IndexOf("PN:", 14, StringComparison.InvariantCulture);
                    index = line.IndexOf(' ', index);
                    transaction.Value = ParseValue(line[index..]);
                    continue;
                }
                if (!string.IsNullOrWhiteSpace(transaction.Reference))
                {
                    transaction.Reference += Environment.NewLine;
                }
                transaction.Reference += line.Trim();
            }
        }

        public bool Parse()
        {
            if (string.IsNullOrWhiteSpace(file_content))
            {
                return false;
            }

            yearOfTransactions = GetYearOfTransaction();


            var mainPattern = @"^\d{2}\.\d{2}\. \d{2}\.\d{2}\. .*,\d{2} [HS]";
            var indentPattern = @"^ {14,}";
            var excludePattern = @"^\s*(Übertrag (auf|von) Blatt|neuer Kontostand vom)";


            var lines = file_content.Split(["\r\n", "\n"], StringSplitOptions.None);

            var filtered = lines
                .Where(line =>
                    Regex.IsMatch(line, mainPattern) ||
                    (Regex.IsMatch(line, indentPattern) && !Regex.IsMatch(line, excludePattern)))
                .ToList();

            ParseTransactions(string.Join("\r\n", filtered));

            return true;
        }
    }
}
